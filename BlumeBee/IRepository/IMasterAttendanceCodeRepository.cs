using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterAttendanceCodeRepository
    {
        Task<List<MasterAttendanceCodeModel>> GetAllAsync();
        Task<MasterAttendanceCodeModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterAttendanceCodeModel model);
        Task<int> UpdateAsync(MasterAttendanceCodeModel model);
        Task<int> DeleteAsync(int id);
    }
}
