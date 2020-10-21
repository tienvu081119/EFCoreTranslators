using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Shipments = new HashSet<Shipments>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string Type { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ConnectionSettingId { get; set; }
        public int? TransportSettingId { get; set; }

        public virtual ConnectionSettings ConnectionSetting { get; set; }
        public virtual Countries Country { get; set; }
        public virtual ICollection<Shipments> Shipments { get; set; }
    }
}
