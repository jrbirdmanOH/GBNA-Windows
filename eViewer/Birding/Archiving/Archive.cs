using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Thayer.Birding.Archiving
{
	public class Archive
	{
		// Number of Tasks should correspond to the number of lists shown below.
		private const int NumberTasks = 5;
		private const int PercentPerGroup = 100 / NumberTasks;

		private List<CustomList> customLists = null;
		private List<Observer> observers = null;
		private List<Sighting> sightings = null;
		private List<HallOfFame> hallOfFameEntries = null;
		private List<Note> notes = null;

		private Dictionary<int, int> observerKeys = null;

		private EventHandler<ProgressUpdateEventArgs> restoreProgress = null;

		public Archive()
		{
		}

		public List<CustomList> CustomLists
		{
			get
			{
				return customLists;
			}

			set
			{
				customLists = value;
			}
		}

		public List<Observer> Observers
		{
			get
			{
				return observers;
			}

			set
			{
				observers = value;
			}
		}

		public List<Sighting> Sightings
		{
			get
			{
				return sightings;
			}

			set
			{
				sightings = value;
			}
		}

		public List<HallOfFame> HallOfFameEntries
		{
			get
			{
				return hallOfFameEntries;
			}

			set
			{
				hallOfFameEntries = value;
			}
		}

		public List<Note> Notes
		{
			get
			{
				return notes;
			}

			set
			{
				notes = value;
			}
		}

		public event EventHandler<ProgressUpdateEventArgs> RestoreProgress
		{
			add
			{
				restoreProgress += value;
			}

			remove
			{
				restoreProgress -= value;
			}
		}

		protected void OnRestoreProgressUpdated(ProgressUpdateEventArgs e)
		{
			if (restoreProgress != null)
			{
				restoreProgress(this, e);
			}
		}

		public void Restore()
		{
			bool failed = true;
			IDbConnection conn = null;
			IDbTransaction trans = null;
			try
			{
				conn = ApplicationSettings.CreateConnection();
				conn.Open();

				trans = conn.BeginTransaction();

				int percentComplete = 0;
/*
				OnRestoreProgressUpdated(new ProgressUpdateEventArgs("Restoring Custom Lists", percentComplete));
				CleanupCustomLists(trans);
				SaveCustomLists(trans);
				percentComplete += PercentPerGroup;
*/
				OnRestoreProgressUpdated(new ProgressUpdateEventArgs("Restoring Observers", percentComplete));
				// Need to cleanup sightings before observers due to referential integrity constraints
				CleanupSightings(trans);
				CleanupObservers(trans);
				SaveObservers(trans);
				percentComplete += PercentPerGroup;

				OnRestoreProgressUpdated(new ProgressUpdateEventArgs("Restoring Sightings", percentComplete));
				SaveSightings(trans);
				percentComplete += PercentPerGroup;
/*
				OnRestoreProgressUpdated(new ProgressUpdateEventArgs("Restoring Hall of Fame", percentComplete));
				CleanupHallOfFame(trans);
				SaveHallOfFame(trans);
				percentComplete += PercentPerGroup;

				OnRestoreProgressUpdated(new ProgressUpdateEventArgs("Restoring Notes", percentComplete));
				CleanupNotes(trans);
				SaveNotes(trans);
				percentComplete += PercentPerGroup;

				OnRestoreProgressUpdated(new ProgressUpdateEventArgs(percentComplete));
*/
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

		private static void CleanupCustomLists(IDbTransaction trans)
		{
			List<CustomList> customLists = CustomList.GetList();
			foreach (CustomList customList in customLists)
			{
				customList.Delete(trans);
			}
		}

		private void SaveCustomLists(IDbTransaction trans)
		{
			foreach (CustomList customList in customLists)
			{
				customList.SaveContents(true, trans);
			}
		}

		private static void CleanupObservers(IDbTransaction trans)
		{
			List<Observer> observers = Observer.GetList();
			foreach (Observer observer in observers)
			{
				observer.Delete(trans);
			}
		}

		private void SaveObservers(IDbTransaction trans)
		{
			observerKeys = new Dictionary<int, int>();

			foreach (Observer observer in observers)
			{
				int oldID = observer.ID;
				observer.ID = 0;
				observer.Save(trans);
				observerKeys[oldID] = observer.ID;
			}
		}

		private static void CleanupSightings(IDbTransaction trans)
		{
			List<Sighting> sightings = Sighting.GetList();
			foreach (Sighting sighting in sightings)
			{
				sighting.Delete(trans);
			}
		}

		private void SaveSightings(IDbTransaction trans)
		{
			foreach (Sighting sighting in sightings)
			{
				sighting.Observer.ID = observerKeys[sighting.Observer.ID];

				if (Organism.Exists(sighting.Organism.ID) && !sighting.Exists())
				{
					sighting.Save(trans);
				}

//				sighting.Save(trans);
			}
		}

		private static void CleanupHallOfFame(IDbTransaction trans)
		{
			HallOfFame.DeleteAll(trans);
		}

		private void SaveHallOfFame(IDbTransaction trans)
		{
			foreach (HallOfFame entry in hallOfFameEntries)
			{
				entry.ID = 0;
				entry.Save(trans);
			}
		}

		private static void CleanupNotes(IDbTransaction trans)
		{
			Note.DeleteAll(trans);
		}

		private void SaveNotes(IDbTransaction trans)
		{
			foreach (Note note in notes)
			{
				note.Save(trans);
			}
		}
	}
}
