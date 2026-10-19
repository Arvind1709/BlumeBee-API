using BlumeBee.Model;
using BlumeBee.ModelDTO;
using System.Data;

namespace BlumeBee.IRepository
{
    public interface IStudentRepository
    {
        // public List<StudentModel> GetAllStudents();
        //public int AddStudent(string name);

        public List<StudentModel> GetAllStudents();

        public StudentModel? GetStudentById(long id);

        public int AddStudent(StudentCreateDto student);

        public int UpdateStudent(long id, StudentUpdateDto student);

        public int DeleteStudent(long id);
    }
}
