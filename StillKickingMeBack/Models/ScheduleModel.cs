using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class ScheduleModel
    {
        public int med_Id { get; set; }
        public int amount { get; set; }
        public string time_to_take { get; set; }
        public string week_repeat_code { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public double repeat_interval { get; set; }
        public byte severity { get; set; }
        public bool active { get; set; }
    }
}