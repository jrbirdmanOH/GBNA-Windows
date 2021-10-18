using System.Collections.Specialized;

namespace Thayer.Birding.UI
{
	internal class Utility
	{
		private Utility()
		{
		}

		public static NameValueCollection GetQueryNameValueCollection(string query)
		{
			if (query.Length == 0)
			{
				return new NameValueCollection();
			}

			// Remove the leading "?"
			string queryString = query.Remove(0, 1);
			string[] parameters = queryString.Split('&');

			NameValueCollection retVal = new NameValueCollection(parameters.Length);
			foreach (string param in parameters)
			{
				string[] nameValues = param.Split('=');
				retVal.Add(nameValues[0], nameValues[1]);
			}

			return retVal;
		}
	}
}
