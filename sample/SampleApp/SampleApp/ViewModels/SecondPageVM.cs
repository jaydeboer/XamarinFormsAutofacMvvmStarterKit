using XamarinFormsAutofacMvvmStarterKit;

namespace SampleApp.ViewModels
{
	public class SecondPageVM : ViewModelBase
	{
		public string Message { get; set; }

		public SecondPageVM()
		{
			Message = "Hello from second page.";
		}
	}
}
