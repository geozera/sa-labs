namespace Ledger.Models;

public class Account(string Id, string Name, double Balance, List<Entry> Entries)
{
    public string Id { get; } = Id;
    public string Name { get; } = Name;
    public double Balance { get; private set; } = Balance;
    public List<Entry> Entries { get; } = Entries;

    public Account AddBalance (AccountTransaction tx)
    {
        Entry newEntry = new(tx.Id, tx.Amount, "CREDIT");
        Entries.Add(newEntry);
        Balance += tx.Amount;

        Console.WriteLine($"New balance for \"{Id}\": {Balance}");

        return this;
    }

    public Account SubtractBalance (AccountTransaction tx)
    {
        if((Balance - tx.Amount) < 0 )
        {
            throw new Exception($"Invalid operation. Can't subtract {tx.Amount} from {Balance}");
        }

        Entry newEntry = new(tx.Id, tx.Amount, "DEBIT");
        Entries.Add(newEntry);
        Balance -= tx.Amount;

        Console.WriteLine($"New balance for \"{Id}\": {Balance}");

        return this;

    }
}