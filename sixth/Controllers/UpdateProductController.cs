using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sixth.Controllers
{
    public class UpdateProductController : ApiController
    {
        public IHttpActionResult Post([FromBody] need_product_details need_Product_Details)
        {
            try
            {
                using (needDbEntities needDbEntities = new needDbEntities())
                {

                    var productCheck = needDbEntities.need_product_details.Where(e => e.emailId == need_Product_Details.emailId).FirstOrDefault();

                    if (need_Product_Details == null)
                    {
                        return BadRequest("Product details can not be blank.");
                    }

                    if (productCheck != null)
                    {
                        productCheck.product_id = need_Product_Details.product_id;
                        productCheck.lat = need_Product_Details.lat;
                        productCheck.@long = need_Product_Details.@long;
                        productCheck.title = need_Product_Details.title;
                        productCheck.decription = need_Product_Details.decription;
                        productCheck.category = need_Product_Details.category;
                        productCheck.sub_category = need_Product_Details.sub_category;
                        productCheck.super_sub_catrgory = need_Product_Details.super_sub_catrgory;
                        productCheck.mobile_number = need_Product_Details.mobile_number;
                        productCheck.isactive = need_Product_Details.isactive;
                        productCheck.report_count = need_Product_Details.report_count;
                        productCheck.photo_one = need_Product_Details.photo_one;
                        productCheck.photo_two = need_Product_Details.photo_two;
                        productCheck.photo_three = need_Product_Details.photo_three;
                        productCheck.emailId = need_Product_Details.emailId;
                        productCheck.time_stamp = need_Product_Details.time_stamp;
                        needDbEntities.SaveChanges();
                        var data = needDbEntities.need_product_details.FirstOrDefault(e => e.emailId == need_Product_Details.emailId);
                        return Ok(data);
                    }
                    else
                    {
                        return BadRequest("Somthing went Wrong!");
                    }

                }
            }
            catch (Exception e)
            {
                return BadRequest("Somthing went Wrong!" + e.ToString());
            }
        }
    }
}
