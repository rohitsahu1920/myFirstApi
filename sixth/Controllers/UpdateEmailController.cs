using sixth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class UpdateEmailController : ApiController
    {
        public IHttpActionResult Post([FromBody] update_phone_email update_Phone_Email)
        {
            using (needDbEntities needDbEntities = new needDbEntities())
            {
                try
                {
                    var loginCheck = needDbEntities.need_login_table.Where(e => e.mobile_number == update_Phone_Email.mobile).FirstOrDefault();

                    if (update_Phone_Email == null)
                    {
                        return BadRequest("Please Provide phone and Email");
                    }

                    if (loginCheck != null)
                    {
                        loginCheck.email = update_Phone_Email.email;
                        needDbEntities.SaveChanges();
                        var data = needDbEntities.need_login_table.FirstOrDefault(e => e.mobile_number == update_Phone_Email.mobile);
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Somthing went Wrong!");
                    }

                }
                catch (Exception e)
                {
                    return BadRequest("Somthing went Wrong!" + e.ToString());
                }
            }
        }
    }
}
