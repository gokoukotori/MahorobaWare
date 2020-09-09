using MahorobaWare.Core.Mahoroba.Entities.Json;
using MahorobaWare.Service.ServerState.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MahorobaWare.Service.ServerState
{
	public class ServerState : IServerState
	{
		private static readonly string BASE_URL = "https://prd-main.sakura.fusion-studio.co.jp:7001/serverconfig_dev.php?func=serverlist";
		public IReadOnlyList<Server> GetAllServerState() => GetServersState();
		public Server GetServerState(int serverId) => GetServersState(serverId).First();

		private IReadOnlyList<Server> GetServersState(int? serverId = null)
		{
			using var client = new WebClient();
			var binary = client.DownloadData(BASE_URL);
			var json = Encoding.UTF8.GetString(binary);
			var list = JsonConvert.DeserializeObject<ServerList>(json);
			if (serverId.HasValue)
			{
				return new List<Server> { list.Serverlist[serverId.Value] };
			}
			return list.Serverlist;

		}
	}
}
