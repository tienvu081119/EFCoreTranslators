using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderLines = new HashSet<OrderLines>();
        }

        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string OrderNo { get; set; }
        public string DeliveryInstruction { get; set; }
        public int? NumberOfPieces { get; set; }
        public decimal TotalCbm { get; set; }
        public decimal? TotalGrossWeight { get; set; }
        public decimal? TotalChargeWeight { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string MeasumentUnit { get; set; }
        public DateTime? ExpectedTimeOfArrival { get; set; }
        public DateTime? EstimatedTimeOfArrival { get; set; }
        public DateTime? ActualTimeOfArrival { get; set; }
        public decimal? Codamount { get; set; }
        public int? DeliveryStatusId { get; set; }
        public int? CustomsStatusId { get; set; }
        public string Cdchanel { get; set; }
        public string Notes { get; set; }
        public decimal? TotalAmountUsd { get; set; }
        public decimal? TotalAmountVnd { get; set; }
        public decimal? TotalInsuranceAmountUsd { get; set; }
        public decimal? TotalInsuranceAmountVnd { get; set; }
        public decimal? TotalTaxAmountUsd { get; set; }
        public decimal? TotalTaxAmountVnd { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string ConsigneeAddress1 { get; set; }
        public string ConsigneeAddress2 { get; set; }
        public int? ConsigneeCountryId { get; set; }
        public int? ConsigneeDistrictId { get; set; }
        public string ConsigneeName { get; set; }
        public string ConsigneePostalCode { get; set; }
        public int? ConsigneeProvinceId { get; set; }
        public string ConsigneeTelephone { get; set; }
        public int? ConsigneeWardId { get; set; }
        public string ShipperAddress1 { get; set; }
        public string ShipperAddress2 { get; set; }
        public int? ShipperCountryId { get; set; }
        public int? ShipperDistrictId { get; set; }
        public string ShipperName { get; set; }
        public string ShipperPostalCode { get; set; }
        public int? ShipperProvinceId { get; set; }
        public string ShipperTelephone { get; set; }
        public int? ShipperWardId { get; set; }
        public string ConsigneeCountryName { get; set; }
        public string ConsigneeDistrictName { get; set; }
        public string ConsigneeProvinceName { get; set; }
        public string ConsigneeWardName { get; set; }
        public string ShipperCountryName { get; set; }
        public string ShipperDistrictName { get; set; }
        public string ShipperProvinceName { get; set; }
        public string ShipperWardName { get; set; }
        public Guid CreatedUserId { get; set; }
        public string CustomerRefNo { get; set; }
        public string CustomerTrackingNo { get; set; }
        public string DeliveryService { get; set; }
        public string DeliveryTrackingNo { get; set; }
        public int? ConsigneeStateId { get; set; }
        public string ConsigneeStateName { get; set; }
        public int? ShipperStateId { get; set; }
        public string ShipperStateName { get; set; }
        public bool? IsIncludedBattery { get; set; }
        public bool? IsRemoteAreaDestination { get; set; }
        public DateTime? ActualDeliveryTime { get; set; }
        public DateTime? ActualPickupTime { get; set; }
        public DateTime? EstimatedDeliveryTime { get; set; }
        public DateTime? EstimatedPickupTime { get; set; }

        public virtual Countries ConsigneeCountry { get; set; }
        public virtual Districts ConsigneeDistrict { get; set; }
        public virtual Provinces ConsigneeProvince { get; set; }
        public virtual States ConsigneeState { get; set; }
        public virtual Wards ConsigneeWard { get; set; }
        public virtual Statuses CustomsStatus { get; set; }
        public virtual Statuses DeliveryStatus { get; set; }
        public virtual Shipments Shipment { get; set; }
        public virtual Countries ShipperCountry { get; set; }
        public virtual Districts ShipperDistrict { get; set; }
        public virtual Provinces ShipperProvince { get; set; }
        public virtual States ShipperState { get; set; }
        public virtual Wards ShipperWard { get; set; }
        public virtual ICollection<OrderLines> OrderLines { get; set; }
    }
}
