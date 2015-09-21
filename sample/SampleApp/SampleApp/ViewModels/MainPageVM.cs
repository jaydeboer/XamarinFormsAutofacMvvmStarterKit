using System.Windows.Input;
using Xamarin.Forms;
using XamarinFormsAutofacMvvmStarterKit;

namespace SampleApp.ViewModels
{
	public class MainPageVM : ViewModelBase
	{
		public string Message { get; set; }

		public ICommand NextViewCommand { get; private set; }

		public MainPageVM(INavigator nav)
		{
			Navigator = nav;

			NextViewCommand = new Command(async () => await Navigator.PushAsync<SecondPageVM>());
			Message = "This is the first page.";
		}

		private readonly INavigator Navigator;
	}
}
