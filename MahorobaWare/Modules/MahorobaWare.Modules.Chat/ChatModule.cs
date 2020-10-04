using MahorobaWare.Core.Module;
using MahorobaWare.Modules.Chat.Views;
using MahorobaWare.Service.Proxy.Interface;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using MahorobaWare.Service.ServerState.Interface;
using MahorobaWare.Service.WebSoccket.Interface;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace MahorobaWare.Modules.Chat
{
	public class ChatModule : IModule
	{
		private readonly IRegionManager _regionManager;

		public ChatModule(IRegionManager regionManager)
		{
			_regionManager = regionManager;
		}
		public void OnInitialized(IContainerProvider containerProvider)
		{
		}

		public void RegisterTypes(IContainerRegistry containerRegistry)
		{
			if (!containerRegistry.IsRegistered<IServerState>())
			{
				containerRegistry.RegisterSingleton(typeof(IServerState), ServiceLoader.LoadService(typeof(IServerState)));
			}

			if (!containerRegistry.IsRegistered<IResolvePicIndexToUrl>())
			{
				containerRegistry.RegisterSingleton(typeof(IResolvePicIndexToUrl), ServiceLoader.LoadService(typeof(IResolvePicIndexToUrl)));
			}

			if (!containerRegistry.IsRegistered<IChatServerService>())
			{
				containerRegistry.RegisterSingleton(typeof(IChatServerService), ServiceLoader.LoadService(typeof(IChatServerService)));
			}

			if (!containerRegistry.IsRegistered<IProxyServerService>())
			{
				containerRegistry.RegisterSingleton(typeof(IProxyServerService), ServiceLoader.LoadService(typeof(IProxyServerService)));
			}

			containerRegistry.RegisterForNavigation<ChatTweetList>();
			containerRegistry.RegisterForNavigation<ChatTweet>();
			containerRegistry.RegisterForNavigation<ChatList>();
			containerRegistry.RegisterForNavigation<ChatLogin>();
		}
	}
}
