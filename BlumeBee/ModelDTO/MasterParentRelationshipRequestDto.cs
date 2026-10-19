namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterParentRelationship create/update operations.</summary>
    public class MasterParentRelationshipRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
