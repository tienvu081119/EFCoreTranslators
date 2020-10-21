using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Ports
    {
        public Ports()
        {
            ShipmentsPortOfDischarge = new HashSet<Shipments>();
            ShipmentsPortOfLoading = new HashSet<Shipments>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Shipments> ShipmentsPortOfDischarge { get; set; }
        public virtual ICollection<Shipments> ShipmentsPortOfLoading { get; set; }
    }
}
