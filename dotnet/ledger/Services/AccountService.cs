using Ledger.Models;

namespace Ledger.Services;

public static class AccountService
{

    public static readonly Account[] Accounts = [
    new Account ("1", "John", 5000, [ new Entry(Guid.NewGuid().ToString(), 5000, "CREDIT")]),
    new Account ("2", "Mary", 2900, [ new Entry(Guid.NewGuid().ToString(), 2900, "DEBIT")]),
    ];

    public static Account GetAccount(string accountId)
    =>
        accountId switch
        {
            "1" => Accounts[0],
            "2" => Accounts[1],
            _ => throw new Exception("Account not found.")
        };

    public static void AddBalance(AccountTransaction tx, string accountId, double amount)
    {
        Account subject = Accounts.First(x => x.Id == accountId);
        subject.AddBalance(tx);
    }

    public static void SubtractBalance(AccountTransaction tx, string accountId, double amount)
    {
        Account subject = Accounts.First(x => x.Id == accountId);
        subject.SubtractBalance(tx);
    }

    public static List<Entry> GetEntries(string accountId) => GetAccount(accountId).Entries;

}