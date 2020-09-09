using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{
		public class MahorobaLoginUser
		{
			[JsonProperty("uid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Uid { get; set; }

			[JsonProperty("u_number", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string UNumber { get; set; }

			[JsonProperty("uname", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Uname { get; set; }

			[JsonProperty("ucoin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Ucoin { get; set; }

			[JsonProperty("ulv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Ulv { get; set; }

			[JsonProperty("uexp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Uexp { get; set; }

			[JsonProperty("upower", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Upower { get; set; }

			[JsonProperty("setuptime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Setuptime { get; set; }

			[JsonProperty("loginday", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Loginday { get; set; }

			[JsonProperty("uptime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Uptime { get; set; }

			[JsonProperty("umid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Umid { get; set; }

			[JsonProperty("ug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public long? Ug { get; set; }

			[JsonProperty("ujob", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Ujob { get; set; }

			[JsonProperty("step", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Step { get; set; }

			[JsonProperty("s1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string S1 { get; set; }

			[JsonProperty("s2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string S2 { get; set; }

			[JsonProperty("pvetime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Pvetime { get; set; }

			[JsonProperty("partnerskill", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Partnerskill { get; set; }

			[JsonProperty("pvb", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Pvb { get; set; }

			[JsonProperty("pvbbuy", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Pvbbuy { get; set; }

			[JsonProperty("nowmid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Nowmid { get; set; }

			[JsonProperty("winrate", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Winrate { get; set; }

			[JsonProperty("winrand", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Winrand { get; set; }

			[JsonProperty("wincoin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Wincoin { get; set; }

			[JsonProperty("winexp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Winexp { get; set; }

			[JsonProperty("winequip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Winequip { get; set; }

			[JsonProperty("sellstar", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Sellstar { get; set; }

			[JsonProperty("selljob", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Selljob { get; set; }

			[JsonProperty("sex", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Sex { get; set; }

			[JsonProperty("zhanli", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Zhanli { get; set; }

			[JsonProperty("vip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Vip { get; set; }

			[JsonProperty("vippay", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Vippay { get; set; }

			[JsonProperty("forgepoint", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Forgepoint { get; set; }

			[JsonProperty("forgestar", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Forgestar { get; set; }

			[JsonProperty("forgeid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Forgeid { get; set; }

			[JsonProperty("bag", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Bag { get; set; }

			[JsonProperty("pvequick", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Pvequick { get; set; }

			[JsonProperty("pvp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Pvp { get; set; }

			[JsonProperty("forgereset", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Forgereset { get; set; }

			[JsonProperty("forgets", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Forgets { get; set; }

			[JsonProperty("refreshtime", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Refreshtime { get; set; }

			[JsonProperty("buycoin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Buycoin { get; set; }

			[JsonProperty("sig", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Sig { get; set; }

			[JsonProperty("mail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Mail { get; set; }

			[JsonProperty("uluck", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Uluck { get; set; }

			[JsonProperty("nowchid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Nowchid { get; set; }

			[JsonProperty("nowmidts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Nowmidts { get; set; }

			[JsonProperty("renamets", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Renamets { get; set; }

			[JsonProperty("senior", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Senior { get; set; }

			[JsonProperty("seniorexp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Seniorexp { get; set; }

			[JsonProperty("seniorstar", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Seniorstar { get; set; }

			[JsonProperty("senior1", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Senior1 { get; set; }

			[JsonProperty("suit", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Suit { get; set; }

			[JsonProperty("suit2", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Suit2 { get; set; }

			[JsonProperty("eid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Eid { get; set; }

			[JsonProperty("maxlv", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Maxlv { get; set; }

			[JsonProperty("favorite", Required = Required.AllowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Favorite { get; set; }

			[JsonProperty("soul_coin", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string SoulCoin { get; set; }

			[JsonProperty("base", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Base { get; set; }

			[JsonProperty("upep", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string Upep { get; set; }

			[JsonProperty("buy_pvb_now", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string BuyPvbNow { get; set; }

			[JsonProperty("payug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Payug { get; set; }

			[JsonProperty("spirit_gvg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string SpiritGvg { get; set; }

			[JsonProperty("re_soul_nums", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string ReSoulNums { get; set; }

			[JsonProperty("re_soul_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string ReSoulTime { get; set; }

			[JsonProperty("shop_reward_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string ShopRewardAt { get; set; }

			[JsonProperty("re_soul_time_auto", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string ReSoulTimeAuto { get; set; }

			[JsonProperty("is_put_gvg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string IsPutGvg { get; set; }

			[JsonProperty("refresh_travel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string RefreshTravel { get; set; }

			[JsonProperty("active_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string ActiveTime { get; set; }

			[JsonProperty("partner_nums", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string PartnerNums { get; set; }

			[JsonProperty("avatar", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Avatar { get; set; }

			[JsonProperty("pvb_nums_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string PvbNumsAt { get; set; }

			[JsonProperty("create_at", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string CreateAt { get; set; }

			[JsonProperty("first_charge_reward", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string FirstChargeReward { get; set; }

			[JsonProperty("team_zhanli", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string TeamZhanli { get; set; }

			[JsonProperty("free_bonusstage_pvb", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string FreeBonusstagePvb { get; set; }

			[JsonProperty("skill_attr_per", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string SkillAttrPer { get; set; }

			[JsonProperty("evil_attr_per", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string EvilAttrPer { get; set; }

			[JsonProperty("grown_attr", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string GrownAttr { get; set; }

			[JsonProperty("grow", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Grow { get; set; }

			[JsonProperty("gid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Gid { get; set; }

			[JsonProperty("grade_exp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string GradeExp { get; set; }

			[JsonProperty("left_exp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string LeftExp { get; set; }

			[JsonProperty("is_robot", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string IsRobot { get; set; }

			[JsonProperty("vip_progress", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string VipProgress { get; set; }

			[JsonProperty("refresh_time", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string RefreshTime { get; set; }

			[JsonProperty("ts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string Ts { get; set; }

			[JsonProperty("vip_hide", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string VipHide { get; set; }

			[JsonProperty("dmm_ug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string DmmUg { get; set; }

			[JsonProperty("ios_ug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string IosUg { get; set; }

			[JsonProperty("google_ug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string GoogleUg { get; set; }

			[JsonProperty("free_ug", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string FreeUg { get; set; }

			[JsonProperty("pve_card_use", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string PveCardUse { get; set; }

			[JsonProperty("guide_id_now", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string GuideIdNow { get; set; }

			[JsonProperty("pvp_max_winning_streak", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string PvpMaxWinningStreak { get; set; }

			[JsonProperty("buy_pvp_nums", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]

			public string BuyPvpNums { get; set; }

			[JsonProperty("buy_pvp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string BuyPvp { get; set; }

			[JsonProperty("free_pve_quick", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string FreePveQuick { get; set; }

			[JsonProperty("is_debuger", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string IsDebuger { get; set; }

			[JsonProperty("free_pve_quick_buff", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public string FreePveQuickBuff { get; set; }

			[JsonProperty("is_gvg_opened", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public bool? IsGvgOpened { get; set; }

			[JsonProperty("rein_num", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
			public long? ReinNum { get; set; }
	}
	public struct UserGeneral1
	{
		public long? Integer;
		public MahorobaLoginUser WelcomeClass;

		public static implicit operator UserGeneral1(long Integer) => new UserGeneral1 { Integer = Integer };
		public static implicit operator UserGeneral1(MahorobaLoginUser WelcomeClass) => new UserGeneral1 { WelcomeClass = WelcomeClass };
	}

	public struct UserGeneral2
	{
		public List<UserGeneral1> AnythingArray;
		public long? Integer;

		public static implicit operator UserGeneral2(List<UserGeneral1> AnythingArray) => new UserGeneral2 { AnythingArray = AnythingArray };
		public static implicit operator UserGeneral2(long Integer) => new UserGeneral2 { Integer = Integer };
	}
	public static class UserSerialize
	{
		public static List<UserGeneral2> FromJson(string json) => JsonConvert.DeserializeObject<List<UserGeneral2>>(json, UserConverter.Settings);
		public static string ToJson(this List<UserGeneral2> self) => JsonConvert.SerializeObject(self, UserConverter.Settings);
	}

	internal static class UserConverter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				UserGeneral2Converter.Singleton,
				UserGeneral1Converter.Singleton,
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
	internal class UserGeneral2Converter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(UserGeneral2) || t == typeof(UserGeneral2?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Integer:
					var integerValue = serializer.Deserialize<long>(reader);
					return new UserGeneral2 { Integer = integerValue };
				case JsonToken.StartArray:
					var arrayValue = serializer.Deserialize<List<UserGeneral1>>(reader);
					return new UserGeneral2 { AnythingArray = arrayValue };
			}
			throw new Exception("Cannot unmarshal type UserGeneral2");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (UserGeneral2)untypedValue;
			if (value.Integer != null)
			{
				serializer.Serialize(writer, value.Integer.Value);
				return;
			}
			if (value.AnythingArray != null)
			{
				serializer.Serialize(writer, value.AnythingArray);
				return;
			}
			throw new Exception("Cannot marshal type UserGeneral2");
		}

		public static readonly UserGeneral2Converter Singleton = new UserGeneral2Converter();
	}

	internal class UserGeneral1Converter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(UserGeneral1) || t == typeof(UserGeneral1?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Integer:
					var integerValue = serializer.Deserialize<long>(reader);
					return new UserGeneral1 { Integer = integerValue };
				case JsonToken.StartObject:
					var objectValue = serializer.Deserialize<MahorobaLoginUser>(reader);
					return new UserGeneral1 { WelcomeClass = objectValue };
			}
			throw new Exception("Cannot unmarshal type UserGeneral1");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (UserGeneral1)untypedValue;
			if (value.Integer != null)
			{
				serializer.Serialize(writer, value.Integer.Value);
				return;
			}
			if (value.WelcomeClass != null)
			{
				serializer.Serialize(writer, value.WelcomeClass);
				return;
			}
			throw new Exception("Cannot marshal type UserGeneral1");
		}

		public static readonly UserGeneral1Converter Singleton = new UserGeneral1Converter();
	}

}
