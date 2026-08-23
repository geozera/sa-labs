namespace Ledger.Models;

public class AccountTransaction
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public double Amount { get; private set; }
    public string FromAccountId { get; private set; }
    public string ToAccountId { get; private set; }

    public AccountTransaction(string FromAccountId, string ToAccountId, double Amount)
    {
        this.ToAccountId = ToAccountId;
        this.FromAccountId = FromAccountId;
        if (Amount <= 0) throw new InvalidOperationException("Invalid amount for the Transaction.");
        this.Amount = Amount;
    }

}