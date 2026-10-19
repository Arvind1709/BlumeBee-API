using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterItemConditionRepository
    {
        Task<List<MasterItemConditionModel>> GetAllAsync();
        Task<MasterItemConditionModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterItemConditionModel model);
        Task<int> UpdateAsync(MasterItemConditionModel model);
        Task<int> DeleteAsync(int id);
    }
}
