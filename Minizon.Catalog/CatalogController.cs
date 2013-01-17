using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Minizon.Catalog.Commands;
using Minizon.Catalog.Domain;
using NServiceBus;
using Raven.Client;

namespace Minizon.Catalog
{
    public class CatalogController : ApiController
    {
        private readonly IBus bus;
        private readonly IDocumentSession documentSession;

        public CatalogController(IBus bus, IDocumentSession documentSession)
        {
            this.bus = bus;
            this.documentSession = documentSession;
        }

        // GET api/catalog
        public HttpResponseMessage  Get()
        {
            var books = documentSession.Query<Book>().ToList();
            return Request.CreateResponse<IEnumerable<Book>>(HttpStatusCode.OK, books);
        }

        // GET api/catalog/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/catalog
        public HttpResponseMessage Post([FromBody]AddNewBook viewModel)
        {
            try
            {
                bus.Send(viewModel);
                return Request.CreateResponse(HttpStatusCode.Created, viewModel);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        // PUT api/catalog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/catalog/5
        public void Delete(int id)
        {
        }
    }

    public class CatalogBookViewModel
    {
        public string Name { get; set; }
        public string Isbn { get; set; }
        public string Author { get; set; }
        public double SuggestedPrice { get; set; }
    }

}
