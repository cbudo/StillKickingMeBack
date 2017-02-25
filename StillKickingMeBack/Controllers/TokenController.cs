using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StillKickingMeBack.Controllers
{
    public class TokenController : ApiController
    {
        [AllowAnonymous]
        [HttpPost]
        public string GetToken(UserModel user)
        {
            return null;
        }

        private bool CheckUser(string username, string password)
        {

            return false;
        }
    }
}