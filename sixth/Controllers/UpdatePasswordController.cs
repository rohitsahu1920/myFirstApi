using sixth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class UpdatePasswordController : ApiController
    {
        public IHttpActionResult Post([FromBody] update_password password)
        {
            using (needDbEntities needDbEntities = new needDbEntities())
            {
                try
                {
                    var emailCheck = needDbEntities.need_login_table.Where(e => e.email == password.email).FirstOrDefault();

                    if (password == null || password.password.Length < 8)
                    {
                        return BadRequest("Password cannot be Empty or less than 8 character");
                    }

                    if (emailCheck != null)
                    {
                        emailCheck.password = password.password;
                        needDbEntities.SaveChanges();
                        var data = needDbEntities.need_login_table.FirstOrDefault(e => e.email == password.email);
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
