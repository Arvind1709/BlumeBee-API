namespace BlumeBee.ModelDTO
{
    public class StaffAttendanceModelDTO
    {
        public DateTime AttendanceDate { get; set; }

        public long StaffId { get; set; }

        public int? AttendanceCodeId { get; set; }

        public int? LeaveTypeId { get; set; }

        public string? Remarks { get; set; }
    }
}
