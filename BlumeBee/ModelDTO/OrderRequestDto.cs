namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for Order create/update operations.</summary>
    public class OrderRequestDto
    {
        public decimal Amount { get; set; }
        public string DiscountType { get; set; }
    }
}
