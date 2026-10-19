namespace BlumeBee.Model
{
    public class MasterLeadStatusModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? SortOrder { get; set; }
    }
}
