using MahorobaWare.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{
	public class Server
	{
		[JsonProperty("change_sug_nums")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long ChangeSugNums { get; set; }

		[JsonProperty("is_suggest")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long IsSuggest { get; set; }

		[JsonProperty("stop_login")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long StopLogin { get; set; }

		[JsonProperty("max_online_nums")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long MaxOnlineNums { get; set; }

		[JsonProperty("online_crowd_nums")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long OnlineCrowdNums { get; set; }

		[JsonProperty("index")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Index { get; set; }

		[JsonProperty("url")]
		public Uri Url { get; set; }

		[JsonProperty("payurl")]
		public string Payurl { get; set; }

		[JsonProperty("chatserver")]
		public string Chatserver { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("state")]
		public long State { get; set; }

		[JsonProperty("platform")]
		public string Platform { get; set; }

		[JsonProperty("isnew")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Isnew { get; set; }

		[JsonProperty("hasaccount")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Hasaccount { get; set; }

		[JsonProperty("online_nums")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long OnlineNums { get; set; }

		[JsonProperty("resource_url")]
		public Uri ResourceUrl { get; set; }
	}
}
