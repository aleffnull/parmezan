namespace Parmezan.Tests.Container.Classes
{
	public class OneDependencyClass
	{
		#region Properties

		public FirstDependencyClass FirstDependency { get; private set; }

		#endregion Properties

		#region Constructors

		public OneDependencyClass(FirstDependencyClass firstDependency)
		{
			FirstDependency = firstDependency;
		}

		#endregion Constructors
	}
}