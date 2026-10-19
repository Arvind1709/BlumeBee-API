using BlumeBee.Model;
using BlumeBee.ModelDTO;

namespace BlumeBee.IRepository
{
    public interface IStaffRepository
    {
        List<StaffModel> GetAll();

        StaffModel? GetById(long id);

        long Insert(StaffModelDTO model);

        bool Update(long id, StaffModelDTO model);

        bool Delete(long id);
    }
}
