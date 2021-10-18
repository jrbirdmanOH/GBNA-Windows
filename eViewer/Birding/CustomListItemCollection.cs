using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;

namespace Thayer.Birding
{
	public class CustomListItemCollection : IEnumerable<CustomListItem>, IBindingList
	{
		private List<CustomListItem> list;
		private event ListChangedEventHandler listChanged;

		public CustomListItemCollection()
		{
			list = new List<CustomListItem>();
		}

		public CustomListItemCollection(IEnumerable<CustomListItem> collection)
		{
			list = new List<CustomListItem>();

			int order = 0;
			foreach (CustomListItem item in collection)
			{
				item.Order = ++order;
				Add(item);
			}
		}

		public CustomListItemCollection(IEnumerable<CustomListItem> collection, int customListID)
		{
			list = new List<CustomListItem>();

			foreach (CustomListItem item in collection)
			{
				CustomListItem copyItem = new CustomListItem(item, customListID);
				Add(copyItem);
			}
		}

		public void Add(CustomListItem item)
		{
			list.Add(item);
			OnListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, list.Count - 1));
		}

		public bool CanAdd(int organismID)
		{
			bool canAdd = true;

			foreach (CustomListItem item in list)
			{
				if (item.Organism.ID == organismID)
				{
					canAdd = false;
					break;
				}
			}

			return canAdd;
		}

		public void Clear()
		{
			list.Clear();
			OnListChanged(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
		}

		public int Count
		{
			get
			{
				return list.Count;
			}
		}

		protected void OnListChanged(object sender, ListChangedEventArgs e)
		{
			if (listChanged != null)
			{
				listChanged(sender, e);
			}
		}

		public void Remove(CustomListItem item)
		{
			int index = list.IndexOf(item);
			RemoveAt(index);
		}

		public void RemoveAt(int index)
		{
			list.RemoveAt(index);
			OnListChanged(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
		}

		public void Insert(int index, CustomListItem item)
		{
			list.Insert(index, item);
			OnListChanged(this, new ListChangedEventArgs(ListChangedType.ItemAdded, index));
		}

		IEnumerator<CustomListItem> IEnumerable<CustomListItem>.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return list.GetEnumerator();
		}

		public CustomListItem this[int index]
		{
			get
			{
				return list[index];
			}
		}

		void IBindingList.AddIndex(PropertyDescriptor property)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		object IBindingList.AddNew()
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		bool IBindingList.AllowEdit
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		bool IBindingList.AllowNew
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		bool IBindingList.AllowRemove
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		int IBindingList.Find(PropertyDescriptor property, object key)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		bool IBindingList.IsSorted
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		public event ListChangedEventHandler ListChanged
		{
			add
			{
				listChanged += value;
			}

			remove
			{
				listChanged -= value;
			}
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void IBindingList.RemoveSort()
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		ListSortDirection IBindingList.SortDirection
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		PropertyDescriptor IBindingList.SortProperty
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		bool IBindingList.SupportsChangeNotification
		{
			get
			{
				return true;
			}
		}

		bool IBindingList.SupportsSearching
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		bool IBindingList.SupportsSorting
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		int IList.Add(object value)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void IList.Clear()
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		bool IList.Contains(object value)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		int IList.IndexOf(object value)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void IList.Insert(int index, object value)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		bool IList.IsFixedSize
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		bool IList.IsReadOnly
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		void IList.Remove(object value)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		void IList.RemoveAt(int index)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}

			set
			{
				throw new System.Exception("The method or operation is not implemented.");
			}
		}

		void ICollection.CopyTo(System.Array array, int index)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}

		bool ICollection.IsSynchronized
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}

		object ICollection.SyncRoot
		{
			get { throw new System.Exception("The method or operation is not implemented."); }
		}
	}
}
