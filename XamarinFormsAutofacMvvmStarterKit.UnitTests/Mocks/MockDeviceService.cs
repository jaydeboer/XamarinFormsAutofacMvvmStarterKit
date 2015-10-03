using System;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit.UnitTests.Mocks
{
	class MockDeviceService : IDeviceService
	{
		public TargetIdiom Idiom
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public TargetPlatform OS
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			action.Invoke();
		}

		public double GetNamedSize(NamedSize size, Element targetElement)
		{
			throw new NotImplementedException();
		}

		public double GetNamedSize(NamedSize size, Type targetElementType)
		{
			throw new NotImplementedException();
		}

		public void OnPlatform(Action iOS, Action Android, Action WinPhone, Action Default)
		{
			throw new NotImplementedException();
		}

		public void OnPlatform<T>(T iOS, T android, T winPhone)
		{
			throw new NotImplementedException();
		}

		public void OpenUri(Uri uri)
		{
			throw new NotImplementedException();
		}

		public void StartTimer(TimeSpan interval, Func<bool> callback)
		{
			throw new NotImplementedException();
		}
	}
}
