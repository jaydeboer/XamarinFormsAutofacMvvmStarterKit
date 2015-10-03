using Autofac;
using System.Linq;
using System.Reflection;

namespace XamarinFormsAutofacMvvmStarterKit
{
	public abstract class CoreAutofacBootstrapper
	{
		public void Run()
		{
			var builder = new ContainerBuilder();

			ConfigureContainer(builder);

			var container = builder.Build();
			var viewFactory = container.Resolve<IViewFactory>();

			RegisterViews(viewFactory);

			ConfigureApplication(container);
		}

		public CoreAutofacBootstrapper() { }
		public CoreAutofacBootstrapper(Assembly autoRegisterAssembly)
		{
			AutoRegisterAssembly = autoRegisterAssembly;
		}

		protected virtual void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule<CoreAutofacModule>();
			if (AutoRegisterAssembly != null)
			{
				builder.RegisterAssemblyTypes(AutoRegisterAssembly).Where(t => t.Namespace != null && t.Namespace.EndsWith(".ViewModels") && t.Name.EndsWith("VM")).AsSelf().InstancePerDependency();
				builder.RegisterAssemblyTypes(AutoRegisterAssembly).Where(t => t.Namespace != null && t.Namespace.EndsWith(".Views") && t.Name.EndsWith("View")).AsSelf().InstancePerDependency();
			}
		}

		protected virtual void RegisterViews(IViewFactory viewFactory)
		{
			if (AutoRegisterAssembly == null)
				return;

			var viewModels = AutoRegisterAssembly.DefinedTypes.Where(t => t.Namespace != null && t.Namespace.EndsWith(".ViewModels") && t.Name.EndsWith("VM"));
			var views = AutoRegisterAssembly.DefinedTypes.Where(t => t.Namespace != null && t.Namespace.EndsWith(".Views") && t.Name.EndsWith("View"));

			foreach (var vm in viewModels)
			{
				var pairedViews = views.Where(v => v.Name.Substring(0, v.Name.Length - 4) == vm.Name.Substring(0, vm.Name.Length - 2));
				if (pairedViews.Count() == 1)
				{
					var vmt = vm.AsType();
					viewFactory.Register(vm.AsType(), pairedViews.First().AsType());
				}
			}
		}

		protected abstract void ConfigureApplication(IContainer container);

		private Assembly AutoRegisterAssembly { get; set; }

	}
}

