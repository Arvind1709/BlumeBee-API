using BlumeBee.Model;
using BlumeBee.ModelDTO;

namespace BlumeBee.IRepository
{
    public interface IStudentAttendanceRepository
    {
        List<StudentAttendanceModel> GetAll();

        StudentAttendanceModel? GetById(long id);

        long Insert(StudentAttendanceModelDTO model);

        bool Update(long id, StudentAttendanceModelDTO model);

        bool Delete(long id);
    }
}
