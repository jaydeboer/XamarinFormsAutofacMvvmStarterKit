using Autofac;
using SampleApp.ViewModels;
using XamarinFormsAutofacMvvmStarterKit;

namespace SampleApp
{
	public class Bootstrapper : CoreAutofacBootstrapper
	{
		public Bootstrapper(Xamarin.Forms.Application app)
		{
			App = app;
		}

		protected override void ConfigureApplication(IContainer container)
		{
			var viewFactory = container.Resolve<IViewFactory>();
			var mainPage = viewFactory.Resolve<MainPageVM>();
			var navigationPage = new NavigationPage(mainPage);

			App.MainPage = navigationPage;
		}

		private readonly Xamarin.Forms.Application App;
	}
}
