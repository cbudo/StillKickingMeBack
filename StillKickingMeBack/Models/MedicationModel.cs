using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class MedicationModel
    {
        public string name { get; set; }
        public bool eat_with_food { get; set; }
        public string dosage_mg { get; set; }
        public string notes { get; set; }
        public int max_pills { get; set; }
    }
}