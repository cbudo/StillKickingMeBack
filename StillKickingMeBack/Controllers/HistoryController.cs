using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StillKickingMeBack.Controllers
{
    public class HistoryController : ApiController
    {
        [HttpGet]
        [Route("api/patient/today")]
        public IEnumerable<History> GetToday()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                var db = new StillKickingDBDataContext();
                return db.Histories.Where(h => h.patient_idfk == authCode && h.completed_time.GetValueOrDefault().Date == DateTime.Now.Date);
            }
            return null;
        }
        [HttpGet]
        [Route("api/patient/history")]
        public IEnumerable<History> GetPast()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                var db = new StillKickingDBDataContext();
                return db.Histories.Where(h => h.patient_idfk == authCode && h.completed_time.GetValueOrDefault().Date > DateTime.Now.AddHours(-48));
            }
            return null;
        }

        [HttpPost]
        [Route("api/patient/history")]
        public int? MakeHistory(History model)
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                var db = new StillKickingDBDataContext();
                model.patient_idfk = authCode;
                model.completed_time = DateTime.Now;
                db.Histories.InsertOnSubmit(model);
                db.SubmitChanges();
                return model.Id;
            }
            return null;
        }
    }
}
