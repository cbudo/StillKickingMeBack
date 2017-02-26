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
            return null;
        }

        [HttpPost]
        [Route("api/patient/contacts")]
        public IEnumerable<EmergencyContact> GetContacts()
        {
            var headers = Request.Headers;
            if (headers.Contains("Authorization"))
            {
                var db = new StillKickingDBDataContext();
            }
            return null;
        }
    }
}
