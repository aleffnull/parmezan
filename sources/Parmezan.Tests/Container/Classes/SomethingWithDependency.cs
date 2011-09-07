namespace Parmezan.Tests.Container.Classes
{
	public class SomethingWithDependency : ISomethingWithDependency
	{
		#region ISomethingWithDependency implementation

		public FirstDependencyClass FirstDependency { get; private set; }

		#endregion ISomethingWithDependency implementation

		#region Constructors

		public SomethingWithDependency(FirstDependencyClass firstDependency)
		{
			FirstDependency = firstDependency;
		}

		#endregion Constructors
	}
}