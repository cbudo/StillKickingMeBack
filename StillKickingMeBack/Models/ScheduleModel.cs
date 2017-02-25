using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class ScheduleModel
    {
        public int medId { get; set; }
        public int toTake { get; set; }
        public string timeToTake { get; set; }
        public string weekRepeatCode { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public byte severity { get; set; }
        public bool active { get; set; }
    }
}