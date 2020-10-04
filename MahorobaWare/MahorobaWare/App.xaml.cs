using Prism.Ioc;
using MahorobaWare.Views;
using System.Windows;
using Prism.Modularity;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MahorobaWare.Core.Module;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using DryIoc;
using Prism.Container.Extensions;
using Prism.DryIoc.Extensions;
using System.Linq;

namespace MahorobaWare
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		protected override Window CreateShell()
		{
			return Container.Resolve<MainWindow>();
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			var plugins = ModuleLoader.LoadVisualPlugins(ReadModules());
			containerRegistry.RegisterInstance(plugins);
		}
		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			ModuleLoader.LoadModule(moduleCatalog, ReadModules());
		}

		private string[] ReadModules()
		{
			//var dir = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "modules");
			var dir = Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName);
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}

			var names = Directory.GetFiles(dir);
			return names.Where(x => x.Contains(".Modules.") && x.Contains(".dll")).ToArray();
		}
	}
}
