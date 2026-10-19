using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterPaymentStatusRepository
    {
        Task<List<MasterPaymentStatusModel>> GetAllAsync();
        Task<MasterPaymentStatusModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterPaymentStatusModel model);
        Task<int> UpdateAsync(MasterPaymentStatusModel model);
        Task<int> DeleteAsync(int id);
    }
}
