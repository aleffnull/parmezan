namespace Parmezan.Tests.Container.Classes
{
	public class FirstLevelDependency
	{
		#region Properties

		public SecondLevelDependency SecondLevelDependency { get; private set; }

		#endregion Properties

		#region Constructors

		public FirstLevelDependency(SecondLevelDependency secondLevelDependency)
		{
			SecondLevelDependency = secondLevelDependency;
		}

		#endregion Constructors
	}
}