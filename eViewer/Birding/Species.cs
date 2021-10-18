using System;
using System.Collections.Generic;
using System.Text;

namespace Thayer.Birding
{
	public class Species
	{
		private int id;
		private string name;
		private string pronunciation;

		public Species()
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

		public string Pronunciation
		{
			get
			{
				return pronunciation;
			}

			set
			{
				pronunciation = value;
			}
		}
	}
}
