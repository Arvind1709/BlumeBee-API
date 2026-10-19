using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterProgramRepository
    {
        Task<List<MasterProgramModel>> GetAllAsync();
        Task<MasterProgramModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterProgramModel model);
        Task<int> UpdateAsync(MasterProgramModel model);
        Task<int> DeleteAsync(int id);
    }
}
