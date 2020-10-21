using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Users
    {
        public Users()
        {
            Shipments = new HashSet<Shipments>();
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual ICollection<Shipments> Shipments { get; set; }
        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
