using NUnit.Framework;
using Parmezan.Container;

namespace Parmezan.Tests.Container
{
	[TestFixture]
	public class GeneralFixture
	{
		#region Tests

		[Test]
		public void CanInstantiateContainer()
		{
			new Box();
		}

		#endregion Tests
	}
}