using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Minizon.Pricing.Commands;
using Minizon.Pricing.Domain;
using NServiceBus;
using Raven.Client;

namespace Minizon.Pricing
{
    public class PricingController : ApiController
    {
        private readonly IBus bus;
        private readonly IDocumentSession documentSession;

        public PricingController(IBus bus, IDocumentSession documentSession)
        {
            this.bus = bus;
            this.documentSession = documentSession;
        }

        // GET api/pricing
        public IEnumerable<BookPricing> Get()
        {
            var pricings = documentSession.Query<BookPricing>();
            return pricings;
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
                bus.Send<AddNewBookPricing>(x =>
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
