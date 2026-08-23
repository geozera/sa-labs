namespace Ledger.Models;

public class Entry (string TransactionId, double Amount, string Type)
{
    public string Id {get;} = Guid.NewGuid().ToString();
    public string TransactionId {get; } = TransactionId;
    public double Amount {get;} = Amount;
    public string Type {get;} = Type;
}