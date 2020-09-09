using MahorobaWare.Core.Extensions;
using MahorobaWare.Core.Plugin;
using MahorobaWare.Core.Plugin.Interface;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MahorobaWare.Core.Module
{
	public static class ModuleLoader
	{
		public static IModuleCatalog LoadModule(IModuleCatalog catalog, params string[] modulePaths)
		{
			foreach (var item in modulePaths)
			{
				var asm = Assembly.LoadFrom(item);
				var prismModule = asm.GetInterfaces<IModule>()[0];
				catalog.AddModule(new ModuleInfo()
				{
					ModuleName = prismModule.Name,
					ModuleType = prismModule.AssemblyQualifiedName,
					InitializationMode = InitializationMode.WhenAvailable
				});


			}
			return catalog;
		}


		public static IVisualPlugins LoadVisualPlugins(params string[] modulePaths)
		{
			var list = new VisualPlugins();
			foreach (var item in modulePaths)
			{
				var asm = Assembly.LoadFrom(item);
				var prismModule = asm.CreateInterfaceInstances<IVisualPlugin>()[0];

				list.Add(prismModule);

			}
			return list;
		}
	}
}
