using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;

namespace sixth.Controllers
{
    public class RegistrationController : ApiController
    {
        string key = "1prt56";
        public HttpResponseMessage Post([FromBody] need_login_table need_Login)
        {
            using (needDbEntities needDbEntities = new needDbEntities()) 
            {
                try
                {

                    bool isEverythingOk = true;

                    if (need_Login == null) 
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Somthing went Wrong!");
                    }

                    //var emp = employeeRepository.GetEmployeeByEmail(need_Login.email);

                    var emailCheck = needDbEntities.need_login_table.FirstOrDefault(e => e.email == need_Login.email);
                    var phoneCheck = needDbEntities.need_login_table.Find(need_Login.mobile_number);
                    

                    if (phoneCheck != null)
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Phone is already in use");
                    }

                    if (emailCheck != null)
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Email is already in use");
                    }

                 

                    if (need_Login.email == "" || need_Login.email == null)
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Emailid is Mendetory");
                    }

                    if (need_Login.first_name == "" || need_Login.first_name == null || need_Login.last_name == "" || need_Login.last_name == null)
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "first name and last name is Mendetory");
                    }

                    if (need_Login.password == null || need_Login.password == "" || need_Login.password.Length < 8)
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Password should be more than 8 character");
                    }

                    if (need_Login.gender == null || need_Login.gender == "")
                    {
                        isEverythingOk = false;
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Gender is mendetory");
                    }

                    if(isEverythingOk)
                    {
                        needDbEntities.need_login_table.Add(need_Login);
                        needDbEntities.SaveChanges();
                        var message = Request.CreateResponse(HttpStatusCode.Created, need_Login);
                        message.Headers.Location = new Uri(Request.RequestUri + "");
                        return message;
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Somthing Went Wrong");
                    }
                }
                catch (Exception e) 
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e); 
                }
            }
        }


        public string Encryptword(string Encryptval)
        {
            byte[] SrctArray;
            byte[] EnctArray = UTF8Encoding.UTF8.GetBytes(Encryptval);
            SrctArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objcrpt = new MD5CryptoServiceProvider();
            SrctArray = objcrpt.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            objcrpt.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateEncryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(EnctArray, 0, EnctArray.Length);
            objt.Clear();
            return Convert.ToBase64String(resArray, 0, resArray.Length);
        }


        public string Decryptword(string DecryptText)
        {
            byte[] SrctArray;
            byte[] DrctArray = Convert.FromBase64String(DecryptText);
            SrctArray = UTF8Encoding.UTF8.GetBytes(key);
            TripleDESCryptoServiceProvider objt = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider objmdcript = new MD5CryptoServiceProvider();
            SrctArray = objmdcript.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            objmdcript.Clear();
            objt.Key = SrctArray;
            objt.Mode = CipherMode.ECB;
            objt.Padding = PaddingMode.PKCS7;
            ICryptoTransform crptotrns = objt.CreateDecryptor();
            byte[] resArray = crptotrns.TransformFinalBlock(DrctArray, 0, DrctArray.Length);
            objt.Clear();
            return UTF8Encoding.UTF8.GetString(resArray);
        }
    }
}
