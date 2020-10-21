using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Wards
    {
        public Wards()
        {
            OrdersConsigneeWard = new HashSet<Orders>();
            OrdersShipperWard = new HashSet<Orders>();
            Warehouses = new HashSet<Warehouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int DistrictId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Districts District { get; set; }
        public virtual ICollection<Orders> OrdersConsigneeWard { get; set; }
        public virtual ICollection<Orders> OrdersShipperWard { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
    }
}
