using BlumeBee.IRepository;

namespace BlumeBee.Repositories
{
    public class FestivalDiscount :IDiscount
    {
        public string Type => "Festival";

        public decimal ApplyDiscount(decimal amount)
        {
            return amount - (amount * 0.20m); // 10% discount
        }
    }
}
