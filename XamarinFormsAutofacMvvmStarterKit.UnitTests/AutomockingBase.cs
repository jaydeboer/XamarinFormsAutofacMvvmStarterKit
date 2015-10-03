using Autofac.Extras.Moq;
using NUnit.Framework;

namespace XamarinFormsAutofacMvvmStarterKit.UnitTests
{
	public class AutomockingBase
	{

		AutoMock _mock = null;

		protected AutoMock mock
		{
			get
			{
				if (_mock == null)
				{
					_mock = AutoMock.GetLoose();
				}
				return _mock;
			}
		}

		[TearDown]
		private void TearDown()
		{
			if (_mock != null)
			{
				_mock.Dispose();
				_mock = null;
			}
		}
	}
}
