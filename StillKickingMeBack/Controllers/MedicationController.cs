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
        [Route("api/patient/medications")]
        public IEnumerable<Medication> GetMedications()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                return db.Medications.Where(p => p.UserIDFK == authCode && p.active);
            }
            return null;
        }

        [HttpGet]
        [Route("api/medication/{medicationId:int}")]
        public Medication GetMedication(int medicationId)
        {
            var db = new StillKickingDBDataContext();

            return db.Medications.Where(m => m.Id == medicationId).First();
        }

        [HttpPost]
        [Route("api/patient/medication")]
        public IEnumerable<Medication> AddMedication(MedicationModel meds)
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                var db = new StillKickingDBDataContext();
                Medication drugs = new Medication();
                drugs.UserIDFK = authCode;
                drugs.Name = meds.name;
                drugs.active = true;
                drugs.dosage_mg = meds.dosage_mg;
                drugs.eat_with_food = meds.eat_with_food;
                drugs.max_pills = meds.max_pills;
                drugs.notes = meds.notes;
                db.Medications.InsertOnSubmit(drugs);
                db.SubmitChanges();
                return db.Medications.Where(p => p.UserIDFK == authCode && p.active);
            }
            return null;
        }
    }
}