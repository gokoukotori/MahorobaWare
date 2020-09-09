using MahorobaWare.Modules.Chat.Views;
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
			containerRegistry.RegisterForNavigation<ChatTweetList>();
			containerRegistry.RegisterForNavigation<ChatTweet>();
			containerRegistry.RegisterForNavigation<ChatList>();
			containerRegistry.RegisterForNavigation<ChatLogin>();
		}
	}
}
