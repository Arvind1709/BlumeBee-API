namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterStaffRole create/update operations.</summary>
    public class MasterStaffRoleRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? SortOrder { get; set; }
    }
}
