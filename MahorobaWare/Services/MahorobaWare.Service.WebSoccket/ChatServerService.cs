using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Service.WebSoccket.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace MahorobaWare.Service.WebSoccket
{
	public class ChatServerService : IChatServerService
	{
		private static readonly Dictionary<string, WebSocket> _WsList = new Dictionary<string, WebSocket>();

		public void NewSoccket(string serverId)
		{
			if (_WsList.ContainsKey(serverId)) return;
			_WsList.Add(serverId, new WebSocket("wss://prd-main.sakura.fusion-studio.co.jp:5002"));
		}


		public void Connect(string serverId)
		{
			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].Connect();
		}

		public void Disconnect(string serverId)
		{
			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].Close();
			_WsList[serverId] = null;
			_WsList.Remove(serverId);
		}

		public void ChatAuth(string serverId, TweetAuth auth)
		{
			if (!_WsList.ContainsKey(serverId)) return;
			var json = auth.ToJson();
			_WsList[serverId].Send(Encoding.UTF8.GetBytes(json));
		}
		public void SendMessage(string serverId)
		{

		}

		public void AddOnClose(string serverId, EventHandler<CloseEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnClose += @event;
		}
		public void AddOnError(string serverId, EventHandler<ErrorEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnError += @event;
		}
		public void AddOnMessage(string serverId, EventHandler<MessageEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnMessage += @event;
		}

		public void AddOnOpen(string serverId, EventHandler @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnOpen += @event;
		}
		public void RemoveOnClose(string serverId, EventHandler<CloseEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnClose -= @event;
		}
		public void RemoveOnError(string serverId, EventHandler<ErrorEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnError -= @event;
		}
		public void RemoveOnMessage(string serverId, EventHandler<MessageEventArgs> @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnMessage -= @event;
		}
		public void RemoveOnOpen(string serverId, EventHandler @event)
		{

			if (!_WsList.ContainsKey(serverId)) return;
			_WsList[serverId].OnOpen -= @event;
		}
	}
}
