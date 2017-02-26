using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StillKickingMeBack.Controllers
{
    public class ContactsController : ApiController
    {
        [HttpPost]
        [Route("api/patient/contact")]
        public int? AddContact(ContactModel model)
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var authCode = Convert.ToInt32(headers.GetValues("Authorization").First());
                var caregiver = new Caregiver();
                var db = new StillKickingDBDataContext();
                caregiver.ContactType_IDFK = model.ContactType;
                caregiver.Name = model.Name;
                caregiver.Notes = model.Notes;
                caregiver.Patient_IDFK = authCode;
                caregiver.Phone = model.phone;
                db.Caregivers.InsertOnSubmit(caregiver);
                db.SubmitChanges();
                return caregiver.Id;
            }
            return null;
        }

        [HttpGet]
        [Route("api/patient/contacts")]
        public IEnumerable<Caregiver> GetContacts()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
                return db.Caregivers.Where(c => c.Patient_IDFK == Convert.ToInt32(headers.GetValues("Authorization").First()));
            }
            return null;
        }
    }
}
