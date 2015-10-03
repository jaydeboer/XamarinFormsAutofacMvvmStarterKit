using Autofac;
using System.Reflection;

namespace XamarinFormsAutofacMvvmStarterKit.UnitTests.Mocks
{
	public class MockBootstrapper : CoreAutofacBootstrapper
	{
		public IViewFactory ViewFactory { get; set; }

		public IContainer Container { get; set; }

		protected override void ConfigureContainer(ContainerBuilder builder)
		{
			base.ConfigureContainer(builder);
			builder.RegisterType<MockViewModel>();
			builder.RegisterType<MockView>();
		}

		protected override void RegisterViews(IViewFactory viewFactory)
		{
			base.RegisterViews(viewFactory);
			ViewFactory = viewFactory;
			ViewFactory.Register<MockViewModel, MockView>();
		}

		protected override void ConfigureApplication(IContainer container)
		{
			Container = container;
		}

		public MockBootstrapper() : base() { }
		public MockBootstrapper(Assembly autoRegisterAssembly) : base(autoRegisterAssembly) { }
	}
}
