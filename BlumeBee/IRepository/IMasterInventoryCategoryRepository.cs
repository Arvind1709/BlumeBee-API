using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterInventoryCategoryRepository
    {
        Task<List<MasterInventoryCategoryModel>> GetAllAsync();
        Task<MasterInventoryCategoryModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterInventoryCategoryModel model);
        Task<int> UpdateAsync(MasterInventoryCategoryModel model);
        Task<int> DeleteAsync(int id);
    }
}
