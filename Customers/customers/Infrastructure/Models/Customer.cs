using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Gamer.Customer.Customers.Infrastructure.Models
{
    public class Customer
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}