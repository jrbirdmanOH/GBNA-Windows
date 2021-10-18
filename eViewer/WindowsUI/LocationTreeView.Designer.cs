namespace Thayer.Birding.UI.Windows
{
	partial class LocationTreeView
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationTreeView));
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.excludeRareBirdsCheckBox = new System.Windows.Forms.CheckBox();
			this.treeView = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "World.bmp");
			this.imageList.Images.SetKeyName(1, "Compass.bmp");
			// 
			// excludeRareBirdsCheckBox
			// 
			this.excludeRareBirdsCheckBox.AutoSize = true;
			this.excludeRareBirdsCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.excludeRareBirdsCheckBox.Location = new System.Drawing.Point(0, 246);
			this.excludeRareBirdsCheckBox.Name = "excludeRareBirdsCheckBox";
			this.excludeRareBirdsCheckBox.Size = new System.Drawing.Size(283, 17);
			this.excludeRareBirdsCheckBox.TabIndex = 1;
			this.excludeRareBirdsCheckBox.Text = "Exclude very rare, accidental and extinct birds";
			this.excludeRareBirdsCheckBox.UseVisualStyleBackColor = true;
			// 
			// treeView
			// 
			this.treeView.CheckBoxes = true;
			this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView.ImageIndex = 0;
			this.treeView.ImageList = this.imageList;
			this.treeView.Location = new System.Drawing.Point(0, 0);
			this.treeView.Name = "treeView";
			this.treeView.SelectedImageIndex = 0;
			this.treeView.Size = new System.Drawing.Size(283, 246);
			this.treeView.TabIndex = 2;
			this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
			// 
			// LocationTreeView
			// 
			this.Controls.Add(this.treeView);
			this.Controls.Add(this.excludeRareBirdsCheckBox);
			this.Name = "LocationTreeView";
			this.Size = new System.Drawing.Size(283, 263);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.CheckBox excludeRareBirdsCheckBox;
		private System.Windows.Forms.TreeView treeView;
	}
}
