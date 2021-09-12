using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class GetProductController : ApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                using (needDbEntities needDbEntities = new needDbEntities())
                {

                    var values = needDbEntities.need_product_details.AsParallel();

                    return Ok(values.ToList());
                }
            }
            catch (Exception e)
            {
                return BadRequest("Somthing went Wrong!" +e);
            }
        }
    }
}
