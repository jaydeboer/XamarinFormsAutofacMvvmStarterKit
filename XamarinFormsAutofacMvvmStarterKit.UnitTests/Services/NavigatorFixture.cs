using Moq;
using NUnit.Framework;
using System;
using Xamarin.Forms;
using XamarinFormsAutofacMvvmStarterKit.UnitTests.Mocks;

namespace XamarinFormsAutofacMvvmStarterKit.UnitTests.Services
{
	[TestFixture]
	public class NavigatorFixture : AutomockingBase
	{
		private MockViewModel _viewModel;
		private Navigator _navigator;
		private Action<MockViewModel> _action;

		[SetUp]
		public void SetUp()
		{
			_action = x => x.Title = "Test";
			_viewModel = new MockViewModel();
			var navigation = mock.Mock<INavigation>();

			navigation.Setup(x => x.PopAsync()).ReturnsAsync(new Page { BindingContext = new MockViewModel() });
			navigation.Setup(x => x.PopModalAsync()).ReturnsAsync(new Page { BindingContext = new MockViewModel() });
			navigation.Setup(x => x.PopToRootAsync());
		
			mock.Mock<IViewFactory>().Setup(x => x.Resolve(out _viewModel, _action)).Returns(new MockView());

			mock.Provide<IDeviceService, MockDeviceService>();
			_navigator = mock.Create<Navigator>(); //(new Lazy<INavigation>(() => navigation.Object), viewFactory.Object);
		}

		[Test]
		public async void NavigateToView()
		{
			MockViewModel viewModel = await _navigator.PushAsync<MockViewModel>(_action);
			Assert.That(viewModel, Is.EqualTo(_viewModel));
		}

		[Test]
		public async void NavigateToModalView()
		{
			MockViewModel viewModel = await _navigator.PushModalAsync<MockViewModel>(_action);
			Assert.That(viewModel, Is.EqualTo(_viewModel));
		}

		[Test]
		public async void NavigateFromView()
		{
			var viewModel = await _navigator.PopAsync();
			Assert.That(viewModel, Is.Not.Null);
			Assert.That(viewModel, Is.TypeOf<MockViewModel>());
		}

		[Test]
		public async void NavigateFromModalView()
		{
			var viewModel = await _navigator.PopModalAsync();
			Assert.That(viewModel, Is.Not.Null);
			Assert.That(viewModel, Is.TypeOf<MockViewModel>());
		}

		[Test]
		public async void NavigateToRoot()
		{
			var viewModel = await _navigator.PopModalAsync();
			Assert.That(viewModel, Is.Not.Null);
			Assert.That(viewModel, Is.TypeOf<MockViewModel>());
		}
	}

}
