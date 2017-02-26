using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StillKickingMeBack.Controllers
{
    public class ScheduleController : ApiController
    {
        // GET: Schedule
        [HttpGet]
        [Route("api/Patient/Schedule")]
        public IEnumerable<Patient_Medication_rel> GetSchedule()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
                return db.Patient_Medication_rels.Where(m => m.User_IDFK == Convert.ToInt64(headers.GetValues("Authorization").First())).Where(m=>m.active);
            }
            return null;
        }
        [HttpGet]
        [Route("api/Patient/ScheduleDrugs")]
        public IEnumerable<JoinedPatientMeds> GetScheduleWithDrugs()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
                var schedules = db.Patient_Medication_rels.Where(m => m.User_IDFK == Convert.ToInt64(headers.GetValues("Authorization").First())).Where(m => m.active);
                return from s in schedules
                       join m in db.Medications
                       on s.Medication_IDFK equals m.Id
                       select new JoinedPatientMeds(m.Name, s.amount, m.eat_with_food, m.dosage_mg, s.start_date, s.week_repeat_code, s.end_date, s.severity, m.active, m.max_pills, s.repeat_interval, s.time_to_take);
            }
            return null;
        }
        [HttpPost]
        [Route("api/Patient/Schedule")]
        public int? AddSchedule(ScheduleModel model)
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
                var schedule = new Patient_Medication_rel();
                schedule.active = model.active;
                schedule.end_date = model.end_date;
                schedule.Medication_IDFK = model.med_Id;
                schedule.severity = model.severity;
                schedule.start_date = model.start_date;
                schedule.time_to_take = model.time_to_take;
                schedule.repeat_interval =  model.repeat_interval;
                schedule.User_IDFK = Convert.ToInt32(headers.GetValues("Authorization").First());
                schedule.week_repeat_code = model.week_repeat_code;
                db.Patient_Medication_rels.InsertOnSubmit(schedule);
                db.SubmitChanges();
                return schedule.Id;
            }
            return null;
        }
    }

    
}