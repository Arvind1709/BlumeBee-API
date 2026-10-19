namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterDepartment create/update operations.</summary>
    public class MasterDepartmentRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
