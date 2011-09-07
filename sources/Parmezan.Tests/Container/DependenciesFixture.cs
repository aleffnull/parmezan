using NUnit.Framework;
using Parmezan.Container;
using Parmezan.Tests.Container.Classes;

namespace Parmezan.Tests.Container
{
	[TestFixture]
	public class DependenciesFixture
	{
		#region Tests

		[Test]
		public void CanResolveClassWithOneDependency()
		{
			var box = new Box();
			box.Register<FirstDependencyClass>();
			box.Register<OneDependencyClass>();

			var obj = box.Resolve<OneDependencyClass>();
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.FirstDependency, Is.Not.Null);
		}

		#endregion Tests
	}
}