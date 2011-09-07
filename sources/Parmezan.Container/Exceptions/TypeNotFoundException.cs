using System;
using System.Runtime.Serialization;

namespace Parmezan.Container.Exceptions
{
	[Serializable]
	public class TypeNotFoundException : Exception
	{
		#region Constructors

		public TypeNotFoundException()
		{
			//
		}

		public TypeNotFoundException(string message)
			: base(message)
		{
			//
		}

		public TypeNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
			//
		}

		protected TypeNotFoundException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			//
		}

		#endregion Constructors
	}
}