using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public abstract class ViewModelBase : IViewModel
	{
		public string Title { get; set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public void SetState<T>(Action<T> action) where T : class, IViewModel
		{
			action(this as T);
		}

		protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (object.Equals(storage, value)) return false;

			storage = value;
			OnPropertyChanged(propertyName);

			return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var eventHandler = PropertyChanged;
			if (eventHandler != null)
			{
				eventHandler(this, new PropertyChangedEventArgs(propertyName));
			}
		}


		public virtual void OnAppearing () {	}
		public virtual void OnDisappearing (){ }
		public void OnPushed (){}
		public void OnPopped (){}
	}
}

