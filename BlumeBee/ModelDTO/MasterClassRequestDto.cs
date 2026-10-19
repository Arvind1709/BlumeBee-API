namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterClass create/update operations.</summary>
    public class MasterClassRequestDto
    {
        public int Id { get; set; }
        public int? ProgramId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public int? SortOrder { get; set; }
    }
}
