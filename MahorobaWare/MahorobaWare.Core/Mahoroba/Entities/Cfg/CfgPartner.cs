using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Cfg
{
	public class CfgPartner
	{
		public CfgPartner(string partnerid, string name, string partnerbase, string upep, string skill, string mainp, string picindex, string text, string quality, string synthesis, string type, string kizina, string pinyin, string grown, string group, string avt, string cg, string skillgroup, string limit, string lines, string desc, string hide, string offline_report, string attribution, string pvp_enemy, string cg_reward, string gacha_lines, string gacha_name, string collection)
		{
			Partnerid = partnerid;
			Name = name;
			Partnerbase = partnerbase;
			Upep = upep;
			Skill = skill;
			Mainp = mainp;
			Picindex = picindex;
			Text = text;
			Quality = quality;
			Synthesis = synthesis;
			Type = type;
			Kizina = kizina;
			Pinyin = pinyin;
			Grown = grown;
			Group = group;
			Avt = avt;
			Cg = cg;
			Skillgroup = skillgroup;
			Limit = limit;
			Lines = lines;
			Desc = desc;
			Hide = hide;
			Offline_report = offline_report;
			Attribution = attribution;
			Pvp_enemy = pvp_enemy;
			Cg_reward = cg_reward;
			Gacha_lines = gacha_lines;
			Gacha_name = gacha_name;
			Collection = collection;
		}

		public string Partnerid { get; set; }
		public string Name { get; set; }
		public string Partnerbase { get; set; }
		public string Upep { get; set; }
		public string Skill { get; set; }
		public string Mainp { get; set; }
		public string Picindex { get; set; }
		public string Text { get; set; }
		public string Quality { get; set; }
		public string Synthesis { get; set; }
		public string Type { get; set; }
		public string Kizina { get; set; }
		public string Pinyin { get; set; }
		public string Grown { get; set; }
		public string Group { get; set; }
		public string Avt { get; set; }
		public string Cg { get; set; }
		public string Skillgroup { get; set; }
		public string Limit { get; set; }
		public string Lines { get; set; }
		public string Desc { get; set; }
		public string Hide { get; set; }
		public string Offline_report { get; set; }
		public string Attribution { get; set; }
		public string Pvp_enemy { get; set; }
		public string Cg_reward { get; set; }
		public string Gacha_lines { get; set; }
		public string Gacha_name { get; set; }
		public string Collection { get; set; }
	}
}
