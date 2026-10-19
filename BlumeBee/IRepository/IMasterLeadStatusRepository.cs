using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterLeadStatusRepository
    {
        Task<List<MasterLeadStatusModel>> GetAllAsync();
        Task<MasterLeadStatusModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterLeadStatusModel model);
        Task<int> UpdateAsync(MasterLeadStatusModel model);
        Task<int> DeleteAsync(int id);
    }
}
