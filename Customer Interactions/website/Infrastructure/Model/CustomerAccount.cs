using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamer.Customer.Website.Infrastructure.Model
{
    public class CustomerAccount
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public bool IsVerified { get; set; }
    }
}