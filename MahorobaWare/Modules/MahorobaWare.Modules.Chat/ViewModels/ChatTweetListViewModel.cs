using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using MahorobaWare.Service.ServerState.Interface;
using MahorobaWare.Service.WebSoccket.Interface;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using WebSocketSharp;

namespace MahorobaWare.Modules.Chat.ViewModels
{
	public class ChatTweetListViewModel : RegionViewModelBase
	{
		private IResolvePicIndexToUrl _Resolve;
		private string _UiKey;
		private string _Token;
		private string _ServerId;
		private MahorobaLoginUser _User;
		private bool _IsGlobal;
		private IChatServerService _ChatServer;
		private IServerState _ServerState;
		public ReactiveCollection<TweetData> Tweets { get; set; }

		public ChatTweetListViewModel(IRegionManager regionManager, IChatServerService chatServer, IServerState serverState, IResolvePicIndexToUrl resolve) : base(regionManager)
		{
			_Resolve = resolve;
			_ChatServer = chatServer;
			_ServerState = serverState;
			Tweets = new ReactiveCollection<TweetData>();
			ServerName = new ReactiveProperty<string>();
		}
		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
			if (navigationContext.Parameters["UiKey"] is string uiKey)
			{
				_UiKey = uiKey;
			}
			if (navigationContext.Parameters["Token"] is string token)
			{
				_Token = token;
			}
			if (navigationContext.Parameters["ServerId"] is string serverId)
			{
				_ServerId = serverId;
			}
			if (navigationContext.Parameters["User"] is MahorobaLoginUser user)
			{
				_User = user;
			}
			if (navigationContext.Parameters["IsGlobal"] is bool isGlobal)
			{
				_IsGlobal = isGlobal;
			}
			Start();
			if (!_IsGlobal)
			{
				ServerName.Value = _ServerState.GetServerState(int.Parse(_ServerId) -1 ).Name;
			}
			else
			{
				ServerName.Value = "全サーバー";
			}
		}

		public ReactiveProperty<string> ServerName { get; }
		public override bool IsNavigationTarget(NavigationContext navigationContext)
		{
			return false;
		}
		public void ChatAuth()
		{

			var data = new TweetAuthData()
			{
				Uid = long.Parse(_User.Uid),
				Sid = _ServerId,
				Token = _Token,
				Reconnect = 0,
				HeadIndex = "2",
				Vip = long.Parse(_User.Vip),
				VipHide = long.Parse(_User.VipHide),
				Uname = _User.Uname,
				Uidkey = _UiKey
			};
			var auth = new TweetAuth()
			{
				Type = 1,
				Data = data
			};
			_ChatServer.ChatAuth(_ServerId, auth);

		}

		// スタート時ｎ呼ばれる
		private void Start()
		{
			_ChatServer.NewSoccket(_ServerId);
			// サーバからのデータ受信時に呼ばれる
			_ChatServer.AddOnMessage(_ServerId, (sender, e) =>
			{
				try
				{
					if (e.IsText)
					{
						var tweet = TweetSerialize.FromJson(e.Data);
						var utf = Encoding.UTF8.GetString(e.RawData);
						if (tweet.TweetData != null)
						{
							tweet.TweetData.HeadIndex = _Resolve.GetCharacterHeadIcon(tweet.TweetData.HeadIndex).ToString();
							if (_IsGlobal)
							{
								if (tweet.TweetData.Channel == 1) Tweets.AddOnScheduler(tweet.TweetData);
							}
							else
							{
								if (tweet.TweetData.Channel == 2) Tweets.AddOnScheduler(tweet.TweetData);
							}
						}
					}
				}
				catch
				{

				}
			});


			if (!_IsGlobal)
			{
				// クローズ時に呼ばれる
				_ChatServer.AddOnClose(_ServerId, (sender, e) =>
				{
					_ChatServer.Connect(_ServerId);
					ChatAuth();
				});

				// エラー時に呼ばれる
				_ChatServer.AddOnError(_ServerId, (sender, e) =>
				{
					_ChatServer.Connect(_ServerId);
					ChatAuth();
				});
				// 接続
				_ChatServer.Connect(_ServerId);
				ChatAuth();
			}
		}


		// 破棄時に呼ばれる
		private void OnDestroy()
		{
			_ChatServer.Disconnect(_ServerId);
		}
	}
}
