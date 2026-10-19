using BlumeBee.Model;
using BlumeBee.ModelDTO;

namespace BlumeBee.IRepository
{
    public interface IStaffAttendanceRepository
    {
        List<StaffAttendanceModel> GetAll();

        StaffAttendanceModel? GetById(long id);

        long Insert(StaffAttendanceModelDTO model);

        bool Update(long id, StaffAttendanceModelDTO model);

        bool Delete(long id);
    }
}
