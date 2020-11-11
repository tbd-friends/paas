using System;
using System.Text.Json;
using Confluent.Kafka;

namespace kafka.consumers.Infrastructure
{
    public class JsonValueDeserializer<T> : IDeserializer<T>
        where T : class
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions());
        }
    }
}