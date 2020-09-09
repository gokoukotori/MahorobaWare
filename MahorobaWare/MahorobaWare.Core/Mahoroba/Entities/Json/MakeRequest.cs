using MahorobaWare.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{
	public class MakeRequest
	{
		[JsonProperty("https://prd-main.sakura.fusion-studio.co.jp:7001/login.php")]
		public DmmInfo DmmInfo { get; set; }
	}
	public class DmmInfo
	{
		[JsonProperty("rc")]
		public long Rc { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }

		[JsonProperty("headers")]
		public DmmServerHeaders Headers { get; set; }
	}
	public class DmmServerHeaders
	{
		[JsonProperty("Content-Type")]
		public string ContentType { get; set; }

		[JsonProperty("Connection")]
		public string Connection { get; set; }

		[JsonProperty("Server")]
		public string Server { get; set; }

		[JsonProperty("X-Powered-By")]
		public string XPoweredBy { get; set; }

		[JsonProperty("Access-Control-Max-Age")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long AccessControlMaxAge { get; set; }

		[JsonProperty("Access-Control-Allow-Origin")]
		public string AccessControlAllowOrigin { get; set; }

		[JsonProperty("Access-Control-Allow-Headers")]
		public string AccessControlAllowHeaders { get; set; }

		[JsonProperty("Access-Control-Allow-Methods")]
		public string AccessControlAllowMethods { get; set; }
	}
}
