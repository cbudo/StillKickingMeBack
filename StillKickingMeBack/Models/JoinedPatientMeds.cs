using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class JoinedPatientMeds
    {
        public JoinedPatientMeds(string name, int? pills, bool food, string dosage,
             DateTime? start, string repeatCode, DateTime? end, byte? severity, bool active, 
             int? max, double? repeat_hours, string repeat_start)
        {
            this.name = name;
            this.pillsToTake = pills;
            this.eatWithFood = food;
            this.dosage = dosage;
            this.endDate = end;
            this.severity = severity;
            this.startDate = start;
            this.weekRepeatCode = repeatCode;
            this.active = active;
            this.maxPills = max;
            this.repeatStart = repeat_start;
            this.repeatHours = repeat_hours;

        }
        public string name { get; set; }
        public int? pillsToTake { get; set; }
        public bool eatWithFood { get; set; }
        public string dosage { get; set; }
        public double? repeatHours { get; set; }
        public string repeatStart { get; set; }
        public string weekRepeatCode { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        public byte? severity { get; set; }
        public bool active { get; set; }
        public int? maxPills { get; set; }
    }
}