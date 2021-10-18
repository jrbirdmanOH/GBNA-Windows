using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	partial class LocationTreeView : UserControl
	{
		private int collectionID = 0;

		public LocationTreeView()
		{
			InitializeComponent();
		}

		[DefaultValue(0)]
		public int CollectionID
		{
			get
			{
				return collectionID;
			}

			set
			{
				collectionID = value;

				if (!DesignMode)
				{
					LoadLocationTreeView();
				}
			}
		}

		public event TreeViewEventHandler AfterCheck
		{
			add
			{
				treeView.AfterCheck += value;
			}

			remove
			{
				treeView.AfterCheck -= value;
			}
		}

		public event EventHandler ExcludeRareBirdsCheckedChanged
		{
			add
			{
				excludeRareBirdsCheckBox.CheckedChanged += value;
			}

			remove
			{
				excludeRareBirdsCheckBox.CheckedChanged -= value;
			}
		}

		[DefaultValue(false)]
		public bool ExcludeRareBirds
		{
			get
			{
				return excludeRareBirdsCheckBox.Checked;
			}

			set
			{
				excludeRareBirdsCheckBox.Checked = value;
			}
		}

		private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			foreach (TreeNode node in e.Node.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					LoadLocationTreeView(node, true);
				}
			}
		}

		protected void LoadLocationTreeView()
		{
			treeView.BeginUpdate();

			treeView.Nodes.Clear();

			if (collectionID > 0)
			{
				Thayer.Birding.Location parent = Thayer.Birding.Location.GetParent();

				TreeNode parentNode = new TreeNode();
				parentNode.Text = parent.Name;
				parentNode.Tag = new LocationInfo(parent, collectionID);;
				parentNode.ImageIndex = 0;
				parentNode.SelectedImageIndex = parentNode.ImageIndex;
				treeView.Nodes.Add(parentNode);

				LoadLocationTreeView(parentNode, true);
			}

			treeView.EndUpdate();
		}

		protected void LoadLocationTreeView(TreeNode parentNode, bool addChildren)
		{
			LocationInfo parent = parentNode.Tag as LocationInfo;

			List<Thayer.Birding.Location> children = parent.Children;
			foreach (Thayer.Birding.Location location in children)
			{
				TreeNode node = new TreeNode();
				node.Text = location.Name;
				node.Tag = new LocationInfo(location, collectionID);
				node.ImageIndex = 1;
				node.SelectedImageIndex = node.ImageIndex;
				parentNode.Nodes.Add(node);

				if (addChildren)
				{
					LoadLocationTreeView(node, true);
//					if (oneChild)
//					{
						parentNode.Expand();
//					}
/*
					bool oneChild = children.Count == 1;
					LoadLocationTreeView(node, oneChild);
					if (oneChild)
					{
						parentNode.Expand();
					}
*/
				}
			}
		}

		public Location[] SelectedLocations
		{
			get
			{
				List<Location> locations = new List<Location>();

				GetSelectedLocations(locations, treeView.Nodes);

				return locations.ToArray();
			}

			set
			{
				List<int> locations = new List<int>();
				foreach (Location location in value)
				{
					locations.Add(location.ID);
				}

				SetSelectedLocations(locations, treeView.Nodes);
			}
		}

		protected void GetSelectedLocations(List<Location> locations, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
				{
					LocationInfo locationInfo = node.Tag as LocationInfo;
					locations.Add(locationInfo.Location);
				}

				if (node.Nodes.Count > 0)
				{
					GetSelectedLocations(locations, node.Nodes);
				}
			}
		}

		protected void SetSelectedLocations(List<int> locations, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				LocationInfo locationInfo = node.Tag as LocationInfo;
				if (locationInfo != null)
				{
					if (locations.Contains(locationInfo.Location.ID))
					{
						node.Checked = true;
						if (node.TreeView.SelectedNode == null)
						{
							node.TreeView.SelectedNode = node;
							node.EnsureVisible();
						}
					}
				}

				SetSelectedLocations(locations, node.Nodes);
			}
		}

		public void ClearChecks()
		{
			ClearChecks(treeView.Nodes);
		}

		private void ClearChecks(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				node.Checked = false;
				ClearChecks(node.Nodes);
			}
		}

		private class LocationInfo
		{
			private Location location = null;
			private int collectionID = 0;
			private List<Location> children = null;

			public LocationInfo(Location location, int collectionID)
			{
				this.location = location;
				this.collectionID = collectionID;
			}

			public Location Location
			{
				get
				{
					return location;
				}
			}

			public List<Location> Children
			{
				get
				{
					if (children == null)
					{
						children = location.GetChildren(collectionID);
					}

					return children;
				}
			}
		}
	}
}
