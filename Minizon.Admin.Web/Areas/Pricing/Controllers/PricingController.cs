using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Minizon.Pricing.Commands;
using Minizon.Pricing.Messages;

namespace Minizon.Admin.Web.Areas.Pricing.Controllers
{
    public class PricingController : ApiController
    {
        // GET api/pricing
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/pricing/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/pricing
        public HttpResponseMessage Post([FromBody]BookPricingViewModel viewModel)
        {
            try
            {
                MvcApplication.Bus.Send<AddNewBookPricing>(x =>
                {
                    x.ISBN = viewModel.ISBN;
                    x.OurPrice = viewModel.OurPrice;
                });
                return Request.CreateResponse(HttpStatusCode.Created, viewModel);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

        }

        // PUT api/pricing/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/pricing/5
        public void Delete(int id)
        {
        }
    }

    public class BookPricingViewModel
    {
        public string ISBN { get; set; }
        public double OurPrice { get; set; }
    }
}
