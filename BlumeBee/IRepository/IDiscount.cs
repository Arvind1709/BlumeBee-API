namespace BlumeBee.IRepository
{
    public interface IDiscount
    {
        string Type { get; }
        decimal ApplyDiscount(decimal amount);
    }
}
