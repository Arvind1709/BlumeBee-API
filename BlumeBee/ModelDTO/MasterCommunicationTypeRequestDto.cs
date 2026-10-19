namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterCommunicationType create/update operations.</summary>
    public class MasterCommunicationTypeRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
