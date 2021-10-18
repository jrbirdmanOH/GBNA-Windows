namespace Thayer.Birding
{
	public class IDString
	{
		private int id;
		private string text;

		public IDString()
		{
			this.id = 0;
			this.text = string.Empty;
		}

		public IDString(int id, string text)
		{
			this.id = id;
			this.text = text;
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

		public string Text
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		public override string ToString()
		{
			return text;
		}
	}
}
