using MahorobaWare.Core.Constants;
using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Core.Mvvm;
using MahorobaWare.Modules.Chat.Views;
using MahorobaWare.Service.Proxy.Interface;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Titanium.Web.Proxy.EventArguments;

namespace MahorobaWare.Modules.Chat.ViewModels
{
	[RegionMemberLifetime(KeepAlive = false)]
	public class ChatLoginViewModel : RegionViewModelBase
	{
		private readonly IProxyServerService _ServerService;
		public ChatLoginViewModel(IRegionManager regionManager, IProxyServerService serverService) : base(regionManager)
		{
			_User = new ReactiveProperty<MahorobaLoginUser>().AddTo(Disposable);
			_ServerService = serverService;
			_User.Subscribe(_ => SwitchToTweetView());
			CancelCommand = new ReactiveCommand();
			CancelCommand.Subscribe(Cancel);
			_ServerService.NewProxy(8000);
			_ServerService.SetProxyRequestEventHandler(OnRequest);
			_ServerService.SetProxyResponseEventHandler(OnResponse);
			_ServerService.StartProxy();
		}

		private int _Count = 0;

		private int _ReqCount = 0;

		private string _Uidkey;
		private string _Token;
		private string _ServerId;

		private ReactiveProperty<MahorobaLoginUser> _User;
		public ReactiveCommand CancelCommand { get; }

		private void Cancel()
		{
			Application.Current.Dispatcher.BeginInvoke(new Action(() => RegionManager.RequestNavigate(RegionNames.MenuViewRegion, nameof(ChatList), NavigationComplete)));
		}

		private void SwitchToTweetView()
		{
			if (_User.Value == null) return;
			if (_Uidkey == null) return;
			if (_Token == null) return;


			var parameters = new NavigationParameters
			{
				{ "UiKey", _Uidkey },
				{ "Token", _Token },
				{ "ServerId", _ServerId },
				{ "User", _User.Value }
			};
			Application.Current.Dispatcher.BeginInvoke(new Action(() => RegionManager.RequestNavigate(RegionNames.MenuViewRegion, nameof(ChatList), NavigationComplete, parameters)));
		}
		private void NavigationComplete(NavigationResult result)
		{
			_ServerService.RemoveProxyResponseEventHandler(OnResponse);
			_ServerService.RemoveProxyRequestEventHandler(OnRequest);
			_ServerService.StopProxy();
			_ServerService.RemoveProxy();
			Dispose();
		}
		public override void OnNavigatedTo(NavigationContext navigationContext)
		{
		}


		public async Task OnResponse(object sender, SessionEventArgs e)
		{

			if (e.HttpClient.Request.RequestUri.ToString().Contains("http://osapi.dmm.com/gadgets/makeRequest"))
			{

				// read response headers
				var response = e.HttpClient.Response;
				if (e.HttpClient.Request.Method == "POST")
				{
					if (response.StatusCode == 200)
					{
						var test = JsonConvert.DeserializeObject<MakeRequest>(e.GetResponseBodyAsString().Result.Replace("throw 1; < don't be evil' >", ""));
						_Token = JsonConvert.DeserializeObject<List<string>>(test.DmmInfo.Body)[2];
					}
				}
			}

			if (e.HttpClient.Request.RequestUri.ToString().Contains("json-gateway.php"))
			{
				var data = e.GetResponseBodyAsString().Result;
				if (_Count == 0)
				{
					_Uidkey = UidSerialize.FromJson(data)[1].AnythingArray[2].String;
					//_Uidkey = JsonConvert.DeserializeObject<string[]>(test)[2];
				}
				else if (_Count == 1)
				{
					await Application.Current.Dispatcher.BeginInvoke(new Action(() => _User.Value = UserSerialize.FromJson(data)[1].AnythingArray[2].WelcomeClass));

				}
				_Count++;
			}
		}
		public async Task OnRequest(object sender, SessionEventArgs e)
		{
			if (e.HttpClient.Request.RequestUri.ToString().Contains("json-gateway.php"))
			{
				var data = e.GetRequestBodyAsString().Result;
				if (_Count == 1)
				{
					Match matchedObject = Regex.Match(data, @"param=.*?\]");
					_ServerId = matchedObject.Groups[0].Value.Replace("param=[", "").Replace("]", "").Replace("\"", "").Split(",")[0];
				}
				_ReqCount++;
			}
		}
	}
}
