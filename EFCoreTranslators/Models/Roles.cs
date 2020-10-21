using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Roles
    {
        public Roles()
        {
            UserRoles = new HashSet<UserRoles>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Timestamp { get; set; }

        public virtual ICollection<UserRoles> UserRoles { get; set; }
    }
}
