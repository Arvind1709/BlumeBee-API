namespace BlumeBee.ModelDTO
{
    /// <summary>Minimal student data returned by the student lookup endpoint.</summary>
    public class StudentLookupDto
    {
        public long Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
    }
}
