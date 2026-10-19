namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterProgram create/update operations.</summary>
    public class MasterProgramRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? AgeMinMonths { get; set; }
        public int? AgeMaxMonths { get; set; }
        public bool IsActive { get; set; } = true;
        public int? SortOrder { get; set; }
    }
}
