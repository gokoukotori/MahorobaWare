using MahorobaWare.Service.ResourcesDownloader.Interface;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Ionic.Zlib;
using Newtonsoft.Json.Linq;
using System.Linq;
using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using System.Threading.Tasks;

namespace MahorobaWare.Service.ResourcesDownloader
{
	public class InternalDataDownloader : IInternalDataDownloader
	{
		private WebClient _WebClient = new WebClient();
		private IResolvePicIndexToUrl _ResolvePicIndexToUrl;
		private Dictionary<int, dynamic> _Cache = new Dictionary<int, dynamic>();
		public InternalDataDownloader(IResolvePicIndexToUrl resolvePicIndexToUrl)
		{
			_ResolvePicIndexToUrl = resolvePicIndexToUrl;
		}

		public dynamic CfgData(int dataNum)
		{
			if (_Cache.TryGetValue(dataNum, out dynamic value)) return value;
			var url = _ResolvePicIndexToUrl.GetCfgDataThe(dataNum);

			var binary = _WebClient.DownloadData(url);

			var bytes = ZlibStream.UncompressBuffer(binary);
			var str = Encoding.UTF8.GetString(bytes);
			dynamic blog = JObject.Parse(str);
			_Cache.Add(dataNum, blog);
			return blog;
		}

		public CfgChat[] CfgChat()
		{
			List<CfgChat> cfgChats = new List<CfgChat>();
			GetAllCfg();
			var chat = ResolveCfgData("cfg_chat");

			foreach (var item in chat)
			{
				//{[  "1",  "emoj_00001",  "0"]}
				if (chat[0] == item) continue;
				if (item == null) break;
				string sid = item[0];
				string chati = item[1];
				string pid = item[2];
				cfgChats.Add(new CfgChat(sid, chati, pid));
			}

			return cfgChats.ToArray();
		}


		public Task<dynamic> CfgDataAsync(int dataNum)
		{
			if (_Cache.TryGetValue(dataNum, out dynamic value)) return value;
			var url = _ResolvePicIndexToUrl.GetCfgDataThe(dataNum);

			var binary = _WebClient.DownloadData(url);

			var bytes = ZlibStream.UncompressBuffer(binary);
			var str = Encoding.UTF8.GetString(bytes);
			dynamic blog = JObject.Parse(str);
			_Cache.Add(dataNum, blog);
			return blog;
		}

		public Task<CfgChat[]> CfgChatAsync()
		{
			List<CfgChat> cfgChats = new List<CfgChat>();
			GetAllCfg();
			var chat = ResolveCfgData("cfg_chat");

			foreach (var item in chat)
			{
				//{[  "1",  "emoj_00001",  "0"]}
				if (chat[0] == item) continue;
				if (item == null) break;
				string sid = item[0];
				string chati = item[1];
				string pid = item[2];
				cfgChats.Add(new CfgChat(sid, chati, pid));
			}

			return Task.FromResult(cfgChats.ToArray());
		}

		private Task GetAllCfg()
		{
			CfgData(1);
			CfgData(2);
			CfgData(3);
			CfgData(4);
			CfgData(5);
			return Task.CompletedTask;
		}

		private dynamic ResolveCfgData(string name)
		{
			foreach (var item in _Cache)
			{
				if (item.Value[name] == null) continue;
				return item.Value[name];
			}
			return null;
		}
	}
}
