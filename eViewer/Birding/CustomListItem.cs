using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class CustomListItem : IXmlSerializable
	{
		private int id = 0;
		private OrganismListItem organism = new OrganismListItem();
		private int customListID = 0;
		private int order = 0;
		private Organism fullOrganism = null;

		public CustomListItem()
		{
		}

		public CustomListItem(CustomListItem item, int customListID)
		{
			this.CustomListID = customListID;
			this.Order = item.Order;
			this.Organism = item.Organism;
		}

		public int ID
		{
			get
			{
				return id;
			}

			set
			{
				id = value;
			}
		}

		public OrganismListItem Organism
		{
			get
			{
				return organism;
			}

			set
			{
				organism = value;
			}
		}

		public Organism FullOrganism
		{
			get
			{
				if (fullOrganism == null || fullOrganism.ID != organism.ID)
				{
					fullOrganism = Thayer.Birding.Organism.GetByID(organism.ID);
				}

				return fullOrganism;
			}
		}

		public int CustomListID
		{
			get
			{
				return customListID;
			}

			set
			{
				customListID = value;
			}
		}

		public int Order
		{
			get
			{
				return order;
			}

			set
			{
				order = value;
			}
		}

		public override string ToString()
		{
			return organism.ToString();
		}

		public void Delete()
		{
			CustomListsThingsDM.Instance.Delete(id);
		}

		public void Save()
		{
			CustomListsThingsDM.Instance.Save(this, null);
		}

		#region IXmlSerializable Members

		XmlSchema IXmlSerializable.GetSchema()
		{
//			throw new System.Exception("The method or operation is not implemented.");

			// Need to have this method implemented to work on the Mac running under Mono
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			string nodeName = reader.Name;
			if (nodeName == "CustomListThing")
			{
				reader.ReadStartElement();
				while (reader.IsStartElement())
				{
					nodeName = reader.Name;
					if (nodeName == "ThingID")
					{
						reader.ReadStartElement();
						organism.ID = System.Convert.ToInt32(reader.ReadString());
						reader.ReadEndElement();
					}
					else if (nodeName == "order")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
				}
				reader.ReadEndElement();
			}
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("ThingID");
			writer.WriteString(organism.ID.ToString());
			writer.WriteEndElement();
		}

		#endregion
	}
}
