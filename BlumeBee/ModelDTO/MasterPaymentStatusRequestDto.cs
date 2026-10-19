namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterPaymentStatus create/update operations.</summary>
    public class MasterPaymentStatusRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
