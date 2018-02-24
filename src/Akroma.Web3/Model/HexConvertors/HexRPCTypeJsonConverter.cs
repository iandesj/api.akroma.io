using System;
using Akroma.Web3.Model.HexTypes;
using Newtonsoft.Json;

namespace Akroma.Web3.Model.HexConvertors
{
    public class HexRPCTypeJsonConverter<T, TValue> : JsonConverter where T : HexRPCType<TValue>
    {

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            T hexRPCType = (T)value;
            writer.WriteValue(hexRPCType.HexValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return HexTypeFactory.CreateFromHex<TValue>((string)reader.Value);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

    }
}
