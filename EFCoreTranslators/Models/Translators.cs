using System;
using System.Collections.Generic;

namespace EFCoreTranslators.Models
{
    public partial class Translators
    {
        public int Id { get; set; }
        public string DataKey { get; set; }
        public string OriginalValue { get; set; }
        public string TranslatedValue { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
