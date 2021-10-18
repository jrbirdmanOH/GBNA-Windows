using System;
using System.Windows.Forms;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI.Windows.Licensing
{
	public partial class ProductSelectionForm : Form
	{
		private Product selectedProduct = null;

		public ProductSelectionForm()
		{
			InitializeComponent();

			// Set common icon
			if (this.ShowIcon)
			{
				this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
			}
		}

		public Product SelectedProduct
		{
			get
			{
				return selectedProduct;
			}
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			okButton.Enabled = false;
			LoadProducts();
		}

		private void LoadProducts()
		{
			productComboBox.Items.AddRange(Product.RegionProductList.ToArray());
			productComboBox.Items.Add("");
			productComboBox.Items.AddRange(Product.StateProductList.ToArray());
			productComboBox.Items.Add("");
			productComboBox.Items.AddRange(Product.ProvinceProductList.ToArray());
		}

		private void productComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			Product selectedProduct = productComboBox.SelectedItem as Product;
			okButton.Enabled = selectedProduct != null;
		}

		private void okButton_Click(object sender, EventArgs e)
		{
			selectedProduct = productComboBox.SelectedItem as Product;
		}
	}
}