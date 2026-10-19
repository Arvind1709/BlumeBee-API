using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface IDevelopmentDomainRepository
    {
        Task<List<DevelopmentDomainModel>> GetAllAsync();
        Task<DevelopmentDomainModel> GetByIdAsync(int id);
        Task<int> CreateAsync(DevelopmentDomainModel model);
        Task<int> UpdateAsync(DevelopmentDomainModel model);
        Task<int> DeleteAsync(int id);
    }
}
