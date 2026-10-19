using BlumeBee.IRepository;
using BlumeBee.Model;

namespace BlumeBee.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void Save(OrderModel order)
        {
            // simulate DB save
        }
    }
}
