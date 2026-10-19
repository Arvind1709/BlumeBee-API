using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterPaymentModeRepository
    {
        Task<List<MasterPaymentModeModel>> GetAllAsync();
        Task<MasterPaymentModeModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterPaymentModeModel model);
        Task<int> UpdateAsync(MasterPaymentModeModel model);
        Task<int> DeleteAsync(int id);
    }
}
