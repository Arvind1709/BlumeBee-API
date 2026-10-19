namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterSeverity create/update operations.</summary>
    public class MasterSeverityRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? SeverityRank { get; set; }
    }
}
