using Ledger.Models;

namespace Ledger.Services;

public static class TransactionService
{
    public static List<AccountTransaction> Transactions { get; private set; } = [];
    public static void PerformTransaction(AccountTransaction tx)
    {
        AccountService.SubtractBalance(tx, tx.FromAccountId, tx.Amount);
        AccountService.AddBalance(tx, tx.ToAccountId, tx.Amount);
        Transactions.Add(tx);
    }
    public static void UndoTransaction(string txId)
    {
        AccountTransaction? originalTx = Transactions.FirstOrDefault(x => x.Id == txId) ?? throw new Exception($"Transaction {txId} not found.");
        PerformTransaction(Reverse(originalTx));
    }

    private static AccountTransaction Reverse(AccountTransaction target) =>
         new(target.ToAccountId, target.FromAccountId, target.Amount);
}