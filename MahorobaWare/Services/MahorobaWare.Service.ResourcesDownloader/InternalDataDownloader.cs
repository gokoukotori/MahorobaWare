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
		private readonly WebClient _WebClient = new WebClient();
		private readonly IResolvePicIndexToUrl _ResolvePicIndexToUrl;
		private readonly Dictionary<int, dynamic> _Cache = new Dictionary<int, dynamic>();
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


		public Task<CfgChat[]> CfgChatAsync()
		{
			return Task.FromResult(CfgChat());
		}
		public CfgPartner[] CfgPartners()
		{
			CfgProfessions();
			List<CfgPartner> cfgData = new List<CfgPartner>();
			GetAllCfg();
			var data = ResolveCfgData("cfg_partner");

			foreach (var item in data)
			{
				//{[  "1",  "旧鼠",  "1|14,2|6,3|6,4|14",  "1|20.33,2|8.7,3|8.7,4|19.74",  "4001,4011",  "1",  "cha_00005",  "ほら、寝てないでさっさと冒険にいくの！ \nお日さまの下でアクティブに活動するの！|飯綱どこいったのー？\nきっとまたどっかで\n引きこもって寝てるの|ちゃんと食べてるのかなの？\n栄養のバランスも大事なの！\n妖怪は身体が資本なのー！",  "1",  "1001,100",  "3",  "",  "きゅうそ",  "5000",  "1",  "0",  "",  "4001,4011,0,0,0",  "0",  "地獄とかナワバリとか\nいろいろ大変だけど、とりあえず\nあたしがついてるの！|誰がちんちくりんなのー！\nこれでも昔は、大黒さまの使いを\nしてたことだってあるの！|外から見て狭い穴も、内側は広く\nなってたりするものなの。\n何事もやってみないとわからないの！",  "おせっかい焼きな鼠の妖怪。子猫を育てることに命をかけ、半ば無理やり猫又の面倒を見て育てあげた。猫又が自分のもとから巣立って以降は、同じネコ科の飯綱の面倒をみることにしたらしい。かばんの中には「ひみつ道具」が詰まっている。",  "0",  "旧鼠と、その仲間たちの大冒険\n報告するの！",  "1",  "1",  "213",  "ラ～ララ～♪ ラ～ララ～♪子守の事なら、旧鼠におまかせなの！",  "旧鼠",  "0"]}
				if (data[0] == item) continue;
				if (item == null) break;
				string partnerid = item[0];
				string name = item[1];
				string partnerbase = item[2];
				string upep = item[3];
				string skill = item[4];
				string mainp = item[5];
				string picindex = item[6];
				string text = item[7];
				string quality = item[8];
				string synthesis = item[9];
				string type = item[10];
				string kizina = item[11];
				string pinyin = item[12];
				string grown = item[13];
				string group = item[14];
				string avt = item[15];
				string cg = item[16];
				string skillgroup = item[17];
				string limit = item[18];
				string lines = item[19];
				string desc = item[20];
				string hide = item[21];
				string offline_report = item[21];
				string attribution = item[22];
				string pvp_enemy = item[23];
				string cg_reward = item[24];
				string gacha_lines = item[25];
				string gacha_name = item[26];
				string collection = item[27];
				cfgData.Add(new CfgPartner(partnerid, name, partnerbase, upep, skill, mainp, picindex, text, quality, synthesis, type, kizina, pinyin, grown, group, avt, cg, skillgroup, limit, lines, desc, hide, offline_report, attribution, pvp_enemy, cg_reward, gacha_lines, gacha_name, collection));
			}

			return cfgData.ToArray();
		}


		public Task<CfgPartner[]> CfgPartnersAsync()
		{
			return Task.FromResult(CfgPartners());
		}

		public CfgProfession[] CfgProfessions()
		{
			List<CfgProfession> cfgData = new List<CfgProfession>();
			GetAllCfg();
			var data = ResolveCfgData("cfg_profession");

			foreach (var item in data)
			{
				//{[  "1",  "強行",  "しばらく寝ている間に\n世界が随分と\n変わっちゃいましたね、主様？|主様の好物、調達いたしましたよ。\nふふっ、夕餉は楽しみに\nしておいてくださいね。|今どきの機械？ とかいう\nからくりはどう操作すれば\nいいのかわかりませんね……",  "主様！ 報告させていただきます！",  "主様、いかがなさいますか？\nわたしは主様にどこまでも\nついてまいります！|今の時代の文化に\n少しずつでも\n慣れていかないと……。|主様はわたしを見つけてくれた\nとてもとても……\n大切な人です。",  "力を象徴する、鬼人を顕現した式神。\n豪腕からくり出す一振りは、空を裂き断ち、\n強敵をも圧倒する。"]}
				if (data[0] == item) continue;
				if (item == null) break;

				string pid = item[0];
				string name = item[1];
				string text = item[2];
				string offline_report = item[3];
				string lines = item[4];
				string desc = item[5];
				cfgData.Add(new CfgProfession(pid, name, text, offline_report, lines, desc));
			}

			return cfgData.ToArray();
		}


		public Task<CfgProfession[]> CfgProfessionsAsync()
		{
			return Task.FromResult(CfgProfessions());
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
