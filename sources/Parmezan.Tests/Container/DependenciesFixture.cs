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

		[Test]
		public void CanResolveClassWithOneDependencyByInterface()
		{
			var box = new Box();
			box.Register<FirstDependencyClass>();
			box.Register<ISomethingWithDependency, SomethingWithDependency>();

			var obj = box.Resolve<ISomethingWithDependency>();
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.FirstDependency, Is.Not.Null);
		}

		[Test]
		public void CanResolveClassWithTwoDependencyLevels()
		{
			var box = new Box();
			box.Register<TopLevelClass>();
			box.Register<FirstLevelDependency>();
			box.Register<SecondLevelDependency>();

			var obj = box.Resolve<TopLevelClass>();
			Assert.That(obj, Is.Not.Null);
			Assert.That(obj.FirstLevelDependency, Is.Not.Null);
			Assert.That(obj.FirstLevelDependency.SecondLevelDependency, Is.Not.Null);
		}

		#endregion Tests
	}
}