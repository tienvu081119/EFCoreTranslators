using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Shipments
    {
        public Shipments()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int CustomerId { get; set; }
        public string VesselName { get; set; }
        public string Voyage { get; set; }
        public string Awb { get; set; }
        public int? TotalNumberOfPackages { get; set; }
        public decimal? TotalCbm { get; set; }
        public decimal? TotalGrossWeight { get; set; }
        public decimal? TotalChargeWeight { get; set; }
        public decimal? TotalAmountUsd { get; set; }
        public decimal? TotalAmountVnd { get; set; }
        public string MainCurrency { get; set; }
        public decimal? CurrencyRate { get; set; }
        public DateTime Eta { get; set; }
        public int? TotalNumberOfPieces { get; set; }
        public int? PortOfLoadingId { get; set; }
        public int? PortOfDischargeId { get; set; }
        public string ImportFileName { get; set; }
        public DateTime? ImportDate { get; set; }
        public int? ShipmentStatusId { get; set; }
        public string CustomsDeclarationNo { get; set; }
        public int? CustomsStatusId { get; set; }
        public Guid CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Users CreatedUser { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Statuses CustomsStatus { get; set; }
        public virtual Ports PortOfDischarge { get; set; }
        public virtual Ports PortOfLoading { get; set; }
        public virtual Statuses ShipmentStatus { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
