using System;
using System.Text;
using Confluent.Kafka;

namespace kafka.consumers.Infrastructure
{
    public class GuidKeyDeserializer : IDeserializer<Guid>
    {
        public Guid Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return new Guid(data);
        }
    }
}