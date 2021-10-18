using System.Runtime.InteropServices;
using System.Text;
using Thayer.Birding.Data;

namespace Thayer.Birding.Licensing
{
	public class License
	{
		[DllImport("License")]
		private static extern bool Validate(string szProductKey, StringBuilder szProductCode, int nProductMaxCount, StringBuilder szSerialNumber, int nSerialMaxCount);

		private const int ProductCodeLength = 7;
		private const int SerialNumberLength = 6;

		private string licenseKey = string.Empty;
		private string productCode = string.Empty;
		private Collection collection = null;

		private License(string licenseKey, string productCode, Collection collection)
		{
			this.licenseKey = licenseKey;
			this.productCode = productCode;
			this.collection = collection;
		}

		public static License Create(string licenseKey)
		{
			StringBuilder productCode = new StringBuilder(ProductCodeLength + 1);
			StringBuilder serialNumber = new StringBuilder(SerialNumberLength + 1);

			bool valid = Validate(licenseKey, productCode, productCode.Capacity, serialNumber, serialNumber.Capacity);

			if (!valid)
			{
				return null;
			}

			Collection collection = CollectionDM.Instance.GetByCode(productCode.ToString());

			return new License(licenseKey, productCode.ToString(), collection);
		}

		public static bool ValidateKey(string licenseKey, Product product)
		{
			bool isValid = false;

			StringBuilder productCode = new StringBuilder(ProductCodeLength + 1);
			StringBuilder serialNumber = new StringBuilder(SerialNumberLength + 1);

			isValid = Validate(licenseKey, productCode, productCode.Capacity, serialNumber, serialNumber.Capacity);
			product.Code = isValid ? productCode.ToString() : string.Empty;

			return isValid;
		}

		public static string GetProductCode(string licenseKey)
		{
			StringBuilder productCode = new StringBuilder(ProductCodeLength + 1);
			StringBuilder serialNumber = new StringBuilder(SerialNumberLength + 1);

			bool isValid = Validate(licenseKey, productCode, productCode.Capacity, serialNumber, serialNumber.Capacity);

			return isValid ? productCode.ToString() : string.Empty;
		}

		public string LicenseKey
		{
			get
			{
				return licenseKey;
			}
		}

		public string ProductCode
		{
			get
			{
				return productCode;
			}
		}

		public Collection Collection
		{
			get
			{
				return collection;
			}
		}
	}
}
