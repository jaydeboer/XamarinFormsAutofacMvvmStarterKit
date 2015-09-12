using System;
using Xamarin.Forms;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public interface IDeviceService
	{
		TargetIdiom Idiom { get; }
		TargetPlatform OS { get; }
		void BeginInvokeOnMainThread(Action action);
		double GetNamedSize(NamedSize size, Type targetElementType);
		double GetNamedSize(NamedSize size, Element targetElement);
		void OnPlatform(Action iOS, Action Android, Action WinPhone, Action Default);
		void OnPlatform<T>(T iOS, T android, T winPhone);
		void OpenUri(Uri uri);
		void StartTimer(TimeSpan interval, Func<bool> callback);
    }
}
