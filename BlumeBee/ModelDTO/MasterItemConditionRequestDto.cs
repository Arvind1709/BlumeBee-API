namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterItemCondition create/update operations.</summary>
    public class MasterItemConditionRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
