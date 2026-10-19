using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterClassRepository
    {
        Task<List<MasterClassModel>> GetAllAsync();
        Task<MasterClassModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterClassModel model);
        Task<int> UpdateAsync(MasterClassModel model);
        Task<int> DeleteAsync(int id);
    }
}
