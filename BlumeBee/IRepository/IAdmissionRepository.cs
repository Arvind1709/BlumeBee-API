using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IAdmissionRepository
    {
        Task<List<AdmissionModel>> GetAllAsync();
        Task<AdmissionModel> GetByIdAsync(long id);
        Task<int> CreateAsync(AdmissionModel model);
        Task<int> UpdateAsync(AdmissionModel model);
        Task<int> DeleteAsync(long id);
    }
}
