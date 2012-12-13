namespace Minizon.Catalog.Domain
{
    public class Book
    {
        //todo: investigate how to do it via conventions (Raven 2.0+)
        public string Id { get { return "Books/" + ISBN; } }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public double SuggestedPrice { get; set; }
    }
}