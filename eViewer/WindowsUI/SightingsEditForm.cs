using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows
{
    public partial class SightingsEditForm : Form
    {
        private readonly object eventLock = new object();
        private event EventHandler<EventArgs> observerCreated;
        private event EventHandler<EventArgs> sightingSaved;

        private Collection collection = null;
        private Language language = null;
        private Sighting sighting = null;

        private static int? locationID = null;
        private static int? observerID = null;
		private static DateTime? sightingDate = null;

		public SightingsEditForm()
        {
            InitializeComponent();

            // Set common icon
            if (this.ShowIcon)
            {
                this.Icon = Thayer.Birding.UI.Windows.Properties.Resources.MainIcon16;
            }
        }

        public event EventHandler<EventArgs> ObserverCreated
        {
            add
            {
                lock (eventLock)
                {
                    observerCreated += value;
                }
            }

            remove
            {
                lock (eventLock)
                {
                    observerCreated -= value;
                }
            }
        }

        protected virtual void OnObserverCreated(EventArgs e)
        {
            EventHandler<EventArgs> temp = observerCreated;

            if (temp != null)
            {
                temp(this, e);
            }
        }

        public event EventHandler<EventArgs> SightingSaved
        {
            add
            {
                lock (eventLock)
                {
                    sightingSaved += value;
                }
            }

            remove
            {
                lock (eventLock)
                {
                    sightingSaved -= value;
                }
            }
        }

        protected virtual void OnSightingSaved(EventArgs e)
        {
            EventHandler<EventArgs> temp = sightingSaved;

            if (temp != null)
            {
                temp(this, e);
            }
        }

        public Collection Collection
        {
            get
            {
                return collection;
            }

            set
            {
                collection = value;
            }
        }

        public Language Language
        {
            get
            {
                return language;
            }

            set
            {
                language = value;
            }
        }

        public Sighting Sighting
        {
            get
            {
                return sighting;
            }

            set
            {
                sighting = value;

                if (IsHandleCreated)
                {
                    Init();
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<OrganismListItem> organismList = OrganismListItem.GetList(Collection.ID, Language.ID);
            organismComboBox.Organisms = organismList.ToArray();

            List<Thayer.Birding.Location> locations = Thayer.Birding.Location.GetList();
            foreach (Thayer.Birding.Location location in locations)
            {
                locationComboBox.Items.Add(location);
            }

            RefreshObservers();

			// Restore the last selected date
			if (SightingsEditForm.sightingDate.HasValue)
			{
				dateTimePicker.Value = SightingsEditForm.sightingDate.Value;
			}

			// Restore the last selected location
			if (SightingsEditForm.locationID.HasValue)
            {
                SelectLocation(SightingsEditForm.locationID.Value);
            }

            // Restore the last selected observer
            if (SightingsEditForm.observerID.HasValue)
            {
                SelectObserver(SightingsEditForm.observerID.Value);
            }

            Init();
        }

        private void RefreshObservers()
        {
            observerComboBox.Items.Clear();

            List<Observer> observerList = Observer.GetList();
            foreach (Observer observer in observerList)
            {
                observerComboBox.Items.Add(observer);
            }
        }

        protected void Init()
        {
            organismComboBox.SelectedOrganismID = sighting.Organism.ID;
			if (!SightingsEditForm.sightingDate.HasValue)
			{
				dateTimePicker.Value = sighting.Date;
			}
			SelectLocation(sighting.Location.ID);
            commentsTextBox.Text = sighting.Comments;
            SelectObserver(sighting.Observer.ID);
        }

        private void SelectLocation(int locationID)
        {
            int count = locationComboBox.Items.Count;
            for (int index = 0; index < count; index++)
            {
                Location location = locationComboBox.Items[index] as Location;
                if (location.ID == locationID)
                {
                    locationComboBox.SelectedIndex = index;
                    break;
                }
            }
        }

        private void SelectObserver(int observerID)
        {
            for (int index = 0; index < observerComboBox.Items.Count; index++)
            {
                Observer observer = observerComboBox.Items[index] as Observer;
                if (observer.ID == observerID)
                {
                    observerComboBox.SelectedIndex = index;
                    break;
                }
            }

            // If an observer has not been selected, select the first observer in the list.
            if (observerComboBox.SelectedIndex == -1 && observerComboBox.Items.Count > 0)
            {
                observerComboBox.SelectedIndex = 0;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (SaveSighting())
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void saveAndAddButton_Click(object sender, EventArgs e)
        {
            if (SaveSighting())
            {
                // Prepare for new sighting
                sighting = new Sighting();
                organismComboBox.SelectedOrganismID = -1;
				commentsTextBox.Text = string.Empty;

				if (SightingsEditForm.locationID.HasValue)
				{
					SelectLocation(SightingsEditForm.locationID.Value);
				}

				if (SightingsEditForm.observerID.HasValue)
				{
					SelectObserver(SightingsEditForm.observerID.Value);
				}
			}
        }

        private void newObserverButton_Click(object sender, EventArgs e)
        {
            ObserverEditForm form = new ObserverEditForm();
            form.Observer = new Observer();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                RefreshObservers();
                SelectObserver(form.Observer.ID);
                OnObserverCreated(EventArgs.Empty);
            }
        }

        private bool ValidateSighting()
        {
            bool isValid = true;

            OrganismListItem organism = organismComboBox.SelectedItem as OrganismListItem;
            Location location = locationComboBox.SelectedItem as Location;
            Observer observer = observerComboBox.SelectedItem as Observer;

            if (isValid && organism == null)
            {
                MessageBox.Show(this, "A bird must be selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValid = false;
            }

            if (isValid && location == null)
            {
                MessageBox.Show(this, "A location must be selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValid = false;
            }

            if (isValid && observer == null)
            {
                MessageBox.Show(this, "An observer must be selected.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                isValid = false;
            }

            return isValid;
        }

        private bool SaveSighting()
        {
            bool saved = false;

            if (ValidateSighting())
            {
                OrganismListItem organism = organismComboBox.SelectedItem as OrganismListItem;
				DateTime sightingDate = dateTimePicker.Value;
                Location location = locationComboBox.SelectedItem as Location;
                Observer observer = observerComboBox.SelectedItem as Observer;

                sighting.Organism.ID = organism.ID;
                sighting.Location.ID = location.ID;
                sighting.Date = sightingDate;
                sighting.Comments = commentsTextBox.Text;
                sighting.Observer.ID = observer.ID;

                sighting.Save();
                saved = true;
                OnSightingSaved(EventArgs.Empty);

				// Keep track of the date, location and observer so they can
				// be preselected if the user is adding multiple sightings
				SightingsEditForm.sightingDate = sightingDate;
                SightingsEditForm.locationID = location.ID;
                SightingsEditForm.observerID = observer.ID;
            }

            return saved;
        }
    }
}