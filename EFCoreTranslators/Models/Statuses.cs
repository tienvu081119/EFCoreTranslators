using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Statuses
    {
        public Statuses()
        {
            OrderLinesCustomsStatus = new HashSet<OrderLines>();
            OrderLinesDeliveryStatus = new HashSet<OrderLines>();
            OrdersCustomsStatus = new HashSet<Orders>();
            OrdersDeliveryStatus = new HashSet<Orders>();
            ShipmentsCustomsStatus = new HashSet<Shipments>();
            ShipmentsShipmentStatus = new HashSet<Shipments>();
        }

        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string NameVn { get; set; }
        public string NameUs { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int SortingOrder { get; set; }
        public string Color { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string NameTrackingUs { get; set; }
        public string NameTrackingVn { get; set; }

        public virtual ICollection<OrderLines> OrderLinesCustomsStatus { get; set; }
        public virtual ICollection<OrderLines> OrderLinesDeliveryStatus { get; set; }
        public virtual ICollection<Orders> OrdersCustomsStatus { get; set; }
        public virtual ICollection<Orders> OrdersDeliveryStatus { get; set; }
        public virtual ICollection<Shipments> ShipmentsCustomsStatus { get; set; }
        public virtual ICollection<Shipments> ShipmentsShipmentStatus { get; set; }
    }
}
