using System;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	class XamarinDeviceService : IDeviceService
	{
		public TargetIdiom Idiom
		{
			get
			{
				return Device.Idiom;
			}
		}

		public TargetPlatform OS
		{
			get
			{
				return Device.OS;
			}
		}

		public void BeginInvokeOnMainThread(Action action)
		{
			Device.BeginInvokeOnMainThread(action);
		}

		public double GetNamedSize(NamedSize size, Element targetElement)
		{
			return Device.GetNamedSize(size, targetElement);
		}

		public double GetNamedSize(NamedSize size, Type targetElementType)
		{
			return Device.GetNamedSize(size, targetElementType);
		}

		public void OnPlatform(Action iOS, Action android, Action winPhone, Action defaultPlatform)
		{
			Device.OnPlatform(iOS, android, winPhone, defaultPlatform);
		}

		public void OnPlatform<T>(T iOS, T android, T winPhone)
		{
			Device.OnPlatform<T>(iOS, android, winPhone);
		}

		public void OpenUri(Uri uri)
		{
			Device.OpenUri(uri);
		}

		public void StartTimer(TimeSpan interval, Func<bool> callback)
		{
			Device.StartTimer(interval, callback);
		}
	}
}
