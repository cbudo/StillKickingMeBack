using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StillKickingMeBack.Controllers
{
    public class MedicationController : ApiController
    {
        // GET: Medication
        [NonAction]
        [HttpGet]
        [Route("api/medications")]
        public IEnumerable<Medication> Index()
        {
            var db = new StillKickingDBDataContext();
            return db.Medications;
        }

        [HttpGet]
        [Route("api/patient/{patientId:int}/medications")]
        public IEnumerable<Medication> GetMedications(int patientId)
        {
            var db = new StillKickingDBDataContext();
            return db.Medications.Where(p=>p.UserIDFK == patientId);
        }

        [HttpGet]
        [Route("api/medication/{medicationId:int}")]
        public Medication GetMedication(int medicationId)
        {
            var db = new StillKickingDBDataContext();

            return db.Medications.Where(m=>m.Id == medicationId).First();
        }

        [HttpPost]
        [Route("api/patient/{patientId:int}/medication")]
        public int AddMedication(int patientId, MedicationModel meds)
        {
            Medication drugs = new Medication();
            drugs.UserIDFK = patientId;
            drugs.Name = meds.Name;
            drugs.pills_to_take = meds.pills_to_take;
            drugs.active = meds.active;
            drugs.dosage_mg = meds.dosage_mg;
            drugs.eat_with_food = meds.eat_with_food;
            drugs.repeat_hours = meds.repeat_hours;
            drugs.repeat_start = meds.repeat_start;
            var db = new StillKickingDBDataContext();
            db.Medications.InsertOnSubmit(drugs);
            db.SubmitChanges();
            return drugs.Id;
        }
    }
}