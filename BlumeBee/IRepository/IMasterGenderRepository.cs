using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterGenderRepository
    {
        Task<List<MasterGenderModel>> GetAllAsync();
        Task<MasterGenderModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterGenderModel model);
        Task<int> UpdateAsync(MasterGenderModel model);
        Task<int> DeleteAsync(int id);
    }
}
