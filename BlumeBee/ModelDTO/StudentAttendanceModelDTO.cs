namespace BlumeBee.ModelDTO
{
    public class StudentAttendanceModelDTO
    {
        public DateTime AttendanceDate { get; set; }

        public long StudentId { get; set; }

        public int? ClassId { get; set; }

        public int? AttendanceCodeId { get; set; }

        public string? Remarks { get; set; }
    }
}
