using BlumeBee.Model;
using BlumeBee.ModelDTO;

namespace BlumeBee.IRepository
{
    public interface IParentRepository
    {
        List<ParentModel> GetAll();
        ParentModel? GetById(long id);
        long Insert(ParentModelDTO model);
        bool Update(long id, ParentModelDTO model);
        bool Delete(long id);
    }
}
