namespace Minizon.Pricing.Domain
{
    public class BookPricing
    {
        public string Id { get; private set; } 
        public string BookId { get; set; } 
        public double Price { get; set; } 
    }
}