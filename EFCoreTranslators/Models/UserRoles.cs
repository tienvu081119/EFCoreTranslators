using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class UserRoles
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public virtual Roles Role { get; set; }
        public virtual Users User { get; set; }
    }
}
