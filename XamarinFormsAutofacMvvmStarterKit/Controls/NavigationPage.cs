namespace XamarinFormsAutofacMvvmStarterKit
{
	public class NavigationPage : Xamarin.Forms.NavigationPage
	{
		public NavigationPage ()  :base()
		{
			Initialize ();
		}

		public NavigationPage (Xamarin.Forms.Page root) : base (root)
		{
			Initialize ();
		}

		private void Initialize ()
		{
			Popped += OnPopped;
			Pushed += OnPushed;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var vm = CurrentPage.BindingContext as IViewModel;
			if (vm != null)
			{
				vm.OnAppearing();
			}
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			var vm = CurrentPage.BindingContext as IViewModel;
			if (vm != null)
			{
				vm.OnDisappearing();
			}
		}
		private void OnPopped(object sender, Xamarin.Forms.NavigationEventArgs e)
		{
			var vm = e.Page.BindingContext as IViewModel;
			if (vm != null)
			{
				vm.OnPopped();
				Xamarin.Forms.MessagingCenter.Send<NavigationPage, IViewModel>(this, "IViewModelPopped", vm);
			}
		}

		private void OnPushed(object sender, Xamarin.Forms.NavigationEventArgs e)
		{
			var vm = e.Page.BindingContext as IViewModel;
			if (vm != null)
			{
				vm.OnPushed();
			}
		}
	}
}

