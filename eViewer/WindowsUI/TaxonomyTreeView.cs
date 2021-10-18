using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	partial class TaxonomyTreeView : TreeView
	{
		private int taxonomyID = 0;

		public TaxonomyTreeView()
		{
			InitializeComponent();
		}

		[DefaultValue(0)]
		public int TaxonomyID
		{
			get
			{
				return taxonomyID;
			}

			set
			{
				taxonomyID = value;

				if (!DesignMode)
				{
					LoadTaxonomyTreeView();
				}
			}
		}

		protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
		{
			base.OnBeforeExpand(e);

			foreach (TreeNode node in e.Node.Nodes)
			{
				if (node.Nodes.Count == 0)
				{
					ITaxonomy taxonomy = node.Tag as ITaxonomy;
					LoadTaxonomyTreeView(node, taxonomy, true);
				}
			}
		}

		protected void LoadTaxonomyTreeView()
		{
			BeginUpdate();

			Nodes.Clear();

			if (taxonomyID > 0)
			{
				List<Kingdom> kingdoms = Kingdom.GetList(taxonomyID);

				foreach (ITaxonomy kingdom in kingdoms)
				{
					TreeNode node = new TreeNode();
					node.Text = kingdom.Caption;
					node.ImageIndex = 0;
					node.SelectedImageIndex = node.ImageIndex;
					node.Tag = kingdom;
					Nodes.Add(node);

					LoadTaxonomyTreeView(node, kingdom, true);
					node.Expand();
				}
			}

			EndUpdate();
		}

		private void LoadTaxonomyTreeView(TreeNode parentNode, ITaxonomy parent, bool addChildren)
		{
			List<ITaxonomy> children = parent.Children;
			if (children != null)
			{
				foreach (ITaxonomy child in children)
				{
					TreeNode node = new TreeNode();
					node.Text = child.Caption;
					node.ImageIndex = parentNode.ImageIndex + 1;
					node.SelectedImageIndex = node.ImageIndex;
					node.Tag = child;
					parentNode.Nodes.Add(node);

					if (addChildren)
					{
						bool oneChild = child.Children != null && child.Children.Count == 1;
						LoadTaxonomyTreeView(node, child, oneChild);
						if (oneChild)
						{
							node.Expand();
						}
					}
				}
			}
		}

		public ITaxonomy[] SelectedClassifications
		{
			get
			{
				List<ITaxonomy> classifications = new List<ITaxonomy>();

				GetSelectedClassifications(classifications, Nodes);

				return classifications.ToArray();
			}
		}

		protected void GetSelectedClassifications(List<ITaxonomy> classifications, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Checked)
				{
					ITaxonomy classification = node.Tag as ITaxonomy;
					classifications.Add(classification);
				}

				if (node.Nodes.Count > 0)
				{
					GetSelectedClassifications(classifications, node.Nodes);
				}
			}
		}

		public void ClearChecks()
		{
			ClearChecks(Nodes);
		}

		private void ClearChecks(TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				node.Checked = false;
				ClearChecks(node.Nodes);
			}
		}
	}
}
