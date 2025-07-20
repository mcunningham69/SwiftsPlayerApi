using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwiftsPlayerApi.Json      // <‑‑ pick any namespace you like
{
    public sealed class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";

        public override DateOnly Read(ref Utf8JsonReader reader,
                                      Type typeToConvert,
                                      JsonSerializerOptions options)
        {
            var str = reader.GetString();
            return DateOnly.ParseExact(str!, Format);
        }

        public override void Write(Utf8JsonWriter writer,
                                   DateOnly value,
                                   JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}

