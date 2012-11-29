namespace Minizon.Catalog.Messages
{
    public class AddNewBook
    {
        public string Name { get; set; }
        // ISBN == ID building block == reference throughout the system
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double SuggestedPrice { get; set; }
    }
}