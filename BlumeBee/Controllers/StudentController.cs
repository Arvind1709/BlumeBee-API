using BlumeBee.IRepository;
using BlumeBee.Model;
using BlumeBee.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace BlumeBee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        

        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        // GET: api/Student/students
        // Lightweight lookup for dropdowns
        [HttpGet("students")]
        public ActionResult<List<StudentCreateDto>> GetStudents()
        {
            var students = _repo.GetAllStudents()
                    .Select(student => new StudentCreateDto
                    {
                        Id = student.Id,
                        CenterName = student.CenterName,
                        StudentCode = student.StudentCode,
                        CenterId = student.CenterId,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        FullName = student.FullName,
                        GenderId = student.GenderId,
                        Dob = student.Dob,
                        BloodGroup = student.BloodGroup,
                        Allergies = student.Allergies,
                        MedicalNotes = student.MedicalNotes,
                        SpecialSupportNotes = student.SpecialSupportNotes,
                        AddressLine1 = student.AddressLine1,
                        AddressLine2 = student.AddressLine2,
                        City = student.City,
                        State = student.State,
                        Pincode = student.Pincode,
                        AadhaarRef = student.AadhaarRef,
                        StudentStatusId = student.StudentStatusId,
                        Remarks = student.Remarks
                    })
                    .ToList();


            return Ok(students);
        }

        // GET: api/Student
        [HttpGet]
        public ActionResult<List<StudentCreateDto>> GetAllStudents()
        {
            return Ok(_repo.GetAllStudents());
        }

        // GET: api/Student/5
        [HttpGet("{id:long}")]
        public ActionResult<StudentCreateDto> GetStudentById(long id)
        {
            var student = _repo.GetStudentById(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = $"Student with ID {id} was not found."
                });
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult AddStudent(
            [FromBody] StudentCreateDto student)
        {
            int rowsAffected = _repo.AddStudent(student);

            if (rowsAffected == 0)
            {
                return BadRequest(new
                {
                    message = "Student could not be added."
                });
            }

            return Ok(new
            {
                message = "Student added successfully."
            });
        }

        // PUT: api/Student/5
        [HttpPut("{id:long}")]
        public IActionResult UpdateStudent(
            long id,
            [FromBody] StudentUpdateDto student)
        {
            int rowsAffected = _repo.UpdateStudent(id, student);

            if (rowsAffected == 0)
            {
                return NotFound(new
                {
                    message = $"Student with ID {id} was not found."
                });
            }

            return Ok(new
            {
                message = "Student updated successfully."
            });
        }

        // DELETE: api/Student/5
        [HttpDelete("{id:long}")]
        public IActionResult DeleteStudent(long id)
        {
            int rowsAffected = _repo.DeleteStudent(id);

            if (rowsAffected == 0)
            {
                return NotFound(new
                {
                    message = $"Student with ID {id} was not found."
                });
            }

            return Ok(new
            {
                message = "Student deleted successfully."
            });
        }
    }
}
