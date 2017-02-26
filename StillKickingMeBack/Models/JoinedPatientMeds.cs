using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class JoinedPatientMeds
    {
        public JoinedPatientMeds(string name, int pills, bool food, string dosage,
            int? repeat, string repeatStart, string repeatCode, DateTime? start,
            DateTime? end, byte? severity, bool active, int? max)
        {
            this.name = name;
            this.pillsToTake = pills;
            this.eatWithFood = food;
            this.dosage = dosage;
            this.endDate = end;
            this.repeatHours = repeat;
            this.repeatStart = repeatStart;
            this.severity = severity;
            this.startDate = start;
            this.weekRepeatCode = repeatCode;
            this.active = active;
            this.maxPills = max;
        }
        public string name { get; set; }
        public int pillsToTake { get; set; }
        public bool eatWithFood { get; set; }
        public string dosage { get; set; }
        public int? repeatHours { get; set; }
        public string repeatStart { get; set; }
        public string weekRepeatCode { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public byte? severity { get; set; }
        public bool active { get; set; }
        public int? maxPills { get; set; }
    }
}