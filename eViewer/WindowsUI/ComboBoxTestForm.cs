using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
	public partial class ComboBoxTestForm : Form
	{
		private Infragistics.Win.UltraWinEditors.UltraComboEditor comboEditorToolbar = null;
		private OrganismListItem[] organisms = null;

		public ComboBoxTestForm()
		{
			InitializeComponent();
			comboEditorToolbar = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
			comboEditorToolbar.SelectionChangeCommitted += new EventHandler(comboEditorToolbar_SelectionChangeCommitted);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			comboEditorToolbar.Size = new System.Drawing.Size(200, 25);
			comboEditorToolbar.MaxDropDownItems = 30;
			comboEditorToolbar.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.VisualStudio2005;
			Infragistics.Win.EditorWithCombo ecToolbar = (Infragistics.Win.EditorWithCombo)comboEditorToolbar.Editor;

			ecToolbar.TextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
			ecToolbar.TextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			RefreshOrganismListToolbar();
			ToolStripControlHost item = new ToolStripControlHost(comboEditorToolbar);
			toolStrip1.Items.Add(item);

//			Infragistics.Win.EmbeddableEditorBase tb =
//			(Infragistics.Win.EmbeddableEditorBase)ultraComboEditor1.Editor;

//			Infragistics.Win.EditorWithCombo ec = (Infragistics.Win.EditorWithCombo)tb;
			Infragistics.Win.EditorWithCombo ec = (Infragistics.Win.EditorWithCombo)ultraComboEditor1.Editor;

			ec.TextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
			ec.TextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
/*
			AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
			autoCompleteStringCollection.Add("Red-shit woodpecker");
			autoCompleteStringCollection.Add("Red-junk woodpecker");
			autoCompleteStringCollection.Add("Reddish woodpecker");
			autoCompleteStringCollection.Add("Red-ass woodpecker");
			ec.TextBox.AutoCompleteCustomSource = autoCompleteStringCollection;

			ultraComboEditor1.Items.Add(new Infragistics.Win.ValueListItem("Option 1", "Option-Crap"));
			ultraComboEditor1.Items.Add(new Infragistics.Win.ValueListItem("Option 2", "Option-Text"));
			ultraComboEditor1.Items.Add(new Infragistics.Win.ValueListItem("Option 3", "Option-Junk"));
*/

			ultraComboEditor1.AlwaysInEditMode = true;
			ultraComboEditor1.SelectedText = string.Empty;
			ultraComboEditor1.AlwaysInEditMode = false;

			RefreshOrganismList();

//			ultraComboEditor1.AutoComplete = true;

//			ultraComboEditor1.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.OfficeXP;

//			this.ultraComboEditor1.Items[1].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;

//			for (int i = 0; i < this.ultraComboEditor1.Items.Count; i++)
//			{
//				this.ultraComboEditor1.Items[i].Appearance.BackColor = Color.FromArgb(100, 100, baseColorIndex + (baseColorIndex * i));
//			} 
		}

		void comboEditorToolbar_SelectionChangeCommitted(object sender, EventArgs e)
		{
			comboEditorToolbar.SelectedText = comboEditorToolbar.SelectedText.Trim();

			Infragistics.Win.ValueListItem valueListItem = comboEditorToolbar.SelectedItem;
			if (valueListItem != null)
			{
				OrganismListItem organism = valueListItem.DataValue as OrganismListItem;
				if (organism != null)
				{
					this.Text = organism.ToString();
				}
			}
		}

		protected void RefreshOrganismList()
		{
			ultraComboEditor1.BeginUpdate();

//			OrganismListItem selectedItem = ultraComboEditor1.SelectedItem as OrganismListItem;
			Infragistics.Win.ValueListItem valueListItem = ultraComboEditor1.SelectedItem;
//			OrganismListItem selectedItem = ultraComboEditor1.SelectedItem.DataValue as OrganismListItem;
			OrganismListItem selectedItem = null;
			if (valueListItem != null)
			{
				selectedItem = valueListItem.DataValue as OrganismListItem;
			}

			int selectedID;
			if (selectedItem != null)
			{
				selectedID = selectedItem.ID;
			}
			else
			{
				selectedID = -1;
			}
			ultraComboEditor1.Items.Clear();

			int selectedIndex = -1;
			if (Organisms != null)
			{
				AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
				SortedList sortedList = CreateSortedList(organisms, selectedItem, autoCompleteSource);

				OrganismSortOrder sortOrder = UserSettings.Instance.SortOrder;
				OrganismDisplayOptions displayName = UserSettings.Instance.DisplayName;

				foreach (OrganismListItem value in sortedList.Values)
				{
//					int index = ultraComboEditor1.Items.Add(value);
					string displayText = string.Empty;
					if (value.IsAlias && (displayName == OrganismDisplayOptions.CommonName || displayName == OrganismDisplayOptions.CommonNameLastFirst) && sortOrder == OrganismSortOrder.Taxonomic)
					{
						displayText = "   " + value.ToString();
					}
					else
					{
						displayText = value.ToString();
					}

					int index = ultraComboEditor1.Items.Add(new Infragistics.Win.ValueListItem(value, displayText));
					if (value.IsAlias)
					{
						ultraComboEditor1.Items[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					}

					if (value.ID == selectedID && selectedIndex == -1)
					{
						selectedIndex = index;
					}
				}
				ultraComboEditor1.SelectedIndex = selectedIndex;
//				AutoCompleteCustomSource = autoCompleteSource;
				Infragistics.Win.EditorWithCombo ec = (Infragistics.Win.EditorWithCombo)ultraComboEditor1.Editor;
				ec.TextBox.AutoCompleteCustomSource = autoCompleteSource;
			}

			ultraComboEditor1.EndUpdate();
		}

		protected void RefreshOrganismListToolbar()
		{
			comboEditorToolbar.BeginUpdate();

			//			OrganismListItem selectedItem = ultraComboEditor1.SelectedItem as OrganismListItem;
			Infragistics.Win.ValueListItem valueListItem = comboEditorToolbar.SelectedItem;
			//			OrganismListItem selectedItem = ultraComboEditor1.SelectedItem.DataValue as OrganismListItem;
			OrganismListItem selectedItem = null;
			if (valueListItem != null)
			{
				selectedItem = valueListItem.DataValue as OrganismListItem;
			}

			int selectedID;
			if (selectedItem != null)
			{
				selectedID = selectedItem.ID;
			}
			else
			{
				selectedID = -1;
			}
			comboEditorToolbar.Items.Clear();

			int selectedIndex = -1;
			if (Organisms != null)
			{
				AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
				SortedList sortedList = CreateSortedList(organisms, selectedItem, autoCompleteSource);

				OrganismSortOrder sortOrder = UserSettings.Instance.SortOrder;
				OrganismDisplayOptions displayName = UserSettings.Instance.DisplayName;

				foreach (OrganismListItem value in sortedList.Values)
				{
					//					int index = ultraComboEditor1.Items.Add(value);
					string displayText = string.Empty;
					if (value.IsAlias && (displayName == OrganismDisplayOptions.CommonName || displayName == OrganismDisplayOptions.CommonNameLastFirst) && sortOrder == OrganismSortOrder.Taxonomic)
					{
						displayText = "   " + value.ToString();
					}
					else
					{
						displayText = value.ToString();
					}

					int index = comboEditorToolbar.Items.Add(new Infragistics.Win.ValueListItem(value, displayText));
					if (value.IsAlias)
					{
						comboEditorToolbar.Items[index].Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
					}

					if (value.ID == selectedID && selectedIndex == -1)
					{
						selectedIndex = index;
					}
				}
				comboEditorToolbar.SelectedIndex = selectedIndex;
				//				AutoCompleteCustomSource = autoCompleteSource;
				Infragistics.Win.EditorWithCombo ec = (Infragistics.Win.EditorWithCombo)comboEditorToolbar.Editor;
				ec.TextBox.AutoCompleteCustomSource = autoCompleteSource;
			}

			comboEditorToolbar.EndUpdate();
		}

		private static SortedList CreateSortedList(OrganismListItem[] list, OrganismListItem selectedItem, AutoCompleteStringCollection autoCompleteSource)
		{
			if (list == null)
			{
				return null;
			}

			int selectedItemID;
			if (selectedItem != null)
			{
				selectedItemID = selectedItem.ID;
			}
			else
			{
				selectedItemID = -1;
			}

			SortedList sortedList = new SortedList();
			foreach (OrganismListItem organism in list)
			{
				string text = organism.ToString();
				object key;
				OrganismSortOrder sortOrder = UserSettings.Instance.SortOrder;
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

				if (organism.ID == selectedItemID)
				{
					selectedItem = organism;
				}
				autoCompleteSource.Add(text);
				sortedList[key] = organism;
			}

			return sortedList;
		}

		private OrganismListItem[] Organisms
		{
			get
			{
				if (organisms == null)
				{
					List<OrganismListItem> organismList = OrganismListItem.GetList(1, Language.Default.ID);
					organisms = organismList.ToArray();
				}

				return organisms;
			}
		}

		private void ultraComboEditor1_SelectionChanged(object sender, EventArgs e)
		{
//			ultraComboEditor1.SelectedText = ultraComboEditor1.SelectedText.Trim();
		}

		private void ultraComboEditor1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			ultraComboEditor1.SelectedText = ultraComboEditor1.SelectedText.Trim();
		}
	}
}