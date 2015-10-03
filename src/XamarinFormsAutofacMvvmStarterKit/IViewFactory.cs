using System;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public interface IViewFactory
	{
		void Register<TViewModel, TView>() 
			where TViewModel : class, IViewModel 
			where TView : Page;
		void Register(Type viewModel, Type view);
        Page Resolve<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel;

		Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel;

		Page Resolve<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel;
	}
}

