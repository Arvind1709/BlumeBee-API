namespace BlumeBee.ModelDTO
{
    /// <summary>Request payload for Center create/update operations.</summary>
    public class CenterRequestDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; } = "India";
        public string Pincode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
