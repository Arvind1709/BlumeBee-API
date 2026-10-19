namespace BlumeBee.Model
{
    public class StaffAttendanceModel
    {
        public long Id { get; set; }

        public DateTime AttendanceDate { get; set; }

        public long StaffId { get; set; }

        public int? AttendanceCodeId { get; set; }

        public int? LeaveTypeId { get; set; }

        public string? Remarks { get; set; }
    }
}
