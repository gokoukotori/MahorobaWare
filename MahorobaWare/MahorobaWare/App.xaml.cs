using Prism.Ioc;
using MahorobaWare.Views;
using System.Windows;
using Prism.Modularity;
using MahorobaWare.Modules.Base;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using MahorobaWare.Core.Module;
using MahorobaWare.Service.ServerState.Interface;
using MahorobaWare.Service.ServerState;
using MahorobaWare.Modules.StateView;
using MahorobaWare.Service.Proxy.Interface;
using MahorobaWare.Service.Proxy;
using MahorobaWare.Modules.Chat;
using MahorobaWare.Service.WebSoccket.Interface;
using MahorobaWare.Service.WebSoccket;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using MahorobaWare.Service.ResourcesDownloader;

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
			containerRegistry.RegisterSingleton<IServerState, ServerState>();
			containerRegistry.Register<IProxyServerService, ProxyServerService>();
			containerRegistry.RegisterSingleton<IChatServerService, ChatServerService>();
			containerRegistry.RegisterSingleton<IResolvePicIndexToUrl, ResolvePicIndexToUrl>();

			var list = new List<string>
			{
				Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "MahorobaWare.Modules.Base.dll"),
				Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "MahorobaWare.Modules.StateView.dll"),
				Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "MahorobaWare.Modules.Chat.dll")
			};
			var plugins = ModuleLoader.LoadVisualPlugins(list.ToArray());
			containerRegistry.RegisterInstance(plugins);
		}

		protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
		{
			moduleCatalog.AddModule<BaseModule>();
			moduleCatalog.AddModule<StateViewModule>();
			moduleCatalog.AddModule<ChatModule>();
			var list = new List<string>
			{
				//Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "MahorobaWare.Modules.StateView.dll"),
				//Path.Combine(Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName, "MahorobaWare.Modules.BaseModule.dll")
			};
			ModuleLoader.LoadModule(moduleCatalog, list.ToArray());
		}
	}
}
