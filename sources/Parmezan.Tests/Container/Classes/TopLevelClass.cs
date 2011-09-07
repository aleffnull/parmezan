namespace Parmezan.Tests.Container.Classes
{
	public class TopLevelClass
	{
		#region Properties

		public FirstLevelDependency FirstLevelDependency { get; private set; }

		#endregion Properties

		#region Constructors

		public TopLevelClass(FirstLevelDependency firstLevelDependency)
		{
			FirstLevelDependency = firstLevelDependency;
		}

		#endregion Constructors
	}
}