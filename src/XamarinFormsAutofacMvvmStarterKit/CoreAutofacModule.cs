using Autofac;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	class CoreAutofacModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			// service registration
			builder.RegisterType<ViewFactory>()
				.As<IViewFactory>()
				.SingleInstance();

			builder.RegisterType<Navigator>()
				.As<INavigator>()
				.SingleInstance();

			builder.RegisterType<XamarinDeviceService>()
				.As<IDeviceService>()
				.SingleInstance();

			// navigation registration
			builder.Register<INavigation>(context => 
				Application.Current.MainPage.Navigation
			).SingleInstance();
		}
	}
}

