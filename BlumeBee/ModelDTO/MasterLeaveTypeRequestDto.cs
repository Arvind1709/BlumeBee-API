namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterLeaveType create/update operations.</summary>
    public class MasterLeaveTypeRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
