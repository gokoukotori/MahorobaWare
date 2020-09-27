﻿using MahorobaWare.Core.Mahoroba.Entities.Cfg;
using MahorobaWare.Service.ResourcesDownloader.Interface;
using MahorobaWare.Service.ServerState.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MahorobaWare.Service.ResourcesDownloader
{
	public class ResolvePicIndexToUrl : IResolvePicIndexToUrl
	{
		private string BASE_URL = "https://cdn-static.prd.sakura.fusion-studio.co.jp/1.3.0/resources/";

		public ResolvePicIndexToUrl(IServerState serverState)
		{
			BASE_URL = serverState.GetServerState(1).ResourceUrl.ToString();
		}

		public Uri GetCharacterHeadIcon(string picIndex)
		{
			if (picIndex.Contains("avt")) return new Uri("");
			picIndex = picIndex.Replace("cha_", "");
			picIndex = string.Format("{0:D5}", int.Parse(picIndex));
			return new Uri(BASE_URL + ConvertToMD5("player_info_head/cha_head_" + picIndex + ".png") + ".png");
		}
		public Uri GetCfgDataThe(int num)
		{
			if (num < 0 && 6 < num) return new Uri("");
			var res = "data/cfg" + num + "_high.json";
			return new Uri(BASE_URL + ConvertToMD5(res) + ".json");
		}

		public Uri[] GetStamps(params CfgChat[] chat)
		{
			var list = new List<Uri>();
			foreach (var item in chat)
			{
				list.Add(new Uri(BASE_URL + ConvertToMD5("chat/" + item.Chat + ".png") + ".png"));
			}
			return list.ToArray();
		}

		private static string ConvertToMD5(string text)
		{
			//文字列をbyte型配列に変換する
			byte[] data = Encoding.UTF8.GetBytes(text);

#pragma warning disable SCS0006 // Weak hashing function
			MD5 md5 = MD5.Create();
#pragma warning restore SCS0006 // Weak hashing function

			//ハッシュ値を計算する
			byte[] bs = md5.ComputeHash(data);

			//リソースを解放する
			md5.Clear();

			//byte型配列を16進数の文字列に変換
			return BitConverter.ToString(bs).ToLower().Replace("-", "");
		}
	}
}
