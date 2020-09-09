using MahorobaWare.Core.Mahoroba.Entities.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebSocketSharp;

namespace MahorobaWare.Service.WebSoccket.Interface
{
	public interface IChatServerService
	{
		public void NewSoccket(string serverId);


		public void Connect(string serverId);

		public void Disconnect(string serverId);

		public void ChatAuth(string serverId, TweetAuth auth);
		public void SendMessage(string serverId);

		public void AddOnClose(string serverId, EventHandler<CloseEventArgs> @event);
		public void AddOnError(string serverId, EventHandler<ErrorEventArgs> @event);
		public void AddOnMessage(string serverId, EventHandler<MessageEventArgs> @event);
		public void AddOnOpen(string serverId, EventHandler @event);
		public void RemoveOnClose(string serverId, EventHandler<CloseEventArgs> @event);
		public void RemoveOnError(string serverId, EventHandler<ErrorEventArgs> @event);
		public void RemoveOnMessage(string serverId, EventHandler<MessageEventArgs> @event);
		public void RemoveOnOpen(string serverId, EventHandler @event);
	}
}
