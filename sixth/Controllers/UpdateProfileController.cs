using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class UpdateProfileController : ApiController
    {
        public IHttpActionResult Post([FromBody] need_login_table need_Login)
        {
            using (needDbEntities entities = new needDbEntities())
            {
                try
                {
                    
                    var loginCheck = entities.need_login_table.Where(e => e.email == need_Login.email).FirstOrDefault();

                    if (need_Login == null)
                    {
                        return BadRequest("Your Profile details can not be blank.");
                    }

                    if (loginCheck != null)
                    {
                        loginCheck.first_name = need_Login.first_name;
                        loginCheck.last_name = need_Login.last_name;
                        loginCheck.gender = need_Login.gender;
                        loginCheck.profile_image = need_Login.profile_image;
                        entities.SaveChanges();
                        var data = entities.need_login_table.FirstOrDefault(e => e.email == need_Login.email);
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
