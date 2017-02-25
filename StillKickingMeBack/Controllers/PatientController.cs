using StillKickingMeBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        public Patient getPatient(int patientId)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var patient = db.Patients.Where(p => p.Id == patientId).First();
            if (patient == null)
            {
                return null;
            }
            return patient;
        }

        // POST: api/patient/register
        [HttpPost]
        [Route("register")]
        public Patient Create(PatientModel patient)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var a = new Patient();
            a.Email = patient.Email;
            a.Name = patient.Name;
            a.Password = GetHashedString(patient.Password);
            a.Phone = patient.Phone;
            db.Patients.InsertOnSubmit(a);
            db.SubmitChanges();
            return a;
        }

        private string GetHashedString(string _PW)
        {
            string _HashedPW = "";
            SHA512 sha = new SHA512CryptoServiceProvider();
            byte[] result;
            StringBuilder strBuilder = new StringBuilder();


            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_PW));
            result = sha.Hash;

            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            _HashedPW = strBuilder.ToString();
            return _HashedPW;
        }
    }
}