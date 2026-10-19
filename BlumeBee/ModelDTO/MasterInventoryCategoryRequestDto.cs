namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for MasterInventoryCategory create/update operations.</summary>
    public class MasterInventoryCategoryRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
