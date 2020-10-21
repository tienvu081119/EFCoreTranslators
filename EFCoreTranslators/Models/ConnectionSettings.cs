using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class ConnectionSettings
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PartnerCode { get; set; }
        public string Token { get; set; }
        public bool IsTesting { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
