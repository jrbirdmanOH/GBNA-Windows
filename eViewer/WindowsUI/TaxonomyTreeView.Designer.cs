namespace Thayer.Birding.UI.Windows
{
	partial class TaxonomyTreeView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxonomyTreeView));
			this.taxonomyImageList = new System.Windows.Forms.ImageList(this.components);
			this.SuspendLayout();
			// 
			// taxonomyImageList
			// 
			this.taxonomyImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("taxonomyImageList.ImageStream")));
			this.taxonomyImageList.TransparentColor = System.Drawing.Color.Fuchsia;
			this.taxonomyImageList.Images.SetKeyName(0, "Kingdom.bmp");
			this.taxonomyImageList.Images.SetKeyName(1, "Phylum.bmp");
			this.taxonomyImageList.Images.SetKeyName(2, "Class.bmp");
			this.taxonomyImageList.Images.SetKeyName(3, "Order.bmp");
			this.taxonomyImageList.Images.SetKeyName(4, "Family.bmp");
			this.taxonomyImageList.Images.SetKeyName(5, "Genus.bmp");
			// 
			// TaxonomyTreeView
			// 
			this.CheckBoxes = true;
			this.ImageIndex = 0;
			this.ImageList = this.taxonomyImageList;
			this.LineColor = System.Drawing.Color.Black;
			this.SelectedImageIndex = 0;
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList taxonomyImageList;
	}
}
