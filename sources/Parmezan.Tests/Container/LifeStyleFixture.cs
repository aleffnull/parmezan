using NUnit.Framework;
using Parmezan.Container;
using Parmezan.Tests.Container.Classes;

namespace Parmezan.Tests.Container
{
	[TestFixture]
	// ReSharper disable RedundantArgumentDefaultValue
	public class LifeStyleFixture
	{
		#region Tests

		[Test]
		public void NewPerResolveLifeStyleTestByClass()
		{
			var box = new Box();
			box.Register<NoDependenciesClass>(LifeStyle.NewPerResolve);

			var obj1 = box.Resolve<NoDependenciesClass>();
			var obj2 = box.Resolve<NoDependenciesClass>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.False);
		}

		[Test]
		public void NewPerResolveLifeStyleTestByInterface()
		{
			var box = new Box();
			box.Register<ISomething, Something>(LifeStyle.NewPerResolve);

			var obj1 = box.Resolve<ISomething>();
			var obj2 = box.Resolve<ISomething>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.False);
		}

		[Test]
		public void SingleForContainerLifeStyleTestByClass()
		{
			var box = new Box();
			box.Register<NoDependenciesClass>(LifeStyle.SingleForContainer);

			var obj1 = box.Resolve<NoDependenciesClass>();
			var obj2 = box.Resolve<NoDependenciesClass>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.True);
		}

		[Test]
		public void SingleForContainerLifeStyleTestByInterface()
		{
			var box = new Box();
			box.Register<ISomething, Something>(LifeStyle.SingleForContainer);

			var obj1 = box.Resolve<ISomething>();
			var obj2 = box.Resolve<ISomething>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.True);
		}

		[Test]
		public void DifferentLifeStylesTestByClass()
		{
			var box = new Box();
			box.Register<NoDependenciesClass>(LifeStyle.NewPerResolve);
			box.Register<FirstDependencyClass>(LifeStyle.SingleForContainer);
			box.Register<OneDependencyClass>(LifeStyle.SingleForContainer);

			var obj11 = box.Resolve<NoDependenciesClass>();
			var obj12 = box.Resolve<NoDependenciesClass>();
			Assert.That(ReferenceEquals(obj11, obj12), Is.False);

			var obj21 = box.Resolve<OneDependencyClass>();
			var obj22 = box.Resolve<OneDependencyClass>();
			Assert.That(ReferenceEquals(obj21, obj22), Is.True);
		}

		[Test]
		public void DifferentLifeStylesTestByInterface()
		{
			var box = new Box();
			box.Register<FirstDependencyClass>();
			box.Register<ISomethingWithDependency, SomethingWithDependency>(LifeStyle.NewPerResolve);
			box.Register<ISomething, Something>(LifeStyle.SingleForContainer);

			var obj11 = box.Resolve<ISomethingWithDependency>();
			var obj12 = box.Resolve<ISomethingWithDependency>();
			Assert.That(ReferenceEquals(obj11, obj12), Is.False);

			var obj21 = box.Resolve<ISomething>();
			var obj22 = box.Resolve<ISomething>();
			Assert.That(ReferenceEquals(obj21, obj22), Is.True);

		}

		[Test]
		public void DefaultLifeStyleIsSingleForContainerByClass()
		{
			var box = new Box();
			box.Register<NoDependenciesClass>();

			var obj1 = box.Resolve<NoDependenciesClass>();
			var obj2 = box.Resolve<NoDependenciesClass>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.True);

		}

		[Test]
		public void DefaultLifeStyleIsSingleForContainerByInterface()
		{
			var box = new Box();
			box.Register<ISomething, Something>();

			var obj1 = box.Resolve<ISomething>();
			var obj2 = box.Resolve<ISomething>();
			Assert.That(ReferenceEquals(obj1, obj2), Is.True);
		}

		#endregion Tests
	}
	// ReSharper restore RedundantArgumentDefaultValue
}