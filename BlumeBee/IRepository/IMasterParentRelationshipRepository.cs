using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IMasterParentRelationshipRepository
    {
        Task<List<MasterParentRelationshipModel>> GetAllAsync();
        Task<MasterParentRelationshipModel> GetByIdAsync(int id);
        Task<int> CreateAsync(MasterParentRelationshipModel model);
        Task<int> UpdateAsync(MasterParentRelationshipModel model);
        Task<int> DeleteAsync(int id);
    }
}
