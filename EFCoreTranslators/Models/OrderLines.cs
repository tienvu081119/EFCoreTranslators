using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class OrderLines
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductNo { get; set; }
        public string ItemNo { get; set; }
        public string Hscode { get; set; }
        public string Eancode { get; set; }
        public int? Quantity { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Cbm { get; set; }
        public int? Length { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string DescriptionOfGoods { get; set; }
        public int? DeliveryStatusId { get; set; }
        public int? CustomsStatusId { get; set; }
        public decimal? PriceVnd { get; set; }
        public decimal? PriceUsd { get; set; }
        public decimal? AmountVnd { get; set; }
        public decimal? AmountUsd { get; set; }
        public decimal? TaxRate { get; set; }
        public decimal? TaxAmountUsd { get; set; }
        public decimal? TaxAmountVnd { get; set; }
        public decimal? InsuranceAmountUsd { get; set; }
        public decimal? InsuranceAmountVnd { get; set; }
        public string MainCurrency { get; set; }
        public decimal? CurrencyRate { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Guid CreatedUserId { get; set; }

        public virtual Statuses CustomsStatus { get; set; }
        public virtual Statuses DeliveryStatus { get; set; }
        public virtual Orders Order { get; set; }
    }
}
