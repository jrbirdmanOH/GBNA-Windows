using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Thayer.Birding.UI.Windows
{
	public partial class CustomCompareForm : BaseForm
	{
        private int? initialCategoryID = null;
        private int? initialCustomQuizID = null;

		private Audio leftAudio = null;
		private Audio rightAudio = null;

		private const string PlayRecordingText = "Play &Recording";
		private const string StopRecordingText = "Stop &Recording";

        private List<CustomQuizCategory> categories = null;

		public CustomCompareForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

        public int? InitialCategoryID
        {
            get
            {
                return initialCategoryID;
            }

            set
            {
                initialCategoryID = value;
            }
        }

        public int? InitialCustomQuizID
        {
            get
            {
                return initialCustomQuizID;
            }

            set
            {
                initialCustomQuizID = value;
            }
        }

		protected override void OnLoad(EventArgs e)
		{
            Cursor = Cursors.WaitCursor;

            try
            {
                base.OnLoad(e);

                LoadCategories();

                // Set initial category filter
                if (this.InitialCategoryID.HasValue)
                {
                    int categoryIndex = -1;
                    foreach (CustomQuizCategory category in categories)
                    {
                        categoryIndex++;
                        if (category.ID == this.InitialCategoryID.Value)
                        {
                            categoryComboBox.SelectedIndex = categoryIndex;
                            break;
                        }
                    }
                }
                else
                {
                    categoryComboBox.SelectedIndex = 0;
                }

                // Set initial custom quiz filter
                if (this.InitialCustomQuizID.HasValue)
                {
                    int customQuizIndex = -1;
                    List<CustomQuiz> customQuizzes = quizComboBox.DataSource as List<CustomQuiz>;
                    foreach (CustomQuiz customQuiz in customQuizzes)
                    {
                        customQuizIndex++;
                        if (customQuiz.ID == this.InitialCustomQuizID.Value)
                        {
                            quizComboBox.SelectedIndex = customQuizIndex;
                            break;
                        }
                    }
                }

                if (splitContainer.Orientation == Orientation.Vertical)
                {
                    horizontalToolStripMenuItem.Checked = true;
                }
                else
                {
                    verticalToolStripMenuItem.Checked = true;
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

            // Make sure to stop sound if the Utility class was used to play sound
            Utility.StopSound();

			if (leftAudio != null)
			{
				StopAudio(leftAudio);
			}

			if (rightAudio != null)
			{
				StopAudio(rightAudio);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (leftAudio != null)
				{
					leftAudio.Dispose();
				}

				if (rightAudio != null)
				{
					rightAudio.Dispose();
				}

				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			if (this.IsHandleCreated && WindowState != FormWindowState.Minimized)
			{
				UpdateLayout();
			}
		}

		private void UpdateLayout()
		{
			UpdateSplitterPosition();
			UpdateComboBoxLayout();
			RefreshLeftPhoto();
			RefreshRightPhoto();
		}

        private void leftCustomThingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshLeftMedia();
        }

        private void rightCustomThingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRightMedia();
        }

		private void RefreshLeftMedia()
		{
			RefreshMedia(leftCustomThingComboBox, leftMediaComboBox, playRecordingLeftToolStripMenuItem);
		}

		private void RefreshRightMedia()
		{
			RefreshMedia(rightCustomThingComboBox, rightMediaComboBox, playRecordingRightToolStripMenuItem);
		}

		private void RefreshMedia(ComboBox organismComboBox, MediaComboBox mediaComboBox, ToolStripMenuItem playRecordingMenuItem)
		{
            CustomThing customThing = organismComboBox.SelectedItem as CustomThing;
            mediaComboBox.Thing = customThing;

            if (customThing != null)
			{
				mediaComboBox.SelectedIndex = 0;
                playRecordingMenuItem.Enabled = customThing.Sounds.Count > 0;
			}
		}

		private void RefreshLeftPhoto()
		{
			RefreshPhoto(leftMediaComboBox, leftPictureBox);
		}

		private void RefreshRightPhoto()
		{
			RefreshPhoto(rightMediaComboBox, rightPictureBox);
		}

		private void RefreshPhoto(MediaComboBox mediaComboBox, PictureBox pictureBox)
		{
			IMedia item = mediaComboBox.SelectedMedia;
			if (item != null)
			{
				if (item.Type == MediaType.Sound)
				{
					Utility.PlaySound(item.AbsolutePath);
				}
				else
				{
					if (pictureBox.Width > 0 && pictureBox.Height > 0)
					{
						Bitmap picture = new Bitmap(item.AbsolutePath);
						System.Drawing.Size newSize = Utility.GetOptimalSize(picture, pictureBox.Size);
						pictureBox.Image = new Bitmap(picture, newSize);
					}
				}
			}
		}

		private void leftMediaComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StopAudio(leftAudio, playRecordingLeftToolStripMenuItem);
			RefreshLeftPhoto();
		}

		private void rightMediaComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			StopAudio(rightAudio, playRecordingRightToolStripMenuItem);
			RefreshRightPhoto();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			verticalToolStripMenuItem.Checked = false;
			horizontalToolStripMenuItem.Checked = true;

			splitContainer.Orientation = Orientation.Vertical;
			UpdateLayout();
		}

		private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
		{
			verticalToolStripMenuItem.Checked = true;
			horizontalToolStripMenuItem.Checked = false;

			splitContainer.Orientation = Orientation.Horizontal;
			UpdateLayout();
		}

		private void UpdateSplitterPosition()
		{
			if (splitContainer.Orientation == Orientation.Horizontal)
			{
				splitContainer.SplitterDistance = (splitContainer.Height - splitContainer.SplitterWidth) / 2;
			}
			else
			{
				splitContainer.SplitterDistance = (splitContainer.Width - splitContainer.SplitterWidth) / 2;
			}
		}

		private void UpdateComboBoxLayout()
		{
			int space = 5;
			int dropDownWidth = 225;

			int leftComboBoxWidth = (leftPanel.Width - space) / 2;
			leftCustomThingComboBox.Width = leftComboBoxWidth;
			leftCustomThingComboBox.DropDownWidth = dropDownWidth;
			leftMediaComboBox.Left = leftCustomThingComboBox.Right + space;
			leftMediaComboBox.Width = leftComboBoxWidth;
			leftMediaComboBox.DropDownWidth = dropDownWidth;

			int rightComboBoxWidth = (rightPanel.Width - space) / 2;
			rightCustomThingComboBox.Width = rightComboBoxWidth;
			rightCustomThingComboBox.DropDownWidth = dropDownWidth;
			rightMediaComboBox.Left = rightCustomThingComboBox.Right + space;
			rightMediaComboBox.Width = rightComboBoxWidth;
			rightMediaComboBox.DropDownWidth = dropDownWidth;
		}

		private void Flip(PictureBox pictureBox)
		{
			Image image = pictureBox.Image;
			if (image != null)
			{
				image.RotateFlip(RotateFlipType.RotateNoneFlipX);

				pictureBox.Refresh();
			}
		}

		private void PlayRecording(ComboBox organismComboBox, ToolStripMenuItem menuItem, ref Audio audio)
		{
            // Make sure to stop sound if the Utility class was used to play sound
            Utility.StopSound();

            if (audio != null && !audio.Disposed && audio.State == StateFlags.Running)
			{
				StopAudio(audio, menuItem);
			}
			else
			{
                CustomThing customThing = organismComboBox.SelectedItem as CustomThing;

                if (customThing != null)
				{
                    IMedia media = customThing.Sounds[0];
					audio = new Audio(media.AbsolutePath);
					audio.Ending += new EventHandler(audio_Ending);
					audio.Play();
				}

				menuItem.Text = StopRecordingText;
			}
		}

		void audio_Ending(object sender, EventArgs e)
		{
			Audio audio = sender as Audio;
			if (audio != null && !audio.Disposed)
			{
				if (audio.State == StateFlags.Running)
				{
					audio.Stop();
				}

				if (audio == leftAudio)
				{
					playRecordingLeftToolStripMenuItem.Text = PlayRecordingText;
				}
				else if (audio == rightAudio)
				{
					playRecordingRightToolStripMenuItem.Text = PlayRecordingText;
				}
			}
		}

		private void StopAudio(Audio audio, ToolStripMenuItem menuItem)
		{
			StopAudio(audio);
			menuItem.Text = PlayRecordingText;
		}

		private void StopAudio(Audio audio)
		{
            // Make sure to stop sound if the Utility class was used to play sound
            Utility.StopSound();

			if (audio != null && !audio.Disposed)
			{
				audio.Stop();
				audio.Dispose();
				audio = null;
			}
		}

		private void playRecordingLeftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording(leftCustomThingComboBox, playRecordingLeftToolStripMenuItem, ref leftAudio);
		}

		private void flipLeftToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Flip(leftPictureBox);
		}

		private void playRecordingRightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PlayRecording(rightCustomThingComboBox, playRecordingRightToolStripMenuItem, ref rightAudio);
		}

		private void flipRightToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Flip(rightPictureBox);
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                LoadQuizzes();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void quizComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                LoadCustomThings();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void LoadCategories()
        {
            categories = new List<CustomQuizCategory>();

            CustomQuizCategory allCategory = new CustomQuizCategory();
            allCategory.ID = -1;
            allCategory.Name = "<All>";
            categories.Add(allCategory);
            categories.AddRange(CustomQuizCategory.GetList());

            categoryComboBox.DataSource = categories;
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.SelectedIndex = 0;
        }

        private void LoadQuizzes()
        {
            CustomQuizCategory selectedCategory = categoryComboBox.SelectedItem as CustomQuizCategory;
            if (selectedCategory != null)
            {
                List<CustomQuiz> quizzes = new List<CustomQuiz>();

				if (selectedCategory.ID == -1)
                {
                    foreach (CustomQuizCategory category in categories)
                    {
                        quizzes.AddRange(CustomQuiz.GetList(category.ID));
                    }
                }
                else
                {
                    quizzes.AddRange(CustomQuiz.GetList(selectedCategory.ID));
                }

                quizzes.Sort(new CustomQuizComparer());

                CustomQuiz allQuiz = new CustomQuiz();
                allQuiz.ID = -1;
                allQuiz.Name = "<All>";
                quizzes.Insert(0, allQuiz);

                quizComboBox.DataSource = quizzes;
                quizComboBox.DisplayMember = "Name";
                quizComboBox.SelectedIndex = 0;
            }
        }

        private void LoadCustomThings()
        {
            List<CustomThing> customThingsLeft = new List<CustomThing>();
            List<CustomThing> customThingsRight = new List<CustomThing>();

            CustomQuizCategory selectedCategory = categoryComboBox.SelectedItem as CustomQuizCategory;
            if (selectedCategory != null)
            {
                if (selectedCategory.ID == -1)
                {
                    CustomQuiz selectedQuiz = quizComboBox.SelectedItem as CustomQuiz;
                    if (selectedQuiz != null)
                    {
                        if (selectedQuiz.ID == -1)
                        {
                            // Load items for all categories
                            foreach (CustomQuizCategory category in categories)
                            {
                                customThingsLeft.AddRange(category.GetItems());
                                customThingsRight.AddRange(category.GetItems());
                            }
                        }
                        else
                        {
                            // Only load items for the selected quiz
                            customThingsLeft.AddRange(selectedQuiz.Entries);
                            customThingsRight.AddRange(selectedQuiz.Entries);
                        }
                    }
                }
                else
                {
                    foreach (CustomQuizCategory category in categories)
                    {
                        // Only load items for selected category
                        if (category.ID == selectedCategory.ID)
                        {
                            CustomQuiz selectedQuiz = quizComboBox.SelectedItem as CustomQuiz;
                            if (selectedQuiz != null)
                            {
                                if (selectedQuiz.ID == -1)
                                {
                                    // Load all items for the selected category
                                    customThingsLeft.AddRange(category.GetItems());
                                    customThingsRight.AddRange(category.GetItems());
                                }
                                else
                                {
                                    // Only load items for the selected quiz
                                    customThingsLeft.AddRange(selectedQuiz.Entries);
                                    customThingsRight.AddRange(selectedQuiz.Entries);
                                }
                            }
                        }
                    }
                }
            }

            leftCustomThingComboBox.DataSource = customThingsLeft;
            leftCustomThingComboBox.DisplayMember = "Name";
            if (customThingsLeft.Count == 0)
            {
                leftCustomThingComboBox.DataSource = null;
                leftMediaComboBox.Thing = null;
                leftPictureBox.Image = null;
            }

            rightCustomThingComboBox.DataSource = customThingsRight;
            rightCustomThingComboBox.DisplayMember = "Name";
            if (customThingsRight.Count == 0)
            {
                rightCustomThingComboBox.DataSource = null;
                rightMediaComboBox.Thing = null;
                rightPictureBox.Image = null;
            }
        }

        private class CustomQuizComparer : IComparer<CustomQuiz>
        {
            private SortOrder sortOrder = SortOrder.Ascending;

            public CustomQuizComparer()
            {
            }

            public CustomQuizComparer(SortOrder sortOrder)
            {
                this.sortOrder = sortOrder;
            }

            public int Compare(CustomQuiz x, CustomQuiz y)
            {
                int compareResult = compareResult = x.Name.CompareTo(y.Name);

                if (sortOrder == SortOrder.Descending)
                {
                    compareResult = -compareResult;
                }

                return compareResult;
            }
        }
    }
}
