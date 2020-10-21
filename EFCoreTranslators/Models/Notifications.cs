using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Notifications
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string DataKey { get; set; }
        public int ObjectId { get; set; }
        public string MessageHtmlUs { get; set; }
        public string MessageHtmlVn { get; set; }
        public string MessageUs { get; set; }
        public string MessageVn { get; set; }
        public int Level { get; set; }
        public bool? IsRead { get; set; }
        public bool? IsHiden { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
