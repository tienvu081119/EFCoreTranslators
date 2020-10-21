using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class SystemDefaultValues
    {
        public int Id { get; set; }
        public int ObjectId { get; set; }
        public string DataType { get; set; }
        public string DataValueVn { get; set; }
        public string DataValueUs { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string DataKey { get; set; }
    }
}
