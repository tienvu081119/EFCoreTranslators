using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Customers = new HashSet<Customers>();
            OrdersConsigneeCountry = new HashSet<Orders>();
            OrdersShipperCountry = new HashSet<Orders>();
            Ports = new HashSet<Ports>();
            Provinces = new HashSet<Provinces>();
            States = new HashSet<States>();
            Warehouses = new HashSet<Warehouses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string IsoAlpha2 { get; set; }
        public string IsoAlpha3 { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }
        public virtual ICollection<Orders> OrdersConsigneeCountry { get; set; }
        public virtual ICollection<Orders> OrdersShipperCountry { get; set; }
        public virtual ICollection<Ports> Ports { get; set; }
        public virtual ICollection<Provinces> Provinces { get; set; }
        public virtual ICollection<States> States { get; set; }
        public virtual ICollection<Warehouses> Warehouses { get; set; }
    }
}
