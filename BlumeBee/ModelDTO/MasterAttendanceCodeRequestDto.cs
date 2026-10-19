namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterAttendanceCode create/update operations.</summary>
    public class MasterAttendanceCodeRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
