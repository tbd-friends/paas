using System;
using Confluent.Kafka;

namespace kafka.shared.Serializers
{
    public class GuidKeySerializer : ISerializer<Guid>
    {
        public byte[] Serialize(Guid data, SerializationContext context)
        {
            return data.ToByteArray();
        }
    }
}