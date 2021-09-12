using sixth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class UserProductController : ApiController
    {
        public IHttpActionResult Post([FromBody] user_product use_Product)
        {
            try
            {
                using (needDbEntities needDbEntities = new needDbEntities())
                {
                    var values = needDbEntities.need_product_details.AsParallel().Where(e => e.emailId == use_Product.email);
                    return Ok(values.ToList());
                }
            }
            catch (Exception e)
            {
                return BadRequest("Somthing went Wrong!" + e);
            }
        }
    }
}
