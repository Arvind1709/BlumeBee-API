namespace BlumeBee.Model
{
    public class MasterClassModel
    {
        public int Id { get; set; }

        public int? ProgramId { get; set; }
        public MasterProgramModel Program { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public int? Capacity { get; set; }
        public bool IsActive { get; set; } = true;
        public int? SortOrder { get; set; }
    }
}
