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
        public int Create(PatientModel patient)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            var db = new StillKickingDBDataContext();
            var a = new Patient();
            a.Email = patient.Email;
            a.Name = patient.Name;
            a.Password = GetHashedString(patient.Password);
            a.Sex = patient.Sex;
            a.DOB = patient.DOB;
            db.Patients.InsertOnSubmit(a);
            db.SubmitChanges();
            return a.Id;
        }

        // POST: api/patient/login
        [HttpPost]
        [Route("login")]
        public int Login(UserModel user)
        {
            var db = new StillKickingDBDataContext();
            var hashedPwd = GetHashedString(user.password);
            var patient = db.Patients.Where(m => m.Email == user.username).Where(m => m.Password == hashedPwd).First();

            return patient.Id;
        }

        //public static string Encrypt(string data)
        //{
        //    TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        //    DES.Mode = CipherMode.ECB;
        //    DES.Key = GetKey("a1!B78s!5(");

        //    DES.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform DESEncrypt = DES.CreateEncryptor();
        //    Byte[] Buffer = ASCIIEncoding.ASCII.GetBytes(data);

        //    return Convert.ToBase64String(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        //}

        //public static string Decrypt(string data)
        //{
        //    TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();

        //    DES.Mode = CipherMode.ECB;
        //    DES.Key = GetKey("a1!B78s!5(");

        //    DES.Padding = PaddingMode.PKCS7;
        //    ICryptoTransform DESEncrypt = DES.CreateDecryptor();
        //    Byte[] Buffer = Convert.FromBase64String(data.Replace(" ", "+"));

        //    return Encoding.UTF8.GetString(DESEncrypt.TransformFinalBlock(Buffer, 0, Buffer.Length));
        //}

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