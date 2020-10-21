using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Districts
    {
        public Districts()
        {
            OrdersConsigneeDistrict = new HashSet<Orders>();
            OrdersShipperDistrict = new HashSet<Orders>();
            Wards = new HashSet<Wards>();
            Warehouses = new HashSet<Warehouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ProvinceId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Provinces Province { get; set; }
        public virtual ICollection<Orders> OrdersConsigneeDistrict { get; set; }
        public virtual ICollection<Orders> OrdersShipperDistrict { get; set; }
        public virtual ICollection<Wards> Wards { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
    }
}
