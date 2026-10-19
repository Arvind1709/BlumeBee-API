using BlumeBee.IRepository;

namespace BlumeBee.Repositories
{
    public class PercentageDiscount : IDiscount
    {
        public string Type => "Percentage";

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * 0.10m); // 10% discount
        }
    }
}
