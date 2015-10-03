using NUnit.Framework;
using System.Linq;
using System.Reflection;
using XamarinFormsAutofacMvvmStarterKit.UnitTests.Mocks;
using XamarinFormsAutofacMvvmStarterKit.UnitTests.ViewModels;
using XamarinFormsAutofacMvvmStarterKit.UnitTests.Views;

namespace XamarinFormsAutofacMvvmStarterKit.UnitTests.Bootstrapping
{
	[TestFixture]
	public class CoreAutofactBootstrapperFixture
	{
		[Test]
		public void ConfiguresWhenRun()
		{
			var bootstrapper = new MockBootstrapper();
			bootstrapper.Run();

			Assert.That(bootstrapper.ViewFactory, Is.Not.Null);

			var view = bootstrapper.ViewFactory.Resolve<MockViewModel>();

			Assert.That(view, Is.Not.Null);

			Assert.That(bootstrapper.Container, Is.Not.Null);
			Assert.That(bootstrapper.Container.ComponentRegistry.Registrations.Count(), Is.EqualTo(8));

		}
		[Test]
		public void AutoRegistersViewsAndViewModels_WhenAssemblyIsSupplied()
		{
			var assembly = Assembly.GetAssembly(typeof(ViewModels.SampleVM));
			var bootstrapper = new MockBootstrapper(assembly);
			bootstrapper.Run();

			Assert.That(bootstrapper.ViewFactory, Is.Not.Null);

			var view = bootstrapper.ViewFactory.Resolve<SampleVM>();

			Assert.That(view, Is.InstanceOf<SampleView>());

			Assert.That(bootstrapper.Container, Is.Not.Null);
			Assert.That(bootstrapper.Container.ComponentRegistry.Registrations.Count(), Is.EqualTo(10));

		}
	}
}
