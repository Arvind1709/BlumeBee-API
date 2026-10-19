using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterIncidentTypeRepository
    {
        Task<List<MasterIncidentTypeModel>> GetAllAsync();
        Task<MasterIncidentTypeModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterIncidentTypeModel model);
        Task<int> UpdateAsync(MasterIncidentTypeModel model);
        Task<int> DeleteAsync(int id);
    }
}
