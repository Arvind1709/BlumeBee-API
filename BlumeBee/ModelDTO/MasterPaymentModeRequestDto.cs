namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterPaymentMode create/update operations.</summary>
    public class MasterPaymentModeRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
