using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizzesForm : BaseForm
	{
		public MyQuizzesForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadQuizzes();
		}

		private void MyQuizzesForm_Shown(object sender, EventArgs e)
		{
			if (UserSettings.Instance.ShowCustomQuizQuickStart)
			{
				ShowQuickStart();
			}
		}

		private void LoadQuizzes()
		{
			object previouslySelectedObject = null;
			TreeNode previouslySelectedNode = quizTreeView.SelectedNode;
			if (previouslySelectedNode != null)
			{
				previouslySelectedObject = previouslySelectedNode.Tag;
			}

			quizTreeView.BeginUpdate();
			quizTreeView.Nodes.Clear();

			List<CustomQuizCategory> categories = CustomQuizCategory.GetList();
			foreach (CustomQuizCategory category in categories)
			{
				TreeNode parent = quizTreeView.Nodes.Add(category.Name);
				parent.ImageIndex = 0;
				parent.SelectedImageIndex = 0;
				parent.Tag = category;

				List<CustomQuiz> quizzes = CustomQuiz.GetList(category.ID);
				foreach (CustomQuiz quiz in quizzes)
				{
					TreeNode node = parent.Nodes.Add(quiz.Name);
					node.ImageIndex = 1;
					node.SelectedImageIndex = 1;
					node.Tag = quiz;
				}
			}

			// Collapse all nodes
			quizTreeView.CollapseAll();

			SelectObject(previouslySelectedObject);

			// Make sure a node is always selected
			if (quizTreeView.SelectedNode == null && quizTreeView.Nodes.Count > 0)
			{
				quizTreeView.SelectedNode = quizTreeView.Nodes[0];
			}

			// Make sure selected node is visible
			if (quizTreeView.SelectedNode != null)
			{
				quizTreeView.TopNode = quizTreeView.SelectedNode;
			}

			quizTreeView.EndUpdate();

			UpdateMenuItems();
		}

		private void SelectObject(object selectedObject)
		{
			if (selectedObject is CustomQuizCategory)
			{
				SelectCategory(selectedObject as CustomQuizCategory);
			}
			else if (selectedObject is CustomQuiz)
			{
				SelectQuiz(selectedObject as CustomQuiz);
			}
		}

		private void SelectCategory(CustomQuizCategory category)
		{
			if (category != null)
			{
				foreach (TreeNode node in quizTreeView.Nodes)
				{
					CustomQuizCategory nodeCategory = node.Tag as CustomQuizCategory;
					if (nodeCategory != null)
					{
						if (nodeCategory.ID == category.ID)
						{
							quizTreeView.SelectedNode = node;
							return;
						}
					}
				}
			}
		}

		private void SelectQuiz(CustomQuiz quiz)
		{
			if (quiz != null)
			{
				foreach (TreeNode parentNode in quizTreeView.Nodes)
				{
					foreach (TreeNode node in parentNode.Nodes)
					{
						CustomQuiz nodeQuiz = node.Tag as CustomQuiz;
						if (nodeQuiz != null)
						{
							if (nodeQuiz.ID == quiz.ID)
							{
								quizTreeView.SelectedNode = node;
								return;
							}
						}
					}
				}
			}
		}

		private void newCategoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void newCategoryDropDownButtonMenuItem_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void newCategoryContextMenuItem_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void newCategoryToolStripContextMenuItem_Click(object sender, EventArgs e)
		{
			NewCategory();
		}

		private void NewCategory()
		{
			MyQuizNewCategoryForm form = new MyQuizNewCategoryForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadQuizzes();
				SelectCategory(form.Category);
				if (form.AddItems)
				{
					EditCategory();
				}
			}
		}

		private void EditCategory()
		{
			CustomQuizCategory category = quizTreeView.SelectedNode.Tag as CustomQuizCategory;
			if (category != null)
			{
				MyQuizEditCategoryForm form = new MyQuizEditCategoryForm(category);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadQuizzes();
				}
			}
		}

		private void DeleteCategory()
		{
			CustomQuizCategory category = quizTreeView.SelectedNode.Tag as CustomQuizCategory;
			if (category != null)
			{
				if (MessageBox.Show(this, "Are you sure you want to delete the category \"" + category.Name + "\"?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					category.Delete();
					LoadQuizzes();
				}
			}
		}

		private void newQuizToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewQuiz();
		}

		private void newQuizDropDownButtonMenuItem_Click(object sender, EventArgs e)
		{
			NewQuiz();
		}

		private void newQuizContextMenuItem_Click(object sender, EventArgs e)
		{
			NewQuiz();
		}

		private void NewQuiz()
		{
			MyQuizNewQuizForm form = new MyQuizNewQuizForm(GetSelectedCategory());
			if (form.ShowDialog() == DialogResult.OK)
			{
				LoadQuizzes();
				SelectQuiz(form.Quiz);
				if (form.AddQuestions)
				{
					EditQuiz();
				}
			}
		}

		private void EditQuiz()
		{
			CustomQuiz quiz = quizTreeView.SelectedNode.Tag as CustomQuiz;
			if (quiz != null)
			{
				MyQuizEditQuizForm form = new MyQuizEditQuizForm(quiz);
				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadQuizzes();
				}
				else
				{
					// May need to reload the quizzes even if user
					// cancelled because categories may have changed
					LoadQuizzes();
				}
			}
		}

		private void DeleteQuiz()
		{
			CustomQuiz quiz = quizTreeView.SelectedNode.Tag as CustomQuiz;
			if (quiz != null)
			{
				if (MessageBox.Show(this, "Are you sure you want to delete the quiz \"" + quiz.Name + "\"?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					quiz.Delete();
					LoadQuizzes();
				}
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Edit();
		}

		private void editToolStripButton_Click(object sender, EventArgs e)
		{
			Edit();
		}

		private void editContextMenuItem_Click(object sender, EventArgs e)
		{
			Edit();
		}

		private void Edit()
		{
			TreeNode selectedNode = quizTreeView.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Tag is CustomQuizCategory)
				{
					EditCategory();
				}
				else if (selectedNode.Tag is CustomQuiz)
				{
					EditQuiz();
				}
			}
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void deleteContextMenuItem_Click(object sender, EventArgs e)
		{
			Delete();
		}

		private void Delete()
		{
			TreeNode selectedNode = quizTreeView.SelectedNode;
			if (selectedNode != null)
			{
				if (selectedNode.Tag is CustomQuizCategory)
				{
					DeleteCategory();
				}
				else if (selectedNode.Tag is CustomQuiz)
				{
					DeleteQuiz();
				}
			}
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private CustomQuizCategory GetSelectedCategory()
		{
			CustomQuizCategory category = null;

			TreeNode selectedNode = quizTreeView.SelectedNode;
			if (selectedNode != null)
			{
				category = selectedNode.Tag as CustomQuizCategory;
				if (category == null)
				{
					category = selectedNode.Parent.Tag as CustomQuizCategory;
				}
			}

			return category;
		}

		private void quizTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateMenuItems();
		}

		private void UpdateMenuItems()
		{
			bool enabled = true;

			CustomQuizCategory category = GetSelectedCategory();
			if (category == null)
			{
				enabled = false;
			}

			newQuizContextMenuItem.Enabled = enabled;
			newQuizDropDownButtonMenuItem.Enabled = enabled;
			newQuizToolStripMenuItem.Enabled = enabled;

			enabled = true;
			TreeNode selectedNode = quizTreeView.SelectedNode;
			if (selectedNode == null)
			{
				enabled = false;
			}

			editContextMenuItem.Enabled = enabled;
			editToolStripButton.Enabled = enabled;
			editToolStripMenuItem.Enabled = enabled;

			deleteContextMenuItem.Enabled = enabled;
			deleteToolStripButton.Enabled = enabled;
			deleteToolStripMenuItem.Enabled = enabled;
		}

		private void quickStartToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowQuickStart();
		}

		private void quickStartToolStripButton_Click(object sender, EventArgs e)
		{
			ShowQuickStart();
		}

		private void quickStartContextMenuItem_Click(object sender, EventArgs e)
		{
			ShowQuickStart();
		}

		private void ShowQuickStart()
		{
			List<MyQuizQuickStartForm> helpForms = Utility.GetOpenForms<MyQuizQuickStartForm>();
			if (helpForms.Count == 0)
			{
				MyQuizQuickStartForm form = new MyQuizQuickStartForm();
				form.Show(this.Parent);
			}
			else
			{
				helpForms[0].Activate();
			}
		}

		private void quizTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				quizTreeView.SelectedNode = e.Node;
			}
		}

		private void importMyMediaPackageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ImportMyMediaPackage();
		}

		private void importMyMediaPackageToolStripButton_Click(object sender, EventArgs e)
		{
			ImportMyMediaPackage();
		}

		private void importMyMediaPackageContextMenuItem_Click(object sender, EventArgs e)
		{
			ImportMyMediaPackage();
		}

		private void ImportMyMediaPackage()
		{
			if (Utility.ImportMyMediaPackage())
			{
				// Make sure any changes due to the import are updated
				LoadQuizzes();
			}
		}

        private void compareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCompare();
        }

        private void viewCompareToolStripButton_Click(object sender, EventArgs e)
        {
            ShowCompare();
        }

        private void viewCompareContextMenuItem_Click(object sender, EventArgs e)
        {
            CustomQuizCategory selectedCategory = GetSelectedCategory();

            CustomQuiz selectedQuiz = null;
            TreeNode selectedNode = quizTreeView.SelectedNode;
            if (selectedNode != null)
            {
                if (selectedNode.Tag is CustomQuiz)
                {
                    selectedQuiz = selectedNode.Tag as CustomQuiz;
                }
            }

            ShowCompare(selectedCategory, selectedQuiz);
        }

        private void ShowCompare()
        {
            ShowCompare(null, null);
        }

        private void ShowCompare(CustomQuizCategory selectedCategory, CustomQuiz selectedQuiz)
        {
            CustomCompareForm form = new CustomCompareForm();

            if (selectedCategory != null)
            {
                form.InitialCategoryID = selectedCategory.ID;
            }

            if (selectedQuiz != null)
            {
                form.InitialCustomQuizID = selectedQuiz.ID;
            }

            form.ShowDialog(this);
        }
    }
}