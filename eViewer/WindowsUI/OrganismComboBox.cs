using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	class OrganismComboBox : ComboBox
	{
		private OrganismListItem[] organisms = null;

		public OrganismComboBox()
		{
			AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			AutoCompleteSource = AutoCompleteSource.CustomSource;
		}

		[DefaultValue(null)]
		public OrganismListItem[] Organisms
		{
			get
			{
				return organisms;
			}

			set
			{
				organisms = value;

				RefreshOrganismList();
			}
		}

		[DefaultValue(0)]
		public int SelectedOrganismID
		{
			get
			{
				OrganismListItem item = SelectedItem as OrganismListItem;
				if (item == null)
				{
					return 0;
				}

				return item.ID;
			}

			set
			{
				if (value <= 0)
				{
					SelectedIndex = -1;
				}
				else
				{
					for (int i = 0; i < Items.Count; i++)
					{
						OrganismListItem item = Items[i] as OrganismListItem;
						if (item.ID == value)
						{
							SelectedIndex = i;
							break;
						}
					}
				}
			}
		}

		protected void RefreshOrganismList()
		{
			FillOrganismComboBox(this, new List<OrganismListItem>(this.Organisms));
		}

		public static void FillOrganismComboBox(ComboBox organismComboBox, List<OrganismListItem> list)
		{
			OrganismListItem selectedItem = organismComboBox.SelectedItem as OrganismListItem;
			int selectedID;
			if (selectedItem != null)
			{
				selectedID = selectedItem.ID;
			}
			else
			{
				selectedID = -1;
			}

			int selectedIndex = -1;
			if (list != null)
			{
				AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
				Dictionary<string, string> autoCompleteMapping = new Dictionary<string, string>();
				SortList(list, selectedItem, autoCompleteSource, autoCompleteMapping);

				// Set the data source
				BindingManagerBase bindingManager = organismComboBox.BindingContext[list];
				bindingManager.SuspendBinding();
				organismComboBox.DataSource = list;
				organismComboBox.DisplayMember = "DisplayText";
				bindingManager.ResumeBinding();

				// Set auto complete information
				organismComboBox.AutoCompleteCustomSource = autoCompleteSource;
				organismComboBox.Tag = autoCompleteMapping;

				// Clear any existing selection
				organismComboBox.SelectedIndex = -1;

				// Find index of selected organism
				int index = 0;
				foreach (OrganismListItem value in list)
				{
					if (value.ID == selectedID && selectedIndex == -1)
					{
						selectedIndex = index;
					}

					index++;
				}

				// Restore selected organism
				organismComboBox.SelectedIndex = selectedIndex;
			}
		}
/*
		public static void FillOrganismComboBox(ComboBox organismComboBox, List<OrganismListItem> list)
		{
			// Can get rid of making the copy since Peter Thayer is going to
			// modify database so that each bird only has one band code.

			// Can also get rid of storing multiple band codes for each bird.

			List<OrganismListItem> listCopy = new List<OrganismListItem>(list);
			OrganismListItem selectedItem = organismComboBox.SelectedItem as OrganismListItem;
			int selectedID;
			if (selectedItem != null)
			{
				selectedID = selectedItem.ID;
			}
			else
			{
				selectedID = -1;
			}

			int selectedIndex = -1;
			if (listCopy != null)
			{
				// Process list for displaying band codes
				OrganismDisplayOptions displayName = UserSettings.Instance.DisplayName;
				if (displayName == OrganismDisplayOptions.BandCode)
				{
					List<OrganismListItem> bandCodeItems = new List<OrganismListItem>();
					foreach (OrganismListItem organism in listCopy)
					{
						if (organism.BandCodes.Count > 1)
						{
							int bandCodeIndex = 0;
							foreach (BandCode bandCode in organism.BandCodes)
							{
								if (bandCodeIndex > 0)
								{
									List<BandCode> bandCodes = new List<BandCode>();
									bandCodes.Add(bandCode);
									OrganismListItem bandCodeItem = organism.Clone() as OrganismListItem;
									bandCodeItem.BandCodes = bandCodes;
									bandCodeItems.Add(bandCodeItem);
								}
								bandCodeIndex++;
							}
						}
					}

					listCopy.AddRange(bandCodeItems);
				}

				AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
				Dictionary<string, string> autoCompleteMapping = new Dictionary<string, string>();
				SortList(listCopy, selectedItem, autoCompleteSource, autoCompleteMapping);

				// Set the data source
				BindingManagerBase bindingManager = organismComboBox.BindingContext[list];
				bindingManager.SuspendBinding();
				organismComboBox.DataSource = listCopy;
				organismComboBox.DisplayMember = "DisplayText";
				bindingManager.ResumeBinding();

				// Set auto complete information
				organismComboBox.AutoCompleteCustomSource = autoCompleteSource;
				organismComboBox.Tag = autoCompleteMapping;

				// Clear any existing selection
				organismComboBox.SelectedIndex = -1;

				// Find index of selected organism
				int index = 0;
				foreach (OrganismListItem value in listCopy)
				{
					if (value.ID == selectedID && selectedIndex == -1)
					{
						selectedIndex = index;
					}

					index++;
				}

				// Restore selected organism
				organismComboBox.SelectedIndex = selectedIndex;
			}
		}
*/
		private static void SortList(List<OrganismListItem> list, OrganismListItem selectedItem, AutoCompleteStringCollection autoCompleteSource, Dictionary<string, string> autoCompleteMapping)
		{
			int selectedItemID;
			if (selectedItem != null)
			{
				selectedItemID = selectedItem.ID;
			}
			else
			{
				selectedItemID = -1;
			}

//			SortedList<object, OrganismListItem> sortedList = new SortedList<object, OrganismListItem>();
//			OrganismSortOrder sortOrder = UserSettings.Instance.SortOrder;
			foreach (OrganismListItem organism in list)
			{
//				object key;
				string text = organism.ToString();
/*
				if (sortOrder == OrganismSortOrder.Alphabetic)
				{
					key = text;
				}
				else if (sortOrder == OrganismSortOrder.Taxonomic)
				{
					key = organism.TaxonomicOrder;
				}
				else
				{
					throw new ApplicationException("Unhandled sort order: " + sortOrder + ".");
				}
*/
				if (organism.ID == selectedItemID)
				{
					selectedItem = organism;
				}

//				if (!sortedList.ContainsKey(key))
//				{
////					text = text.Replace("-", " ");
//					sortedList.Add(key, organism);
					if (!autoCompleteMapping.ContainsKey(text))
					{
						string displayText = organism.DisplayText;

						autoCompleteSource.Add(text);
						autoCompleteMapping.Add(text, displayText);

						// Add alternate display text for enhanced auto complete functionality
						string alternateDisplayText = string.Empty;
						OrganismDisplayOptions displayName = UserSettings.Instance.DisplayName;
						if (displayName == OrganismDisplayOptions.CommonName)
						{
							alternateDisplayText = organism.ToString(OrganismDisplayOptions.CommonNameLastFirst);
						}
						else if (displayName == OrganismDisplayOptions.CommonNameLastFirst)
						{
							alternateDisplayText = organism.ToString(OrganismDisplayOptions.CommonName);
						}

						if (alternateDisplayText.Length > 0)
						{
							autoCompleteSource.Add(alternateDisplayText);
							autoCompleteMapping.Add(alternateDisplayText, displayText);
						}

						// Add support for auto completing on the other words in the first name
						string[] firstNameParts = organism.FirstName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
						if (firstNameParts.Length > 1)
						{
							for (int index = 1; index < firstNameParts.Length; index++)
							{
								StringBuilder firstNamePart = new StringBuilder(firstNameParts[index]);
								firstNamePart.AppendFormat(" [{0}]", text);
								autoCompleteSource.Add(firstNamePart.ToString());
								autoCompleteMapping.Add(firstNamePart.ToString(), displayText);
							}
						}

						// Add support for auto completing on the second part of the last name when it contains a hyphen
						if (organism.LastName.Contains("-"))
						{
							int lastNameHyphenIndex = organism.LastName.IndexOf('-');
							if (lastNameHyphenIndex < organism.LastName.Length - 1)
							{
								StringBuilder lastNameSecondPart = new StringBuilder(organism.LastName.Substring(lastNameHyphenIndex + 1));
								lastNameSecondPart.AppendFormat(" [{0}]", text);
								autoCompleteSource.Add(lastNameSecondPart.ToString());
								autoCompleteMapping.Add(lastNameSecondPart.ToString(), displayText);
							}
						}
					}
//				}
			}

			list.Sort();

//			list.Clear();
//			list.AddRange(sortedList.Values);
		}

		public static void KeyDownHandler(ComboBox organismComboBox, KeyEventArgs e)
		{
			// Force drop down to close
			organismComboBox.DroppedDown = false;

			if (e.KeyCode == Keys.Enter)
			{
				bool bFoundText = false;
				string text = organismComboBox.Text;
				AutoCompleteStringCollection collection = organismComboBox.AutoCompleteCustomSource;

				foreach (string autoCompleteString in collection)
				{
					// Perform a case insensitive search
					if (string.Compare(autoCompleteString, text, true) == 0)
					{
						text = autoCompleteString;
						bFoundText = true;
						break;
					}
				}
				
				if (bFoundText)
				{
					Dictionary<string, string> autoCompleteMapping = organismComboBox.Tag as Dictionary<string, string>;
					string displayText;
					if (autoCompleteMapping.TryGetValue(text, out displayText))
					{
						int index = organismComboBox.FindStringExact(displayText);
						if (index != -1)
						{
							organismComboBox.SelectedIndex = index;
							organismComboBox.Focus();
						}
					}
				}
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			KeyDownHandler(this, e);

			base.OnKeyDown(e);
		}
	}
}
