using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MahorobaWare.Core.Mahoroba.Entities.Json
{

	public partial struct Uid
	{
		public long? Integer;
		public string String;

		public static implicit operator Uid(long Integer) => new Uid { Integer = Integer };
		public static implicit operator Uid(string String) => new Uid { String = String };
	}

	public partial struct UidGeneral2
	{
		public List<Uid> AnythingArray;
		public long? Integer;

		public static implicit operator UidGeneral2(List<Uid> AnythingArray) => new UidGeneral2 { AnythingArray = AnythingArray };
		public static implicit operator UidGeneral2(long Integer) => new UidGeneral2 { Integer = Integer };
	}

	public static class UidSerialize
	{
		public static List<UidGeneral2> FromJson(string json) => JsonConvert.DeserializeObject<List<UidGeneral2>>(json, UidConverter.Settings);
		public static string ToJson(this List<UidGeneral2> self) => JsonConvert.SerializeObject(self, UidConverter.Settings);
	}

	internal static class UidConverter
	{
		public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
		{
			MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
			DateParseHandling = DateParseHandling.None,
			Converters =
			{
				UidGeneral2Converter.Singleton,
				UidGeneral1Converter.Singleton,
				new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
			},
		};
	}

	internal class UidGeneral2Converter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(UidGeneral2) || t == typeof(UidGeneral2?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Integer:
					var integerValue = serializer.Deserialize<long>(reader);
					return new UidGeneral2 { Integer = integerValue };
				case JsonToken.StartArray:
					var arrayValue = serializer.Deserialize<List<Uid>>(reader);
					return new UidGeneral2 { AnythingArray = arrayValue };
			}
			throw new Exception("Cannot unmarshal type UidGeneral2");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (UidGeneral2)untypedValue;
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
			throw new Exception("Cannot marshal type UidGeneral2");
		}

		public static readonly UidGeneral2Converter Singleton = new UidGeneral2Converter();
	}

	internal class UidGeneral1Converter : JsonConverter
	{
		public override bool CanConvert(Type t) => t == typeof(Uid) || t == typeof(Uid?);

		public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.Integer:
					var integerValue = serializer.Deserialize<long>(reader);
					return new Uid { Integer = integerValue };
				case JsonToken.String:
				case JsonToken.Date:
					var stringValue = serializer.Deserialize<string>(reader);
					return new Uid { String = stringValue };
			}
			throw new Exception("Cannot unmarshal type UidGeneral1");
		}

		public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
		{
			var value = (Uid)untypedValue;
			if (value.Integer != null)
			{
				serializer.Serialize(writer, value.Integer.Value);
				return;
			}
			if (value.String != null)
			{
				serializer.Serialize(writer, value.String);
				return;
			}
			throw new Exception("Cannot marshal type UidGeneral1");
		}

		public static readonly UidGeneral1Converter Singleton = new UidGeneral1Converter();
	}
}
