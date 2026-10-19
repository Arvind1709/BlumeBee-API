using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IOrderService
    {
        decimal ProcessOrder(OrderModel order);
    }
}
