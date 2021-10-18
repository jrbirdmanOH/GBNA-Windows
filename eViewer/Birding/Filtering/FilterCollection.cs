using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Thayer.Birding.Filtering
{
	public class FilterCollection : List<IFilter>, IXmlSerializable
	{
		public enum FilterTypes
		{
			None,
			State,
			Province,
			Region,
			Family,
			CustomList
		}

		FilterTypes filterType = FilterTypes.None;
		bool commonOnly = true;

		public FilterCollection()
		{
		}

		public FilterTypes FilterType
		{
			get
			{
				return filterType;
			}

			set
			{
				filterType = value;
			}
		}

		public bool CommonOnly
		{
			get
			{
				return commonOnly;
			}

			set
			{
				commonOnly = value;
			}
		}

		public string Name
		{
			get
			{
				StringBuilder name = new StringBuilder();

				if (this.Count == 1)
				{
					name.Append(this[0].Name);
				}
				else if (this.Count > 1)
				{
					switch (filterType)
					{
						case FilterTypes.State:
							name.Append("Multiple States");
							break;
						case FilterTypes.Province:
							name.Append("Multiple Provinces");
							break;
						case FilterTypes.Region:
							name.Append("Multiple Regions");
							break;
						case FilterTypes.Family:
							name.Append("Multiple Families");
							break;
					}
				}

				if (this.Count > 0)
				{
					if (filterType == FilterTypes.State || filterType == FilterTypes.Province || filterType == FilterTypes.Region)
					{
						if (commonOnly)
						{
							name.Append(" [Common birds only]");
						}
						else
						{
							name.Append(" [All birds]");
						}
					}
				}

				return name.ToString();
			}
		}

		public string Query
		{
			get
			{
				return GetQuery();
			}
		}

		protected string GetQuery()
		{
			string query = string.Empty;

			if (this.Count > 0)
			{
				List<int> idList = new List<int>();
				foreach (IFilter filter in this)
				{
					idList.Add(filter.ID);
				}

				Type filterType = this[0].GetType();
				MethodInfo method = filterType.GetMethod("GetQuery", BindingFlags.Public | BindingFlags.Static);
				if (method != null)
				{
					int numParameters = method.GetParameters().Length;
					switch (numParameters)
					{
						case 1:
							query = method.Invoke(null, new object[] { idList }) as string;
							break;
						case 2:
							query = method.Invoke(null, new object[] { idList, this.CommonOnly }) as string;
							break;
					}
				}
			}

			return query;
		}

		public XmlSchema GetSchema()
		{
			// Need to have this method implemented to work on the Mac running under Mono
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			// Set defaults
			filterType = FilterTypes.None;
			this.Clear();

			string nodeName = reader.Name;
			if (nodeName == "FilterCollection")
			{
				string filterTypeString = reader.GetAttribute("FilterType");
				if (Enum.IsDefined(typeof(FilterTypes), filterTypeString))
				{
					filterType = (FilterTypes)Enum.Parse(typeof(FilterTypes), filterTypeString);
				}
				else
				{
					filterType = FilterTypes.None;
				}

				commonOnly = Convert.ToBoolean(reader.GetAttribute("CommonOnly"));

				reader.ReadStartElement();
				while (reader.IsStartElement())
				{
					nodeName = reader.Name;

					if (nodeName == "Filter")
					{
						reader.ReadToDescendant("ID");
						reader.ReadStartElement();
						int filterID = reader.ReadContentAsInt();
						reader.ReadEndElement();

						reader.ReadStartElement();
						string filterName = reader.ReadString();
						reader.ReadEndElement();

						reader.ReadStartElement();
						string filterDisplayName = reader.ReadString();
						reader.ReadEndElement();

						IFilter filter = null;
						switch (filterType)
						{
							case FilterTypes.CustomList:
								filter = new CustomListFilter(filterID, filterName, filterDisplayName);
								break;
							case FilterTypes.Family:
								filter = new FamilyFilter(filterID, filterName);
								break;
							case FilterTypes.None:
								break;
							case FilterTypes.Province:
								filter = new StateFilter(filterID, filterName);
								break;
							case FilterTypes.Region:
								filter = new RegionFilter(filterID, filterName);
								break;
							case FilterTypes.State:
								filter = new StateFilter(filterID, filterName);
								break;
							default:
								throw new Exception("Unknown filter type.");
						}

						if (filter != null)
						{
							this.Add(filter);
						}

						reader.ReadEndElement();
					}
				}
				reader.ReadEndElement();
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartAttribute("FilterType");
			writer.WriteString(this.FilterType.ToString());
			writer.WriteEndAttribute();

			writer.WriteStartAttribute("CommonOnly");
			writer.WriteString(this.CommonOnly.ToString());
			writer.WriteEndAttribute();

			foreach (IFilter filter in this)
			{
				writer.WriteStartElement("Filter");

				writer.WriteStartElement("ID");
				writer.WriteString(filter.ID.ToString());
				writer.WriteEndElement();

				writer.WriteStartElement("Name");
				writer.WriteString(filter.Name);
				writer.WriteEndElement();

				writer.WriteStartElement("DisplayName");
				writer.WriteString(filter.DisplayName);
				writer.WriteEndElement();

				writer.WriteEndElement();
			}
		}
	}
}
