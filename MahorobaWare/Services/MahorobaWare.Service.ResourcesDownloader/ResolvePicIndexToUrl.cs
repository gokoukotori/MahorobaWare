using MahorobaWare.Service.ResourcesDownloader.Interface;
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
		private const string BASE_URL = "https://cdn-static.prd.sakura.fusion-studio.co.jp/1.2.0/resources/";
		public Uri GetCharacterHeadIcon(string picIndex)
		{
			if (picIndex.Contains("avt")) return new Uri("");
			picIndex = picIndex.Replace("cha_", "");
			picIndex = string.Format("{0:D5}", int.Parse(picIndex));
			return new Uri(BASE_URL + ConvertToMD5("player_info_head/cha_head_" + picIndex + ".png") + ".png");
		}
		private static string ConvertToMD5(string text)
		{
			//文字列をbyte型配列に変換する
			byte[] data = Encoding.UTF8.GetBytes(text);

			MD5 md5 = MD5.Create();

			//ハッシュ値を計算する
			byte[] bs = md5.ComputeHash(data);

			//リソースを解放する
			md5.Clear();

			//byte型配列を16進数の文字列に変換
			return BitConverter.ToString(bs).ToLower().Replace("-", "");
		}
	}
}
