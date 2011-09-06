using NUnit.Framework;
using Parmezan.Container;
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

		#endregion Tests
	}
}