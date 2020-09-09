using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace MahorobaWare.Modules.Chat.ViewModels
{
	public class ChatListViewModel : RegionViewModelBase
	{
		public ChatListViewModel(IRegionManager regionManager) : base(regionManager)
		{
			AddServerChatCommand = new ReactiveCommand();
			AddServerChatCommand.Subscribe(AddServerChat);
		}

		private void AddServerChat()
		{
			RegionManager.RequestNavigate(RegionNames.MenuViewRegion, "ChatLogin");
		}

		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
			IRegion region = RegionManager.Regions["TweetListRegion"];
			if (navigationContext.Parameters["UiKey"] is string uiKey && navigationContext.Parameters["Token"] is string token && navigationContext.Parameters["ServerId"] is string serverId && navigationContext.Parameters["User"] is MahorobaLoginUser user)
			{
				if(region.Views.Count() == 0){
					var gparameters = new NavigationParameters
					{
						{ "UiKey", uiKey },
						{ "Token", token },
						{ "ServerId", serverId },
						{ "User", user },
						{ "IsGlobal", true }
					};
					Application.Current.Dispatcher.BeginInvoke(new Action(() => RegionManager.RequestNavigate("TweetListRegion", "ChatTweetList", gparameters)));
				}
				var parameters = new NavigationParameters
				{
					{ "UiKey", uiKey },
					{ "Token", token },
					{ "ServerId", serverId },
					{ "User", user },
					{ "IsGlobal", false }
				};
				Application.Current.Dispatcher.BeginInvoke(new Action(() => RegionManager.RequestNavigate("TweetListRegion", "ChatTweetList", parameters)));


			}else if (region.Views.Count() == 0)
			{
				RegionManager.RequestNavigate(RegionNames.MenuViewRegion, "ChatLogin");
			}
		}

		public ReactiveCommand AddServerChatCommand { get; }
	}
}
