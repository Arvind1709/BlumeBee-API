namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterStudentStatus create/update operations.</summary>
    public class MasterStudentStatusRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
