using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface ILeadRepository
    {
        Task<List<LeadModel>> GetAllAsync();
        Task<LeadModel> GetByIdAsync(long id);
        Task<int> CreateAsync(LeadModel model);
        Task<int> UpdateAsync(LeadModel model);
        Task<int> DeleteAsync(long id);
    }
}
