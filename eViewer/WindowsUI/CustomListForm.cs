using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

using Infragistics.Win;
using Infragistics.Win.Printing;

using Thayer.Birding.UI.Windows.Quiz;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI.Windows
{
	public partial class CustomListForm : BaseForm
	{
		private Language language = null;
		private int currentCollectionID = 0;
		private Dictionary<int, List<OrganismListItem>> organisms = new Dictionary<int, List<OrganismListItem>>();
		private CustomListPrintDocument document = new CustomListPrintDocument();
		private IShowsBird showsBirdProvider = null;

		public CustomListForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		public Language Language
		{
			get
			{
				return language;
			}

			set
			{
				language = value;
			}
		}

		private int CurrentCollectionID
		{
			get
			{
				return currentCollectionID;
			}

			set
			{
				currentCollectionID = value;
			}
		}

		private CustomList SelectedCustomList
		{
			get
			{
				CustomList list = null;

				TreeNode node = customListsTreeView.SelectedNode;
				if (node != null)
				{
					list = node.Tag as CustomList;
				}

				return list;
			}
		}

		[Browsable(false)]
		public IShowsBird ShowsBirdProvider
		{
			get
			{
				return showsBirdProvider;
			}

			set
			{
				showsBirdProvider = value;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadTree();

			UserSettings.Instance.ShowAliasesChanged += new EventHandler<EventArgs>(UserSettings_ShowAliasesChanged);
			UserSettings.Instance.LanguageChanged += new EventHandler<LanguageChangedEventArgs>(UserSettings_LanguageChanged);
			UserSettings.Instance.DisplayNameChanged += new EventHandler<EventArgs>(UserSettings_DisplayNameChanged);

			ThayerLicenseManager.Instance.LicenseChanged += new EventHandler<LicenseChangedEventArgs>(ThayerLicenseManager_LicenseChanged);
		}

		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			UserSettings.Instance.ShowAliasesChanged -= UserSettings_ShowAliasesChanged;
			UserSettings.Instance.LanguageChanged -= UserSettings_LanguageChanged;
			UserSettings.Instance.DisplayNameChanged -= UserSettings_DisplayNameChanged;

			ThayerLicenseManager.Instance.LicenseChanged -= ThayerLicenseManager_LicenseChanged;
		}

		private void UserSettings_ShowAliasesChanged(object sender, EventArgs e)
		{
			organisms.Clear();
			RefreshOrganismList();
		}

		private void UserSettings_LanguageChanged(object sender, LanguageChangedEventArgs e)
		{
			this.Language = e.Language;
			organisms.Clear();
			RefreshOrganismList();
		}

		private void UserSettings_DisplayNameChanged(object sender, EventArgs e)
		{
			RefreshOrganismList();

			CustomList list = this.SelectedCustomList;
			if (list != null)
			{
				contentsListBox.BeginUpdate();
				contentsListBox.DataSource = null;
				contentsListBox.DataSource = list.Contents;
				contentsListBox.EndUpdate();
			}
		}

		private void ThayerLicenseManager_LicenseChanged(object sender, LicenseChangedEventArgs e)
		{
			LoadTree();
			organisms.Clear();
			RefreshOrganismList();
		}

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			NewCustomList();
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenCustomList();
		}

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DeleteCustomList();
		}

		private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
		{
			PrintPreview();
		}

		private void printToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				document.CustomList = list;

				PrintDialog dialog = new PrintDialog();
				dialog.UseEXDialog = true;
				dialog.AllowCurrentPage = true;
				dialog.AllowSomePages = true;
				dialog.Document = document;
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					document.Print();
				}
			}
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			NewCustomList();
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			OpenCustomList();
		}

		private void deleteToolStripButton_Click(object sender, EventArgs e)
		{
			DeleteCustomList();
		}

		private void printToolStripButton_Click(object sender, EventArgs e)
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				document.CustomList = list;
				document.Print();
			}
		}

		private void printPreviewToolStripButton_Click(object sender, EventArgs e)
		{
			PrintPreview();
		}

		private void alphabeticToolStripButton_Click(object sender, EventArgs e)
		{
			ReorderAlphabetic();
		}

		private void taxonomicToolStripButton_Click(object sender, EventArgs e)
		{
			ReorderTaxonomic();
		}

		private void customListsTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			CustomList list = e.Node.Tag as CustomList;

			int collectionID;
			if (list == null)
			{
				Collection collection = e.Node.Tag as Collection;
				collectionID = collection.ID;
			}
			else
			{
				collectionID = list.CollectionID;
			}

			if (collectionID != this.CurrentCollectionID)
			{
				this.CurrentCollectionID = collectionID;
				RefreshOrganismList();
			}

			bool customListSelected = list != null;
			if (customListSelected)
			{
				contentsListBox.DisplayMember = "ToString";
				contentsListBox.ValueMember = "ID";
				contentsListBox.DataSource = list.Contents;
			}
			else
			{
				contentsListBox.DataSource = null;
			}

			openToolStripMenuItem.Enabled = customListSelected;
			openToolStripButton.Enabled = customListSelected;
			deleteToolStripMenuItem.Enabled = customListSelected;
			deleteToolStripButton.Enabled = customListSelected;
			printPreviewToolStripMenuItem.Enabled = customListSelected;
			printPreviewToolStripButton.Enabled = customListSelected;
			printToolStripMenuItem.Enabled = customListSelected;
			printToolStripButton.Enabled = customListSelected;
			photoGalleryToolStripMenuItem.Enabled = customListSelected;
			alphabeticToolStripButton.Enabled = customListSelected;
			taxonomicToolStripButton.Enabled = customListSelected;
			photoGalleryToolStripMenuItem.Enabled = customListSelected;
			photoGalleryToolStripButton.Enabled = customListSelected;
			saveAsScreenSaverToolStripMenuItem.Enabled = customListSelected;
			portableDeviceToolStripMenuItem.Enabled = customListSelected;
			exportToolStripMenuItem.Enabled = customListSelected;
			takeQuizToolStripButton.Enabled = customListSelected;
			takeQuizToolStripMenuItem.Enabled = customListSelected;
			copyToolStripButton.Enabled = customListSelected;
			copyToolStripMenuItem.Enabled = customListSelected;

			// Update the status of the content buttons
			UpdateContentButtonStatus();
		}

		private void LoadOrganismList(int collectionID)
		{
			List<OrganismListItem> organismListItems = OrganismListItem.GetList(collectionID, Language.ID);
			organisms[collectionID] = organismListItems;

			organismComboBox.Organisms = organismListItems.ToArray();
		}

		private void RefreshOrganismList()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			int collectionID;
			if (list == null)
			{
				Collection collection = customListsTreeView.SelectedNode.Tag as Collection;
				collectionID = collection.ID;
			}
			else
			{
				collectionID = list.CollectionID;
			}

			List<OrganismListItem> organismListItems;
			organisms.TryGetValue(collectionID, out organismListItems);
			if (organismListItems == null)
			{
				LoadOrganismList(collectionID);
			}
			else
			{
				organismComboBox.Organisms = organismListItems.ToArray();
			}
		}

		private void customListsTreeView_DoubleClick(object sender, EventArgs e)
		{
			OpenCustomList();
		}

		private void LoadTree()
		{
			contentsListBox.DataSource = null;

			customListsTreeView.BeginUpdate();
			customListsTreeView.Nodes.Clear();

			List<Collection> collections = Collection.GetList();
			foreach (Collection collection in collections)
			{
				TreeNode parent = customListsTreeView.Nodes.Add(collection.Name);
				parent.ImageIndex = 0;
				parent.SelectedImageIndex = 0;
				parent.Tag = collection;

				List<CustomList> customLists = CustomList.GetList(collection.ID, true);
				foreach (CustomList customList in customLists)
				{
					TreeNode node = parent.Nodes.Add(GenerateNodeText(customList));
					node.ImageIndex = 1;
					node.SelectedImageIndex = 1;
					node.Tag = customList;
					customList.ContentsChanged += new ListChangedEventHandler(customList_ContentsChanged);
				}

				parent.Expand();
			}

			// Make sure a node is always selected
			if (customListsTreeView.Nodes.Count > 0)
			{
				customListsTreeView.SelectedNode = customListsTreeView.Nodes[0];
			}

			customListsTreeView.EndUpdate();
		}

		private void customList_ContentsChanged(object sender, ListChangedEventArgs e)
		{
			CustomList list = sender as CustomList;

			switch(e.ListChangedType)
			{
				case ListChangedType.ItemAdded:
				case ListChangedType.ItemChanged:
				case ListChangedType.ItemDeleted:
					RenameTreeNode(list, customListsTreeView.Nodes);
					break;
			}

			// Update the status of the content buttons
			UpdateContentButtonStatus();
		}

		private bool RenameTreeNode(CustomList customList, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Tag == customList)
				{
					node.Text = GenerateNodeText(customList);
					return true;
				}
				else
				{
					if (RenameTreeNode(customList, node.Nodes))
					{
						return true;
					}
				}
			}

			return false;
		}

		private void NewCustomList()
		{
			TreeNode selectedNode = customListsTreeView.SelectedNode;
			Collection collection = selectedNode.Tag as Collection;
			if (collection == null)
			{
				collection = selectedNode.Parent.Tag as Collection;
			}

			if (collection != null)
			{
				CustomListEditForm form = new CustomListEditForm();
				CustomList list = new CustomList();
				list.CollectionID = collection.ID;
				form.CustomList = list;

				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadTree();

					foreach (TreeNode node in customListsTreeView.Nodes)
					{
						if (node.Name == list.Name)
						{
							customListsTreeView.SelectedNode = node;
							break;
						}
						else
						{
							SelectCustomList(list.ID);
						}
					}
				}
			}
		}

		private void SelectCustomList(int customListID)
		{
			SelectCustomList(customListsTreeView.Nodes, customListID);
		}

		private bool SelectCustomList(TreeNodeCollection nodes, int customListID)
		{
			bool didSelect = false;

			foreach (TreeNode node in nodes)
			{
				CustomList customList = node.Tag as CustomList;
				if (customList != null)
				{
					if (customList.ID == customListID)
					{
						customListsTreeView.SelectedNode = node;
						didSelect = true;
						break;
					}
				}
				else
				{
					if (SelectCustomList(node.Nodes, customListID))
					{
						didSelect = true;
						break;
					}
				}
			}

			return didSelect;
		}

		private void OpenCustomList()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				CustomListEditForm form = new CustomListEditForm();
				form.CustomList = list;

				if (form.ShowDialog() == DialogResult.OK)
				{
					LoadTree();
				}
			}
		}

		private void DeleteCustomList()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				StringBuilder text = new StringBuilder("'");
				text.Append(list.Name);
				text.Append("' will be deleted permanently.");

				if (MessageBox.Show(this, text.ToString(), Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
				{
					list.Delete();
					LoadTree();
				}
			}
		}

		private void ReorderAlphabetic()
		{
			TreeNode node = customListsTreeView.SelectedNode;
			if (node != null)
			{
				CustomList list = node.Tag as CustomList;

				if (list != null)
				{
					Cursor = Cursors.WaitCursor;
					try
					{
						list.ReorderAlphabetically();
						list.SaveContents(false);

						contentsListBox.DataSource = list.Contents;
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void ReorderTaxonomic()
		{
			TreeNode node = customListsTreeView.SelectedNode;
			if (node != null)
			{
				CustomList list = node.Tag as CustomList;

				if (list != null)
				{
					Cursor = Cursors.WaitCursor;
					try
					{
						list.ReorderTaxonomically();
						list.SaveContents(false);

						contentsListBox.DataSource = list.Contents;
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void PageSetup()
		{
			PageSetupDialog dialog = new PageSetupDialog();
			dialog.Document = document;
			dialog.ShowDialog();
		}

		private void PrintPreview()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				document.CustomList = list;

				UltraPrintPreviewDialog dialog = new UltraPrintPreviewDialog();
				dialog.PrintPreviewControl.Document = document;
				dialog.ShowDialog(this);
			}
		}

		private string GenerateNodeText(CustomList customList)
		{
			StringBuilder text = new StringBuilder(customList.Name);
			text.Append(", Author: ");
			text.Append(customList.Author);
			text.Append(" (");
			text.Append(customList.Length);
			text.Append(")");

			return text.ToString();
		}

		private class CustomListPrintDocument : UltraPrintDocument
		{
			private CustomList customList;
			private int currentIndex;

			public CustomListPrintDocument()
			{
			}

			public CustomList CustomList
			{
				get
				{
					return customList;
				}

				set
				{
					customList = value;
				}
			}

			protected override void OnBeginPrint(PrintEventArgs e)
			{
				base.OnBeginPrint(e);

				currentIndex = 0;
				DocumentName = "Thayer Birding Software - Custom List - " + customList.Name;

				Header.TextLeft = "Custom List - " + customList.Name;
				Header.TextRight = "Page [Page #]";

				PageBody.BorderStyle = UIElementBorderStyle.Solid;

				StringBuilder productAndVersion = new StringBuilder(Application.ProductName);
				productAndVersion.Append(" v");
				productAndVersion.Append(Application.ProductVersion);
				productAndVersion.Append(", Thayer Birding Software");

				Footer.TextLeft = "[Date Printed]";
				Footer.TextCenter = productAndVersion.ToString();
				Footer.TextRight = "www.thayerbirding.com";
			}

			protected override void OnPageBodyPrinting(PageBodyPrintingEventArgs e)
			{
				base.OnPageBodyPrinting(e);

				Graphics g = e.Graphics;

				float leftMargin = e.RectInsideBorders.Left;
				float topMargin = e.RectInsideBorders.Top;
				float bodyHeight = topMargin + e.RectInsideBorders.Height;
				float y = topMargin;
				Font bodyFont = null;
				Brush bodyBrush = null;
				try
				{
					bodyFont = new Font(Control.DefaultFont, FontStyle.Regular);
					bodyBrush = new SolidBrush(System.Drawing.Color.Black);
					float bodyLineSpacing = bodyFont.GetHeight(g) + 1;

					if (PageNumber == 1)
					{
						g.DrawString(customList.Name, bodyFont, bodyBrush, leftMargin, y);
						y += bodyLineSpacing;
						g.DrawString("Author: " + customList.Author, bodyFont, bodyBrush, leftMargin, y);
						y += bodyLineSpacing;
						g.DrawString("Length: " + customList.Contents.Count, bodyFont, bodyBrush, leftMargin, y);
						y += bodyLineSpacing * 2;

						g.DrawString("Contents: ", bodyFont, bodyBrush, leftMargin, y);
						y += bodyLineSpacing;
					}

					while (y + bodyLineSpacing < bodyHeight && currentIndex < customList.Contents.Count)
					{
						CustomListItem item = customList.Contents[currentIndex];

						StringBuilder text = new StringBuilder(item.Organism.CommonName);
						text.Append(" (");
						text.Append(item.Organism.ScientificName);
						text.Append(")");

						g.DrawString(text.ToString(), bodyFont, bodyBrush, leftMargin, y);
						y += bodyLineSpacing;
						currentIndex++;
					}
				}
				finally
				{
					if (bodyBrush != null)
					{
						bodyBrush.Dispose();
					}

					if (bodyFont != null)
					{
						bodyFont.Dispose();
					}
				}
			}

			protected override void OnPagePrinted(PagePrintedEventArgs e)
			{
				base.OnPagePrinted(e);

				e.HasMorePages = currentIndex < customList.Contents.Count;
			}
		}

		private void saveAsScreenSaverToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ScreenSaverForm form = new ScreenSaverForm();
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				Application.DoEvents();

				Cursor = Cursors.WaitCursor;

				try
				{
					CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

					if (list != null)
					{
						// Store the configuration file on a per user basis
						StringBuilder configFileDirectory = new StringBuilder(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
						configFileDirectory.Append(Path.DirectorySeparatorChar);
						configFileDirectory.Append("Thayer Birding Software");
						configFileDirectory.Append(Path.DirectorySeparatorChar);
						configFileDirectory.Append("Screen Saver");

						// Make sure the directory exists
						if (!Directory.Exists(configFileDirectory.ToString()))
						{
							Directory.CreateDirectory(configFileDirectory.ToString());
						}

						string configFileName = Path.Combine(configFileDirectory.ToString(), "ScreenSaver.config");
						using (StreamWriter writer = new StreamWriter(configFileName, false, Encoding.UTF8))
						{
							foreach (CustomListItem item in list.Contents)
							{
								Organism organism = item.FullOrganism;
								IMedia media;
								if (form.PhotographTypeSelected == ScreenSaverForm.PhotographType.Random)
								{
									int count = organism.Photos.Count;
									Random r = new Random();
									int index = r.Next(count - 1);
									media = organism.Photos[index];
								}
								else
								{
									media = organism.Photos[0];
								}

								writer.Write("Name=");
								writer.Write(organism.CommonName.Name);
								writer.Write("&Path=");
								writer.Write(media.AbsolutePath);
								writer.Write("&Width=");
								writer.Write(media.Width);
								writer.Write("&Height=");
								writer.Write(media.Height);
								writer.Write("&Caption=");
								writer.Write(media.Caption);
								writer.Write("&Copyright=");
								writer.Write(media.Copyright);

								if (organism.Sounds.Count > 0)
								{
									writer.Write("&Soundfile=");
									writer.Write(organism.Sounds[0].AbsolutePath);
								}
								writer.WriteLine();
							}
						}
					}
				}
				finally
				{
					Cursor = Cursors.Default;
				}
			}
		}

		private void organismComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Update the status of the content buttons
			UpdateContentButtonStatus();
		}

		private void addContentButton_Click(object sender, EventArgs e)
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;
				OrganismListItem organism = organismComboBox.SelectedItem as OrganismListItem;

				if (organism != null && list != null)
				{
					int lastOrder;
					int itemCount = contentsListBox.Items.Count;
					if (itemCount > 0)
					{
						CustomListItem lastItem = contentsListBox.Items[itemCount - 1] as CustomListItem;
						lastOrder = lastItem.Order;
					}
					else
					{
						lastOrder = 0;
					}

					CustomListItem item = new CustomListItem();
					item.Organism = organism;
					item.CustomListID = list.ID;
					item.Order = lastOrder + 1;

					list.AddItemAndSave(item);

					// Select the newly added item
					contentsListBox.SelectedItem = item;

					// Update the status of the content buttons
					UpdateContentButtonStatus();
				}
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void UpdateContentButtonStatus()
		{
			bool canAdd = false;

			// Update status of add content button
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;
			OrganismListItem organism = organismComboBox.SelectedItem as OrganismListItem;
			if (list != null && organism != null)
			{
				canAdd = list.Contents.CanAdd(organism.ID);
			}
			addContentButton.Enabled = canAdd;

			// Update status of move up, move down, and remove content buttons
			int selectedIndex = contentsListBox.SelectedIndex;
			moveDownButton.Enabled = selectedIndex >= 0 && selectedIndex < contentsListBox.Items.Count - 1;
			moveUpButton.Enabled = selectedIndex > 0;
			removeContentButton.Enabled = selectedIndex != -1;

			// Update status of copy to clipboard button and menus
			bool isListSelected = list != null;
			copyToClipboardToolStripButton.Enabled = isListSelected;
			copyToClipboardToolStripMenuItem.Enabled = isListSelected;
			copyToClipboardContextMenuToolStripMenuItem.Enabled = isListSelected;
		}

		private void photoGalleryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowPhotoGallery();
		}

		private void ShowPhotoGallery()
		{
			Cursor = Cursors.WaitCursor;

			try
			{
				List<Organism> organisms = new List<Organism>();

				CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;
				CustomListItemCollection contents = list.Contents;
				int[] organismIDs = new int[contents.Count];
				for (int i = 0; i < organismIDs.Length; i++)
				{
					organismIDs[i] = contents[i].Organism.ID;
				}

				// Get the collection associated with the selected custom list
				TreeNode selectedNode = customListsTreeView.SelectedNode;
				Collection collection = selectedNode.Tag as Collection;
				if (collection == null)
				{
					collection = selectedNode.Parent.Tag as Collection;
				}

				PhotoGalleryForm form = new PhotoGalleryForm();
				form.OrganismIDs = organismIDs;
				form.WindowState = FormWindowState.Maximized;
				form.Collection = collection;
				form.ShowsBirdProvider = this.ShowsBirdProvider;
				form.Show();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		private void photoGalleryToolStripButton_Click(object sender, EventArgs e)
		{
			ShowPhotoGallery();
		}

		private void removeContentButton_Click(object sender, EventArgs e)
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if(list != null)
			{
				CustomListItem item = contentsListBox.SelectedItem as CustomListItem;

				// Get the existing top index so it can be restored
				// later to keep the list box from scrolling
				int topIndex = contentsListBox.TopIndex;

				list.RemoveItemAndSave(item);

				// Restore the top index to keep list box from scrolling
				contentsListBox.TopIndex = topIndex;

				// Update the status of the content buttons
				UpdateContentButtonStatus();
			}
		}

		private void portableDeviceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.DoEvents();

			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				Cursor = Cursors.WaitCursor;
				PortableDeviceForm form = new PortableDeviceForm();
				try
				{
					// Setting the list can be a lengthy process if the list is long
					form.CustomList = list;
				}
				finally
				{
					Cursor = Cursors.Default;
				}

				if (form.ShowDialog(this) == DialogResult.OK)
				{
					Application.DoEvents();

					Cursor = Cursors.WaitCursor;
					try
					{
//						list.PrepareForPortableDevice(Language.English.ID, form.Path, form.FileNameDisplay);
                        list.PrepareForPortableDevice(Language.ID, form.Path, form.FileNameDisplay);
                    }
					catch (UnauthorizedAccessException uaEx)
					{
						MessageBox.Show(this, uaEx.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					catch (Exception ex)
					{
						MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void importToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "XML Document (*.xml)|*.xml";
			dialog.RestoreDirectory = true;
			if (dialog.ShowDialog(this) == DialogResult.OK)
			{
				CustomList.Import(this.CurrentCollectionID, dialog.FileName);
				LoadTree();
			}
		}

		private void exportToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				SaveFileDialog dialog = new SaveFileDialog();
				dialog.FileName = list.Name + ".xml";
				dialog.Filter = "XML Document (*.xml)|*.xml";
				dialog.RestoreDirectory = true;
				if (dialog.ShowDialog(this) == DialogResult.OK)
				{
					string fileName = dialog.FileName;
					if (File.Exists(fileName))
					{
						if (MessageBox.Show(this, "The file " + fileName + " already exists.\n\nDo you want to replace the existing file?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
						{
							fileName = null;
						}
					}

					if (fileName != null)
					{
						list.Export(fileName);
					}
				}
			}
		}

		private void contentsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateContentButtonStatus();
		}

		private void moveUpButton_Click(object sender, EventArgs e)
		{
			MoveCustomListItem(-1);
		}

		private void moveDownButton_Click(object sender, EventArgs e)
		{
			MoveCustomListItem(1);
		}

		private void MoveCustomListItem(int moveAmount)
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				int selectedIndex = contentsListBox.SelectedIndex;

				if (selectedIndex != -1)
				{
					int newIndex = selectedIndex + moveAmount;

					CustomListItem item = list.Contents[selectedIndex];
					CustomListItem switchItem = list.Contents[newIndex];

					int oldOrder = item.Order;
					item.Order = switchItem.Order;
					switchItem.Order = oldOrder;

					// Get the existing top index so it can be restored
					// later to keep the list box from scrolling
					contentsListBox.BeginUpdate();
					int topIndex = contentsListBox.TopIndex;

					list.Contents.RemoveAt(selectedIndex);
					list.Contents.Insert(newIndex, item);

					// Restore the top index to keep list box from scrolling
					contentsListBox.TopIndex = topIndex;

					contentsListBox.SelectedIndex = newIndex;
					contentsListBox.EndUpdate();

					item.Save();
					switchItem.Save();
				}
			}
		}

		private void takeQuizToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RunQuiz();
		}

		private void takeQuizToolStripButton_Click(object sender, EventArgs e)
		{
			RunQuiz();
		}

		private void RunQuiz()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				TreeNode selectedNode = customListsTreeView.SelectedNode;
				Collection collection = selectedNode.Tag as Collection;
				if (collection == null)
				{
					collection = selectedNode.Parent.Tag as Collection;
				}

				if (collection != null)
				{
					QuizSettings quizSettings = UserSettings.Instance.QuizSettings;
					quizSettings.WizardStartupType = QuizSettings.WizardStartupTypes.CustomList;
					quizSettings.QuizSource.Type = QuizSource.QuizSourceTypes.CustomList;
					quizSettings.QuizSource.CustomList.CustomListID = list.ID;
					quizSettings.QuizLength = list.Length;
					QuizLauncher.Instance.RunQuizWizard(quizSettings, collection);
				}
			}
		}

		private void idWizardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowIDWizard();
		}

		private void idWizardToolStripButton_Click(object sender, EventArgs e)
		{
			ShowIDWizard();
		}

		private void ShowIDWizard()
		{
			Cursor = Cursors.WaitCursor;
			try
			{
				IdentificationForm form = new IdentificationForm();
				form.Collection = Collection.GetByID(this.CurrentCollectionID);
				form.ShowsBirdProvider = this.ShowsBirdProvider;
				form.Show();
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

		public static void RefreshForm()
		{
			// Refresh the custom lists for all open CustomListForm forms
			List<CustomListForm> openForms = Utility.GetOpenForms<CustomListForm>();
			foreach (CustomListForm form in openForms)
			{
				form.RefreshCustomLists();
			}
		}

		public void RefreshCustomLists()
		{
			LoadTree();
		}

		private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Help.ShowHelp(this, helpProvider.HelpNamespace, HelpNavigator.TopicId, helpProvider.GetHelpKeyword(this));
		}

		private void Copy()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				CustomListEditForm form = new CustomListEditForm();
				CustomList newList = new CustomList(list);
				newList.Name += " (Copy)";
				if (newList.Author.Equals("Thayer Birding Software"))
				{
					newList.Author = string.Empty;
				}
				form.CustomList = newList;

				if (form.ShowDialog() == DialogResult.OK)
				{
					Cursor = Cursors.WaitCursor;
					try
					{
						newList.Contents = new CustomListItemCollection(list.Contents, newList.ID);
						newList.SaveContents(false);

						LoadTree();

						foreach (TreeNode node in customListsTreeView.Nodes)
						{
							if (node.Name == newList.Name)
							{
								customListsTreeView.SelectedNode = node;
								break;
							}
							else
							{
								SelectCustomList(newList.ID);
							}
						}
					}
					finally
					{
						Cursor = Cursors.Default;
					}
				}
			}
		}

		private void CopyToClipboard()
		{
			CustomList list = customListsTreeView.SelectedNode.Tag as CustomList;

			if (list != null)
			{
				StringBuilder listContents = new StringBuilder();

				listContents.Append("Custom List: ");
				listContents.Append(list.Name);
				listContents.Append("\r\n");
				listContents.Append("Author: ");
				listContents.Append(list.Author);
				listContents.Append("\r\n");
				listContents.Append("Length: ");
				listContents.Append(list.Length.ToString());
				listContents.Append("\r\n");

				int nameLineLength = 13 + list.Name.Length;
				int authorLineLength = 8 + list.Author.Length;
				int separatorLineLength = nameLineLength > authorLineLength ? nameLineLength : authorLineLength;
				for (int i = 0; i < separatorLineLength; i++)
				{
					listContents.Append("=");
				}
				listContents.Append("\r\n");

				foreach (CustomListItem item in list.Contents)
				{
					listContents.Append(item.Organism.DisplayText);
					listContents.Append("\r\n");
				}

				Clipboard.SetText(listContents.ToString(), TextDataFormat.Text);
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Copy();
		}

		private void copyToolStripButton_Click(object sender, EventArgs e)
		{
			Copy();
		}

		private void copyToClipboardToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		private void copyToClipboardContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		private void copyToClipboardToolStripButton_Click(object sender, EventArgs e)
		{
			CopyToClipboard();
		}

		private void customListsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				customListsTreeView.SelectedNode = e.Node;
			}
		}
	}
}
