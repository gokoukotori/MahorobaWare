using MahorobaWare.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{
	public class Tweet
	{
		[JsonProperty("error_code", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? ErrorCode { get; set; }

		[JsonProperty("type", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Type { get; set; }

		[JsonProperty("data", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public TweetData TweetData { get; set; }

		[JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; set; }
	}

	public class TweetData
	{
		[JsonProperty("channel", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Channel { get; set; }

		[JsonProperty("uid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Uid { get; set; }

		[JsonProperty("sid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		[JsonConverter(typeof(ParseStringConverter))]
		public long? Sid { get; set; }

		[JsonProperty("gid", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Gid { get; set; }

		[JsonProperty("vip", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Vip { get; set; }

		[JsonProperty("vip_hide", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? VipHide { get; set; }

		[JsonProperty("server_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string ServerName { get; set; }

		[JsonProperty("role_name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string RoleName { get; set; }

		[JsonProperty("head_index", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string HeadIndex { get; set; }

		[JsonProperty("content", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public string Content { get; set; }

		[JsonProperty("is_history_msg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? IsHistoryMsg { get; set; }

		[JsonProperty("ts", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
		public long? Ts { get; set; }
	}


	public static class TweetSerialize
	{
		public static Tweet FromJson(string json) => JsonConvert.DeserializeObject<Tweet>(json, TweetConverter.Settings);
		public static string ToJson(this Tweet self) => JsonConvert.SerializeObject(self, TweetConverter.Settings);
	}

	internal static class TweetConverter
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
