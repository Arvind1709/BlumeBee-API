using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterLeaveTypeRepository
    {
        Task<List<MasterLeaveTypeModel>> GetAllAsync();
        Task<MasterLeaveTypeModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterLeaveTypeModel model);
        Task<int> UpdateAsync(MasterLeaveTypeModel model);
        Task<int> DeleteAsync(int id);
    }
}
