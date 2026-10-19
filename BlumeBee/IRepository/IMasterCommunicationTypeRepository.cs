using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterCommunicationTypeRepository
    {
        Task<List<MasterCommunicationTypeModel>> GetAllAsync();
        Task<MasterCommunicationTypeModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterCommunicationTypeModel model);
        Task<int> UpdateAsync(MasterCommunicationTypeModel model);
        Task<int> DeleteAsync(int id);
    }
}
