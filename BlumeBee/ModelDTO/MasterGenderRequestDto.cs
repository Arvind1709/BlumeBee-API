namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterGender create/update operations.</summary>
    public class MasterGenderRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
