using System;

namespace Parmezan.Container.Helpers
{
	internal class ImplementationInformation
	{
		#region Properties

		public Type Type { get; private set; }
		public LifeStyle LifeStyle { get; private set; }
		public object Instance { get; set; }

		#endregion Properties

		#region Constructors

		public ImplementationInformation(Type type, LifeStyle lifeStyle)
		{
			Type = type;
			LifeStyle = lifeStyle;
		}

		#endregion Constructors
	}
}