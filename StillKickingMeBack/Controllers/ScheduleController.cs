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
                schedule.end_date = model.endDate;
                schedule.Medication_IDFK = model.medId;
                schedule.severity = model.severity;
                schedule.start_date = model.startDate;
                schedule.end_date = null;
                schedule.time_to_take = model.timeToTake;
                schedule.to_take = model.toTake;
                schedule.User_IDFK = Convert.ToInt32(headers.GetValues("Authorization").First());
                schedule.week_repeat_code = model.weekRepeatCode;
                db.Patient_Medication_rels.InsertOnSubmit(schedule);
                db.SubmitChanges();
                return schedule.Id;
            }
            return null;
        }
    }
}