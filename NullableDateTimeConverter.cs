using System.Text.Json;
using System.Text.Json.Serialization;

public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (string.IsNullOrWhiteSpace(str))
                return null;

            if (DateTime.TryParse(str, out var result))
                return result;

            throw new JsonException($"Unable to parse '{str}' as DateTime.");
        }

        throw new JsonException($"Unexpected token parsing DateTime: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString("O")); // ISO 8601
        else
            writer.WriteNullValue();
    }
}

