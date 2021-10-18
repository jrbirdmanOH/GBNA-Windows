using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Thayer.Birding.ScreenSaver
{
	public sealed class ScreenSaverException : Exception, ISerializable
	{
		public ScreenSaverException() : base()
		{
		}

		public ScreenSaverException(string message) : base(message)
		{
		}

		public ScreenSaverException(string message, Exception innerException) : base(message, innerException)
		{
		}

		// Constructor for deserialization
		private ScreenSaverException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			// Deserialize any attributes
		}

		// The method for serialization: the SecurityPermission ensures that
		// callers are allowed to obtain the internal state of this object
		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);

			// Serialize any attributes
		}
	}
}
