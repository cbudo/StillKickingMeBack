using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace StillKickingMeBack.Controllers
{
    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        // GET: api/Patient/example@example.com
        [HttpGet]
        [Route("{patientId:int}")]
        public string getPatient(int patientId)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var patient = db.Patients.Where(p => p.Id == patientId).First();
            if (patient == null)
            {
                return js.Serialize(null);
            }
            return js.Serialize(patient);
        }
    }
}