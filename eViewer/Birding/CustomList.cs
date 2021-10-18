using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Thayer.Birding.Data;

namespace Thayer.Birding
{
	public class CustomList : IXmlSerializable
	{
		public enum PortableDeviceNameDisplay
		{
			FirstLast,
			LastFirst
		}

		private int id = 0;
		private string name = string.Empty;
		private string author = string.Empty;
		private int length = 0;
		private int collectionID = 0;
		private DateTime dateCreated = DateTime.Now;
		private DateTime? dateModified = null;
		private CustomListItemCollection contents = null;
		private ListChangedEventHandler contentsChanged;

		public CustomList()
		{
		}

		public CustomList(CustomList list)
		{
			this.Name = list.Name;
			this.Author = list.Author;
			this.CollectionID = list.CollectionID;
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

		public string Name
		{
			get
			{
				return name;
			}

			set
			{
				name = value;
			}
		}

		public string Author
		{
			get
			{
				return author;
			}

			set
			{
				author = value;
			}
		}

		public int Length
		{
			get
			{
				return length;
			}

			set
			{
				length = value;
			}
		}

		public int CollectionID
		{
			get
			{
				return collectionID;
			}

			set
			{
				collectionID = value;
			}
		}

		public DateTime DateCreated
		{
			get
			{
				return dateCreated;
			}

			set
			{
				dateCreated = value;
			}
		}

		public DateTime? DateModified
		{
			get
			{
				return dateModified;
			}

			set
			{
				dateModified = value;
			}
		}

		public CustomListItemCollection Contents
		{
			get
			{
				if (contents == null)
				{
					Contents = CustomListsThingsDM.Instance.GetList(id);
				}

				return contents;
			}

			set
			{
				if (contents != null)
				{
					contents.ListChanged -= new ListChangedEventHandler(contents_ListChanged);
				}

				contents = value;
				length = contents.Count;
				contents.ListChanged += new ListChangedEventHandler(contents_ListChanged);
			}
		}

		public void Export(string fileName)
		{
			if (fileName != null)
			{
				using (FileStream stream = File.Open(fileName, FileMode.Create))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(CustomList));
					serializer.Serialize(stream, this);
				}
			}
		}

		public static CustomList Import(int collectionID, string fileName)
		{
			CustomList customList = null;

			using (FileStream stream = File.Open(fileName, FileMode.Open))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(CustomList));
				customList = (CustomList)serializer.Deserialize(stream);
			}

			// Set collection ID to the current collection of the user doing the import
			customList.CollectionID = collectionID;

			// Get list of organism ID's that belong to the current collection
			List<OrganismListItem> organisms = OrganismListItem.GetList(collectionID);
			List<int> organismIDs = new List<int>();
			foreach(OrganismListItem item in organisms)
			{
				organismIDs.Add(item.ID);
			}

			// Remove any items from the list that do not belong to the current collection
			for (int index = customList.Contents.Count - 1; index >= 0; index--)
			{
				CustomListItem item = customList.Contents[index];
				if (!organismIDs.Contains(item.Organism.ID))
				{
					customList.Contents.Remove(item);
				}
			}
			
			// Save the contents of the custom list
			customList.SaveContents(true);

			return customList;
		}

		public int GetCountWithSounds()
		{
			int count = 0;

			foreach (CustomListItem item in Contents)
			{
				if (Media.GetListByThingAndType(item.Organism.ID, MediaType.Sound).Count > 0)
				{
					count++;
				}
			}

			return count;
		}

		public void ReorderAlphabetically()
		{
			SortedList<IComparable, CustomListItem> sortedList = new SortedList<IComparable, CustomListItem>(new OrganismComparer());
			foreach (CustomListItem item in Contents)
			{
				sortedList.Add(item.Organism.DisplayText, item);
			}

			Contents = new CustomListItemCollection(sortedList.Values);
		}

		public void ReorderTaxonomically()
		{
			SortedList<IComparable, CustomListItem> sortedList = new SortedList<IComparable, CustomListItem>(new OrganismComparer());
			foreach (CustomListItem item in Contents)
			{
				sortedList.Add(item.Organism.TaxonomicOrder, item);
			}

			Contents = new CustomListItemCollection(sortedList.Values);
		}

		private void contents_ListChanged(object sender, ListChangedEventArgs e)
		{
			OnContentsChanged(sender, e);
		}

		protected virtual void OnContentsChanged(object sender, ListChangedEventArgs e)
		{
			length = contents.Count;
			if (contentsChanged != null)
			{
				contentsChanged(this, e);
			}
		}

		public void Delete()
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				Delete(trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void Delete(IDbTransaction trans)
		{
			CustomListsThingsDM.Instance.DeleteByCustomListID(id, trans);
			CustomListDM.Instance.Delete(id, trans);
		}

		public void Save()
		{
			CustomListDM.Instance.Save(this, null);
		}

		public void Save(IDbTransaction trans)
		{
			CustomListDM.Instance.Save(this, trans);
		}

		public void DeleteContents()
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				CustomListsThingsDM.Instance.DeleteByCustomListID(id, trans);

				if (contents != null)
				{
					contents.Clear();
				}

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void SaveContents()
		{
			SaveContents(false, null);
		}

		public void SaveContents(bool generateOrder)
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;

			bool failed = true;
			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				SaveContents(generateOrder, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void SaveContents(bool generateOrder, IDbTransaction trans)
		{
			int order = 0;
			CustomListDM.Instance.Save(this, trans);
			foreach (CustomListItem item in Contents)
			{
				item.CustomListID = id;
				if (generateOrder)
				{
					item.Order = order++;
				}
				CustomListsThingsDM.Instance.Save(item, trans);
			}
		}

		public void AddItemAndSave(CustomListItem item)
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				Contents.Add(item);
				CustomListDM.Instance.Save(this, trans);
				CustomListsThingsDM.Instance.Save(item, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public void RemoveItemAndSave(CustomListItem item)
		{
			IDbConnection conn = null;
			IDbTransaction trans = null;
			bool failed = true;

			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				Contents.Remove(item);
				CustomListDM.Instance.Save(this, trans);
				CustomListsThingsDM.Instance.Delete(item.ID, trans);

				failed = false;
			}
			finally
			{
				if (trans != null)
				{
					if (!failed)
					{
						trans.Commit();
					}
					else
					{
						trans.Rollback();
					}
				}

				if (conn != null)
				{
					conn.Close();
				}
			}
		}

		public static CustomList GetTemporaryList()
		{
			return CustomListDM.Instance.GetTemporaryList();
		}

		public static CustomList GetByID(int id)
		{
			return CustomListDM.Instance.GetByID(id);
		}

		public static List<CustomList> GetList()
		{
			return CustomListDM.Instance.GetList();
		}

		public static List<CustomList> GetList(int collectionID)
		{
			return GetList(collectionID, false);
		}

		public static List<CustomList> GetList(int collectionID, bool includeEmpty)
		{
			return CustomListDM.Instance.GetList(collectionID, includeEmpty);
		}

		public bool Exists()
		{
			return CustomListDM.Instance.Exists(this, null);
		}

		public event ListChangedEventHandler ContentsChanged
		{
			add
			{
				contentsChanged += value;
			}

			remove
			{
				contentsChanged -= value;
			}
		}

		public override string ToString()
		{
			StringBuilder text = new StringBuilder(Name);
			text.Append(" (");
			text.Append(Length);
			text.Append(")");

			return text.ToString();
		}

		public void PrepareForPortableDevice(int languageID, string directory, PortableDeviceNameDisplay nameDisplay)
		{
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			foreach (CustomListItem item in Contents)
			{
				Organism organism = item.FullOrganism;
				if (organism.Sounds.Count > 0)
				{
					CommonName commonName = organism.GetCommonName(languageID);

					IMedia media = organism.Sounds[0];
					string source = media.AbsolutePath;
					string destination = Path.Combine(directory, organism.Order.Description);
					if (!Directory.Exists(destination))
					{
						Directory.CreateDirectory(destination);
					}

					destination = Path.Combine(destination, organism.Family.Description);
					if (!Directory.Exists(destination))
					{
						Directory.CreateDirectory(destination);
					}

					StringBuilder fileName = new StringBuilder();
					if (nameDisplay == PortableDeviceNameDisplay.LastFirst)
					{
						fileName.Append(commonName.Last);
						fileName.Append(", ");
						fileName.Append(commonName.First);
					}
					else
					{
						fileName.Append(commonName.Name);
					}
					fileName.Append(".mp3");

					destination = Path.Combine(destination, fileName.ToString());

					File.Copy(source, destination);
				}
			}
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
			string nodeName = reader.Name;
			if (nodeName == "CustomList")
			{
				Contents = new CustomListItemCollection();

				reader.ReadStartElement();
				while (reader.IsStartElement())
				{
					nodeName = reader.Name;
					if (nodeName == "CustomListID")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "Name")
					{
						reader.ReadStartElement();
						name = reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "Author")
					{
						if (!reader.IsEmptyElement)
						{
							reader.ReadStartElement();
							author = reader.ReadString();
							reader.ReadEndElement();
						}
						else
						{
							reader.Read();
						}
					}
					else if (nodeName == "Length")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "CollectionID")
					{
						reader.ReadStartElement();
						collectionID = Convert.ToInt32(reader.ReadString());
						reader.ReadEndElement();
					}
					else if (nodeName == "DateCreated")
					{
						reader.ReadStartElement();
						dateCreated = Convert.ToDateTime(reader.ReadString());
						reader.ReadEndElement();
					}
					else if (nodeName == "DateModified")
					{
						if (!reader.IsEmptyElement)
						{
							reader.ReadStartElement();
							dateModified = Convert.ToDateTime(reader.ReadString());
							reader.ReadEndElement();
						}
						else
						{
							reader.Read();
						}
					}
					else if (nodeName == "Hide")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "TemporaryList")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "internal")
					{
						reader.ReadStartElement();
						reader.ReadString();
						reader.ReadEndElement();
					}
					else if (nodeName == "CustomListThing")
					{
						CustomListItem item = new CustomListItem();
						IXmlSerializable xmlSerializable = item as IXmlSerializable;
						xmlSerializable.ReadXml(reader);
						contents.Add(item);
					}
				}
				reader.ReadEndElement();
			}
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("Name");
			writer.WriteString(name);
			writer.WriteEndElement();
			writer.WriteStartElement("Author");
			writer.WriteString(author);
			writer.WriteEndElement();
			writer.WriteStartElement("CollectionID");
			writer.WriteString(collectionID.ToString());
			writer.WriteEndElement();
			writer.WriteStartElement("DateCreated");
			// Format DateTime to the default serialization format
			writer.WriteString(dateCreated.ToString("s"));
			writer.WriteEndElement();
			writer.WriteStartElement("DateModified");
			if (dateModified != null)
			{
				// Format DateTime to the default serialization format
				writer.WriteString(dateModified.Value.ToString("s"));
			}
			writer.WriteEndElement();
			foreach (IXmlSerializable item in Contents)
			{
				writer.WriteStartElement("CustomListThing");
				item.WriteXml(writer);
				writer.WriteEndElement();
			}
		}

		#endregion

		private class OrganismComparer : IComparer<IComparable>
		{
			public int Compare(IComparable x, IComparable y)
			{
				int retVal = x.CompareTo(y);

				if (retVal == 0)
				{
					retVal = 1;
				}

				return retVal;
			}
		}
	}
}
