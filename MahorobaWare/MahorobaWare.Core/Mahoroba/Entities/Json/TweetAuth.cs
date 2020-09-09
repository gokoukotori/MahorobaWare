using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{
	public class TweetAuth
	{
		[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Type { get; set; }

		[JsonProperty("data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public TweetAuthData Data { get; set; }
	}
	public class TweetAuthData
	{
		[JsonProperty("uid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Uid { get; set; }

		[JsonProperty("sid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Sid { get; set; }

		[JsonProperty("uidkey", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Uidkey { get; set; }

		[JsonProperty("token", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Token { get; set; }

		[JsonProperty("reconnect", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Reconnect { get; set; }

		[JsonProperty("head_index", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string HeadIndex { get; set; }

		[JsonProperty("vip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Vip { get; set; }

		[JsonProperty("vip_hide", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? VipHide { get; set; }

		[JsonProperty("uname", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Uname { get; set; }
	}

	public static class TweetAuthSerialize
	{
		public static TweetAuth FromJson(string json) => JsonConvert.DeserializeObject<TweetAuth>(json, TweetAuthConverter.Settings);
		public static string ToJson(this TweetAuth self) => JsonConvert.SerializeObject(self, TweetAuthConverter.Settings);
	}

	internal static class TweetAuthConverter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}
}
