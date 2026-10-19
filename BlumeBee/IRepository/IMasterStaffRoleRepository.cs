using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterStaffRoleRepository
    {
        Task<List<MasterStaffRoleModel>> GetAllAsync();
        Task<MasterStaffRoleModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterStaffRoleModel model);
        Task<int> UpdateAsync(MasterStaffRoleModel model);
        Task<int> DeleteAsync(int id);
    }
}
