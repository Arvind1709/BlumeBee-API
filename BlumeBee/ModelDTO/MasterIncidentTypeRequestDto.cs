namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterIncidentType create/update operations.</summary>
    public class MasterIncidentTypeRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
