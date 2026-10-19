using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterStudentStatusRepository
    {
        Task<List<MasterStudentStatusModel>> GetAllAsync();
        Task<MasterStudentStatusModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterStudentStatusModel model);
        Task<int> UpdateAsync(MasterStudentStatusModel model);
        Task<int> DeleteAsync(int id);
    }
}
