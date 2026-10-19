using BlumeBee.IRepository;

namespace BlumeBee.Repositories
{
    public class FlatDiscount : IDiscount
    {
        public string Type => "Flat";

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - 100; // flat ₹100 off
        }
    }
}
