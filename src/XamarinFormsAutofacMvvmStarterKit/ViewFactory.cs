using Autofac;
using Autofac.Features.OwnedInstances;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public class ViewFactory : IViewFactory
	{
		private readonly IDictionary<Type, Type> _map = new Dictionary<Type, Type>();
		private readonly IComponentContext _componentContext;

		public ViewFactory(IComponentContext componentContext)
		{
			_componentContext = componentContext;
			_registry = new Dictionary<IViewModel, Action>();
			Xamarin.Forms.MessagingCenter.Subscribe<XamarinFormsAutofacMvvmStarterKit.NavigationPage, IViewModel>(this
				, "IViewModelPopped"
				, (s, vm) => Dispose(vm));
		}

		public void Register<TViewModel, TView>() 
			where TViewModel : class, IViewModel 
			where TView : Page
		{
			_map[typeof(TViewModel)] = typeof(TView);
		}

		public void Register(Type viewModel, Type view)
		{
			if (!viewModel.IsAssignableTo<IViewModel>())
			{
				throw new ArgumentException("viewModel must be type of IViewModel");
			}

			if (!view.IsAssignableTo<Page>())
			{
				throw new ArgumentException("view must be type of Page");
			}

			_map[viewModel] = view;
		}

		public Page Resolve<TViewModel>(Action<TViewModel> setStateAction = null) where TViewModel : class, IViewModel
		{
			TViewModel viewModel;
			return Resolve<TViewModel>(out viewModel, setStateAction);
		}

		public Page Resolve<TViewModel>(out TViewModel viewModel, Action<TViewModel> setStateAction = null) 
			where TViewModel : class, IViewModel 
		{
			var ownedVM = _componentContext.Resolve<Owned<TViewModel>> ();
			viewModel = ownedVM.Value;
			_registry.Add(viewModel, ownedVM.Dispose);

			var viewType = _map[typeof(TViewModel)];
			var view = _componentContext.Resolve(viewType) as Page;

			if (setStateAction != null)
				viewModel.SetState(setStateAction);

			view.BindingContext = viewModel;
			return view;
		}

		public Page Resolve<TViewModel>(TViewModel viewModel) 
			where TViewModel : class, IViewModel 
		{
			var viewType = _map[typeof(TViewModel)];
			var view = _componentContext.Resolve(viewType) as Page;
			view.BindingContext = viewModel;
			return view;
		}

		#region View Model Scope

		private readonly Dictionary<IViewModel, Action> _registry;

		private void Dispose(IViewModel viewModel)
		{
			var owned = _registry[viewModel];
			if (owned != null)
			{
				owned.Invoke(); ;
				_registry.Remove(viewModel);
			}
		}

		#endregion
	}
}

