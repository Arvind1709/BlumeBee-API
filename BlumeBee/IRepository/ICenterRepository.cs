using BlumeBee.Model;

namespace BlumeBee.IRepository
{
    public interface ICenterRepository
    {
        IEnumerable<CenterModel> GetAllActive();
        IEnumerable<CenterModel> GetAllNonActive();
        CenterModel GetById(int id);
        int Create(CenterModel center);
        int Update(CenterModel center);
        int Delete(int id);
    }
}
