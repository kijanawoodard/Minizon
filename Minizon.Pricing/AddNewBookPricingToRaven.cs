using Minizon.Pricing.Domain;
using Minizon.Pricing.Messages;
using NServiceBus;
using Raven.Client;

namespace Minizon.Pricing
{
    public class AddNewBookPricingToRaven : IHandleMessages<AddNewBookPricing>
    {
        private readonly IBus bus;
        private readonly IDocumentSession documentSession;

        public AddNewBookPricingToRaven(IBus bus, IDocumentSession documentSession)
        {
            this.bus = bus;
            this.documentSession = documentSession;
        }

        public void Handle(AddNewBookPricing message)
        {
            var bookPricing = new BookPricing
                           {
                               BookId = "Books/"+message.ISBN,
                               Price = message.OurPrice
                           };
            documentSession.Store(bookPricing);
            documentSession.SaveChanges();
        }
    }
}