using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterSeverityRepository
    {
        Task<List<MasterSeverityModel>> GetAllAsync();
        Task<MasterSeverityModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterSeverityModel model);
        Task<int> UpdateAsync(MasterSeverityModel model);
        Task<int> DeleteAsync(int id);
    }
}
