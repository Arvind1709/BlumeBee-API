using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterDepartmentRepository
    {
        Task<List<MasterDepartmentModel>> GetAllAsync();
        Task<MasterDepartmentModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterDepartmentModel model);
        Task<int> UpdateAsync(MasterDepartmentModel model);
        Task<int> DeleteAsync(int id);
    }
}
