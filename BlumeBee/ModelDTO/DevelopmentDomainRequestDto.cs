namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for DevelopmentDomain create/update operations.</summary>
    public class DevelopmentDomainRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
