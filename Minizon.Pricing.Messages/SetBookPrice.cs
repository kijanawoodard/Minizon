namespace Minizon.Pricing.Messages
{
    public class SetBookPrice
    {
        public string ISBN { get; set; }
        public decimal price { get; set; }
    }
}