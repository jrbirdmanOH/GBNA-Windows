using System.Windows.Forms;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.UI.Windows.Licensing
{
	public class ProductSelector : IProductSelector
	{
		#region IProductSelector Members
		public Product SelectProduct()
		{
			Product selectedProduct = null;

			ProductSelectionForm form = new ProductSelectionForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				selectedProduct = form.SelectedProduct;
			}

			return selectedProduct;
		}
		#endregion
	}
}
