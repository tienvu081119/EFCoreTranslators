using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Warehouses
    {
        public int Id { get; set; }
        public string NameVn { get; set; }
        public string NameUs { get; set; }
        public string Address { get; set; }
        public string Pic { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public int WardId { get; set; }
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Countries Country { get; set; }
        public virtual Districts District { get; set; }
        public virtual Provinces Province { get; set; }
        public virtual States State { get; set; }
        public virtual Wards Ward { get; set; }
    }
}
