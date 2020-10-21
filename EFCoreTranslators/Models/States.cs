using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class States
    {
        public States()
        {
            OrdersConsigneeState = new HashSet<Orders>();
            OrdersShipperState = new HashSet<Orders>();
            Provinces = new HashSet<Provinces>();
            Warehouses = new HashSet<Warehouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Orders> OrdersConsigneeState { get; set; }
        public virtual ICollection<Orders> OrdersShipperState { get; set; }
        public virtual ICollection<Provinces> Provinces { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
    }
}
