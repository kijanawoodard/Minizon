using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Minizon.Catalog.Messages;

namespace Minizon.Admin.Web.Areas.Catalog.Controllers
{
    public class CatalogController : ApiController
    {
        // GET api/catalog
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/catalog/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/catalog
        public HttpResponseMessage Post([FromBody]CatalogBookViewModel viewModel)
        {
            try
            {
                MvcApplication.Bus.Send<AddNewBook>(x =>
                {
                    x.ISBN = viewModel.Isbn;
                    x.Name = viewModel.Name;
                    x.Author = viewModel.Author;
                    x.SuggestedPrice = viewModel.SuggestedPrice;
                });
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
