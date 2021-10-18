using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class Sighting : IXmlSerializable
	{
		private int id = 0;
		private IDString observer = new IDString();
		private IDString organism = new IDString();
		private IDString location = new IDString();
		private DateTime date = DateTime.Now;
		private string comments = string.Empty;
		private double taxonomicOrder = 0.0;

		public Sighting()
		{
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

		public IDString Observer
		{
			get
			{
				return observer;
			}
		}

		public IDString Organism
		{
			get
			{
				return organism;
			}
		}

		public IDString Location
		{
			get
			{
				return location;
			}
		}

		public DateTime Date
		{
			get
			{
				return date;
			}

			set
			{
				date = value;
			}
		}

		public string Comments
		{
			get
			{
				return comments;
			}

			set
			{
				comments = value;
			}
		}

		public double TaxonomicOrder
		{
			get
			{
				return taxonomicOrder;
			}

			set
			{
				taxonomicOrder = value;
			}
		}

		public bool Exists()
		{
			return SightingsDM.Instance.Exists(this);
		}

		public void Delete()
		{
			Delete(null);
		}

		public void Delete(IDbTransaction trans)
		{
			SightingsDM.Instance.Delete(id, trans);
		}

		public void Save()
		{
			Save(null);
		}

		public void Save(IDbTransaction trans)
		{
			SightingsDM.Instance.Save(this, trans);
		}

		public static List<Sighting> GetList()
		{
			return SightingsDM.Instance.GetList();
		}

		public static List<Sighting> GetList(int organismID)
		{
			return SightingsDM.Instance.GetList(organismID);
		}

		public static void DeleteList(List<Sighting> sightings)
		{
			SightingsDM.Instance.DeleteList(sightings);
		}

		public static void DeleteByObserver(int observerID, IDbTransaction trans)
		{
			SightingsDM.Instance.DeleteByObserver(observerID, trans);
		}

		public static bool WasObservedByObserver(int organismID, int observerID)
		{
			return SightingsDM.Instance.WasObservedByObserver(organismID, observerID);
		}

		#region IXmlSerializable Members

		XmlSchema IXmlSerializable.GetSchema()
		{
//			throw new Exception("The method or operation is not implemented.");

			// Need to have this method implemented to work on the Mac running under Mono
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			string nodeName;

			reader.ReadStartElement();
			while (reader.IsStartElement())
			{
				nodeName = reader.Name;

				if (nodeName == "ObserverID")
				{
					observer.ID = Convert.ToInt32(reader.ReadString());
				}
				else if (nodeName == "ThingID")
				{
					organism.ID = Convert.ToInt32(reader.ReadString());
				}
				else if (nodeName == "LocationID")
				{
					location.ID = Convert.ToInt32(reader.ReadString());
				}
				else if (nodeName == "Date")
				{
					date = Convert.ToDateTime(reader.ReadString());
				}
				else if (nodeName == "Comments")
				{
					comments = reader.ReadString();
				}
				else
				{
					if (!reader.IsEmptyElement)
					{
						reader.ReadStartElement();
					}
				}

				reader.Read();
			}
			reader.ReadEndElement();
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("ObserverID");
			writer.WriteString(observer.ID.ToString());
			writer.WriteEndElement();
			writer.WriteStartElement("ThingID");
			writer.WriteString(organism.ID.ToString());
			writer.WriteEndElement();
			writer.WriteStartElement("LocationID");
			writer.WriteString(location.ID.ToString());
			writer.WriteEndElement();
			writer.WriteStartElement("Date");
			// Format DateTime to the default serialization format
			writer.WriteString(date.ToString("s"));
			writer.WriteEndElement();
			writer.WriteStartElement("Comments");
			writer.WriteString(comments);
			writer.WriteEndElement();
		}

		#endregion
	}
}
