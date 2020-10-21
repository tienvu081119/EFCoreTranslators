using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Provinces
    {
        public Provinces()
        {
            Districts = new HashSet<Districts>();
            OrdersConsigneeProvince = new HashSet<Orders>();
            OrdersShipperProvince = new HashSet<Orders>();
            Warehouses = new HashSet<Warehouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProvinceType { get; set; }
        public string MappingCode1 { get; set; }
        public string MappingCode2 { get; set; }
        public string MappingCode3 { get; set; }
        public string MappingCode4 { get; set; }
        public string MappingCode5 { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? StateId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual States State { get; set; }
        public virtual ICollection<Districts> Districts { get; set; }
        public virtual ICollection<Orders> OrdersConsigneeProvince { get; set; }
        public virtual ICollection<Orders> OrdersShipperProvince { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
    }
}
