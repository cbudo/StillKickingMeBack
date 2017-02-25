using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace StillKickingMeBack.Controllers
{
    [RoutePrefix("api/patient")]
    public class ConditionsController : ApiController
    {
        // GET: api/patient/conditions
        [HttpGet]
        [Route("conditions")]

        public IEnumerable<Medical_Condition> getConditions(int patientId)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var conditions = db.Medical_Conditions.Where(p => p.Id == patientId).AsEnumerable();
            return conditions;
        }

        // POST: api/patient
        [HttpPost]
        [Route("{patientId:int}/conditions")]
        public Medical_Condition Create(int patientId, ConditionsModel condition)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var a = new Medical_Condition();
            a.Name = condition.Name;
            a.Patient_IDFK = patientId;
            db.Medical_Conditions.InsertOnSubmit(a);
            db.SubmitChanges();
            return a;
        }
    }
}