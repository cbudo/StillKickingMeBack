using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class MedicationModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public int pills_to_take { get; set; }
        public bool eat_with_food { get; set; }
        public string dosage_mg { get; set; }
        public int repeat_hours { get; set; }
        public string repeat_start { get; set; }
        public bool active { get; set; }
    }
}