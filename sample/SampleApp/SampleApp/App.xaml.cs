
using Xamarin.Forms;

namespace SampleApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			var assembly = System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("SampleApp"));
			var bootstrapper = new Bootstrapper(this);
			bootstrapper.AutoRegisterAssembly = assembly;
			bootstrapper.Run();
		}
	}
}
