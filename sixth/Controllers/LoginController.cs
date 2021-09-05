using Newtonsoft.Json.Linq;
using sixth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace sixth.Controllers
{
    public class LoginController : ApiController
    {
        public object UrlUtil { get; private set; }

        public HttpResponseMessage Post([FromBody] login_model login_Model)
        {
            using (needDbEntities needDbEntities = new needDbEntities())
            {
                try
                {
                    var emailCheck = needDbEntities.need_login_table.FirstOrDefault(e => e.email == login_Model.email);

                    var loginCheck = needDbEntities.need_login_table.Where(e => e.email == login_Model.email && e.password == login_Model.password).FirstOrDefault();

                    if (emailCheck == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Email is not Register yet. Please Register Your self");
                    }

                    if (loginCheck != null)
                    {
                        var response = Request.CreateResponse(HttpStatusCode.OK);
                        response.Content = new StringContent(needDbEntities.need_login_table.FirstOrDefault(e => e.email == login_Model.email).ToString(), Encoding.UTF8, "application/json");
                        return response;

                        //need_login_table need_login_table = needDbEntities.need_login_table.FirstOrDefault(e => e.email == login_Model.email);
                        //return Request.CreateErrorResponse(HttpStatusCode.OK, need_login_table.ToString());
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Username or Password is wrong.");
                    }
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
                }
                

                
            }
        }
    }
}
