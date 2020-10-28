using System;

namespace Gamer.Events
{
    public class AccountRegistered
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}
