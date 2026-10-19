using BlumeBee.IRepository;
using BlumeBee.Model;

namespace BlumeBee.Repositories
{
    public class OrderService : IOrderService
    {
        private readonly IEnumerable<IDiscount> _discounts;
        private readonly IOrderRepository _repo;

        public OrderService(IEnumerable<IDiscount> discounts, IOrderRepository repo)
        {
            _discounts = discounts;
            _repo = repo;
        }

        public decimal ProcessOrder(OrderModel order)
        {
            var discount = _discounts
                .FirstOrDefault(x => x.Type == order.DiscountType);

            if (discount == null)
                return order.Amount;

            var finalAmount = discount.ApplyDiscount(order.Amount);

            _repo.Save(order);

            return finalAmount;
        }
    }
}
