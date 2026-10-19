using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IOrderRepository
    {
        void Save(OrderModel order);
    }
}
