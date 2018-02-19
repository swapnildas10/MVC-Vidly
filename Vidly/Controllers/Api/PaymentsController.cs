using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using Vidly.Models;
using Vidly.Utils;

namespace Vidly.Controllers.Api
{
    public class PaymentsController : ApiController
    {
        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody] PaymentData data)
        {
            
            ChargeWithToken charge = new ChargeWithToken((long)(Convert.ToDouble(data.Amount)*100), data.Token);
            if (charge.PaymentResult() == EnumSuccessFail.SUCCESS)
            {
                return Ok();
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, "Payment Failed");
            }
        }

        // PUT api/<controller>/5
        public void Put(int id,  string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}