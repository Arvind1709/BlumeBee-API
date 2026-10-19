using BlumeBee.IRepository;

namespace BlumeBee.Repositories
{
    public class PremiumUserDiscount : IDiscount
    {
        public string Type => "PremiumUser";

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * 0.50m); // 10% discount
        }

    }
}
