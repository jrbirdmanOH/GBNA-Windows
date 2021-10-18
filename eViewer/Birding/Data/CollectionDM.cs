using System.Collections.Generic;
using System.Data;
using System.Text;
using Thayer.Birding.Licensing;
using System.Collections.Specialized;

namespace Thayer.Birding.Data
{
	internal class CollectionDM
	{
		private const int SamplerCollectionID = 80;
		private static CollectionDM instance = new CollectionDM();

		private CollectionDM()
		{
		}

		public static CollectionDM Instance
		{
			get
			{
				return instance;
			}
		}

		private string ActiveCollectionClause
		{
			get
			{
				StringBuilder buffer = new StringBuilder();

				ThayerLicenseCollection licenses = ThayerLicenseManager.Instance.Licenses;
				if (licenses != null && licenses.Count > 0)
				{
					foreach (ThayerLicense license in licenses)
					{
						if (buffer.Length > 0)
						{
							buffer.Append(",");
						}
						buffer.Append(license.Product.Collection.ID);
					}
				}
				else
				{
					buffer.Append(Product.Default.Collection.ID);

					StringCollection messages = new StringCollection();
					messages.Add("CollectionDM.cs: ActiveCollectionClause");
					if (licenses == null)
					{
						messages.Add("ThayerLicenseCollection is null.");
					}
					else
					{
						messages.Add("ThayerLicenseCollection is empty.");
					}

					messages.Add("");
					messages.Add("License file contents");
					messages.Add("=====================");
					messages.Add(ThayerLicenseManager.Instance.LicenseFile.DecryptedString);
					Log.Write(messages);
				}

				StringBuilder clause = new StringBuilder("CollectionID IN (");
				clause.Append(buffer.ToString());
				clause.Append(")");

				return clause.ToString();
			}
		}

		public List<Collection> GetList()
		{
			List<Collection> list = new List<Collection>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CollectionID, Name, ShortName, TaxonomyID FROM Collections WHERE " + ActiveCollectionClause;
				cmd.CommandType = CommandType.Text;

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					Collection collection = new Collection();

					collection.ID = reader.GetInt32(0);
					collection.Name = reader.GetString(1);
					collection.ShortName = reader.GetString(2);
					collection.TaxonomyID = reader.GetInt32(3);

					list.Add(collection);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		public Collection GetByID(int id)
		{
			Collection collection = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CollectionID, Name, ShortName, TaxonomyID FROM Collections WHERE CollectionID=:id AND " + ActiveCollectionClause;
				cmd.CommandType = CommandType.Text;

				IDbDataParameter idParam = cmd.CreateParameter();
				idParam.ParameterName = ":id";
				idParam.Value = id;
				cmd.Parameters.Add(idParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					collection = new Collection();

					collection.ID = reader.GetInt32(0);
					collection.Name = reader.GetString(1);
					collection.ShortName = reader.GetString(2);
					collection.TaxonomyID = reader.GetInt32(3);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return collection;
		}

		public Collection GetByCode(string code)
		{
			Collection collection = null;

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT CollectionID, Name, ShortName, TaxonomyID FROM Collections WHERE ShortName=:ShortName";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter codeParam = cmd.CreateParameter();
				codeParam.ParameterName = ":ShortName";
				codeParam.Value = code;
				cmd.Parameters.Add(codeParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				if (reader.Read())
				{
					collection = new Collection();

					collection.ID = reader.GetInt32(0);
					collection.Name = reader.GetString(1);
					collection.ShortName = reader.GetString(2);
					collection.TaxonomyID = reader.GetInt32(3);
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return collection;
		}
	}
}
