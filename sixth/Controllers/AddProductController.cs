using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers.Product
{
    public class AddProductController : ApiController
    {
        public IHttpActionResult Post([FromBody] need_product_details need_Product_Details)
        {
            using (needDbEntities needDbEntities = new needDbEntities())
            {
                try
                {
                    bool isEverythingOk = true;

                    if (need_Product_Details == null)
                    {
                        isEverythingOk = false;
                        return BadRequest("Product details can not be Blank!");
                    }

                    if (need_Product_Details.product_id == null || need_Product_Details.product_id == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Product ID can not be Blank!");
                    }

                    if (need_Product_Details.time_stamp == null || need_Product_Details.time_stamp == null)
                    {
                        isEverythingOk = false;
                        return BadRequest("Need Time Stamp");
                    }

                    if (need_Product_Details.photo_one == null || need_Product_Details.photo_one == "") 
                    {
                        isEverythingOk = false;
                        return BadRequest("Enter atleast 1 Image and Max 3 Images");
                    }

                    if (need_Product_Details.lat == null || need_Product_Details.lat == "" || need_Product_Details.@long == null || need_Product_Details.@long == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Please Provide lat and Long.");
                    }

                    if (need_Product_Details.title == null || need_Product_Details.title == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Title can not be empty");
                    }

                    if (need_Product_Details.decription == null || need_Product_Details.decription == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Description can not be Empty");
                    }

                    if (need_Product_Details.category == null || need_Product_Details.category == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Category can not be Empty");
                    }

                    if (need_Product_Details.mobile_number == null || need_Product_Details.mobile_number == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Mobile Number can not be Empty");
                    }

                    if (need_Product_Details.emailId == null || need_Product_Details.emailId == "")
                    {
                        isEverythingOk = false;
                        return BadRequest("Email ID can not be Empty");
                    }

                    if (isEverythingOk)
                    {
                        needDbEntities.need_product_details.Add(need_Product_Details);
                        needDbEntities.SaveChanges();
                        var data = needDbEntities.need_product_details.FirstOrDefault(e => e.emailId == need_Product_Details.emailId && e.product_id == need_Product_Details.product_id);
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Somthing went Wrong!");
                    }
                }
                catch (Exception e)
                {
                    return BadRequest("Somthing went Wrong!" + e);
                }
            }
        }
    }
}
