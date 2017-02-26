using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StillKickingMeBack.Models
{
    public class caregiverWithTypes
    {
        public caregiverWithTypes(int Id, string Name, string Phone, string Notes, int ContactType_IDFK,
                int Patient_IDFK, string TypeName)
        {
            this.Id = Id;
            this.Name = Name;
            this.Phone = Phone;
            this.Notes = Notes;
            this.ContactType_IDFK = ContactType_IDFK;
            this.Patient_IDFK = Patient_IDFK;
            this.TypeName = TypeName;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public int ContactType_IDFK { get; set; }
        public int Patient_IDFK { get; set; }
        public string TypeName { get; set; }
    }
}