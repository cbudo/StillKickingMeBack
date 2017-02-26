using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class HistoryObject
    {
        public HistoryObject(History model, string drug_name, string drug_dose)
        {
            this.Id = model.Id;
            this.amount_taken = model.amount_taken;
            this.timecode = model.timecode;
            this.Id = model.Id;
            this.patient_Idfk = model.patient_idfk;
            this.on_time = model.on_time;
            if (model.completed_time >= new DateTime(1753, 1, 1))
            {
                this.completed_time = model.completed_time.GetValueOrDefault();
            }
            this.drug_idfk = model.drug_idfk;
            this.drug_name = drug_name;
            this.drug_dosage = drug_dose;
        }
        public string drug_name { get; set; }
        public string drug_dosage { get; set; }
        public int drug_idfk { get; set; }
        public int Id { get; set; }
        public int patient_Idfk { get; set; }
        public int amount_taken { get; set; }
        public string timecode { get; set; }
        public bool on_time { get; set; }
        public DateTime completed_time { get; set; }
    }
}