namespace XamarinFormsAutofacMvvmStarterKit.UnitTests.Mocks
{
	class MockViewModel : ViewModelBase
	{
		public bool WasOnPushedCalled { get; private set; } = false;
		public bool WasOnPoppedCalled { get; private set; } = false;
		public bool WasOnAppearingCalled { get; private set; } = false;
		public bool WasOnDisappearingCalled { get; private set; } = false;
		public override void OnAppearing()
		{
			base.OnAppearing();
			WasOnAppearingCalled = true;
		}

		public override void OnDisappearing()
		{
			base.OnDisappearing();
			WasOnDisappearingCalled = true;
		}

		public override void OnPushed()
		{
			base.OnPushed();
			WasOnPushedCalled = true;
		}

		public override void OnPopped()
		{
			base.OnPopped();
			WasOnPoppedCalled = true;
		}
	}
}
