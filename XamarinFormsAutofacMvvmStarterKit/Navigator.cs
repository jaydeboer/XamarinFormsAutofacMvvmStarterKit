using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public class Navigator : INavigator
	{
		private readonly Lazy<INavigation> _navigation;
		private readonly IViewFactory _viewFactory;
		private readonly IDeviceService _deviceService;

		public Navigator(Lazy<INavigation> navigation, IViewFactory viewFactory, IDeviceService deviceService)
		{
			_navigation = navigation;
			_viewFactory = viewFactory;
			_deviceService = deviceService;
		}

		private INavigation Navigation
		{
			get { return _navigation.Value; }
		}

		public Task<IViewModel> PopAsync()
		{
			var tcs = new TaskCompletionSource<IViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				Page view = await Navigation.PopAsync();
				tcs.SetResult(view.BindingContext as IViewModel);

			});
            return tcs.Task;
		}

		public Task<IViewModel> PopModalAsync()
		{
			var tcs = new TaskCompletionSource<IViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				Page view = await Navigation.PopAsync();
				tcs.SetResult(view.BindingContext as IViewModel);
			});
            return tcs.Task;
		}

		public Task PopToRootAsync()
		{
			var tcs = new TaskCompletionSource<object>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				await Navigation.PopToRootAsync();
				tcs.SetResult(null);
			});
			return tcs.Task;
		}

		public Task<TViewModel> PushAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel
		{
			var tcs = new TaskCompletionSource<TViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				TViewModel viewModel;
				var view = _viewFactory.Resolve(out viewModel, setStateAction);
				await Navigation.PushAsync(view);
				tcs.SetResult(viewModel);
			});
			return tcs.Task;
		}

		public Task<TViewModel> PushAsync<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel
		{
			var tcs = new TaskCompletionSource<TViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				var view = _viewFactory.Resolve(viewModel);
				await Navigation.PushAsync(view);
				tcs.SetResult(viewModel);
			});
			return tcs.Task;
		}

		public Task<TViewModel> PushModalAsync<TViewModel>(Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel
		{
			var tcs = new TaskCompletionSource<TViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				TViewModel viewModel;
				var view = _viewFactory.Resolve<TViewModel>(out viewModel, setStateAction);
				await Navigation.PushModalAsync(view);
				tcs.SetResult(viewModel);
			});
			return tcs.Task;
		}

		public Task<TViewModel> PushModalAsync<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel
		{
			var tcs = new TaskCompletionSource<TViewModel>();
			Device.BeginInvokeOnMainThread(async () =>
			{
				var view = _viewFactory.Resolve(viewModel);
				await Navigation.PushModalAsync(view);
				tcs.SetResult(viewModel);
			});
			return tcs.Task;
		}
	}
}
