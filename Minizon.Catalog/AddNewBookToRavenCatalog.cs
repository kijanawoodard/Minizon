using Minizon.Catalog.Domain;
using Minizon.Catalog.Messages;
using NServiceBus;
using Raven.Client;

namespace Minizon.Catalog
{
    public class AddNewBookToRavenCatalog : IHandleMessages<AddNewBook>
    {
        private readonly IBus bus;
        private readonly IDocumentSession documentSession;

        public AddNewBookToRavenCatalog(IBus bus, IDocumentSession documentSession)
        {
            this.bus = bus;
            this.documentSession = documentSession;
        }

        public void Handle(AddNewBook message)
        {
            var book = new Book
                           {
                               ISBN = message.ISBN, Name = message.Name, Author = message.Author, SuggestedPrice = message.SuggestedPrice
                           };
            documentSession.Store(book);
            documentSession.SaveChanges();
        }
    }
}