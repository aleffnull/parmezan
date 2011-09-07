using NUnit.Framework;
using Parmezan.Container;
using Parmezan.Container.Exceptions;
using Parmezan.Tests.Container.Classes;

namespace Parmezan.Tests.Container
{
	[TestFixture]
	public class NoDependenciesFixture
	{
		#region Tests

		[Test]
		public void CanResolveByClass()
		{
			var box = new Box();
			box.Register<NoDependenciesClass>();

			var resolvedObj = box.Resolve<NoDependenciesClass>();
			Assert.That(resolvedObj, Is.Not.Null);
		}

		[Test]
		public void CanResolveByInterface()
		{
			var box = new Box();
			box.Register<ISomething, Something>();

			var resolvedObject = box.Resolve<ISomething>();
			Assert.That(resolvedObject, Is.Not.Null);
		}

		[Test]
		public void ResolvingOfNotRegisteredClassThrowsException()
		{
			var box = new Box();
			Assert.That(() => box.Resolve<NoDependenciesClass>(), Throws.InstanceOf<TypeNotFoundException>());
		}

		[Test]
		public void ResolvingByClassIfRegisteredByInterfaceThrowsException()
		{
			var box = new Box();
			box.Register<ISomething, Something>();
			Assert.That(() => box.Resolve<Something>(), Throws.InstanceOf<TypeNotFoundException>());
		}

		#endregion Tests
	}
}