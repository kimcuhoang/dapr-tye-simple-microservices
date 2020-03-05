using SimpleStore.Domain.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SimpleStore.Infrastructure.Common.JsonConverters.IdentityTypes
{
    /// <summary>
    /// https://weblogs.thinktecture.com/pawel/2019/10/aspnet-core-3-0-custom-jsonconverter-for-the-new-system_text_json.html
    /// </summary>
    public class IdentityJsonConverter<TIdentity> : JsonConverter<TIdentity> where TIdentity : IdentityBase
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(TIdentity);
        }

        public override TIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return IdentityFactory.Create<TIdentity>(reader.GetGuid());
        }

        public override void Write(Utf8JsonWriter writer, TIdentity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Id);
        }
    }
}
