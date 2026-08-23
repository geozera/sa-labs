using Ledger.Models;
using Ledger.Services;

var app = WebApplication.Create(args);

app.MapPost("/transactions", (AccountTransaction tx) =>
{
    TransactionService.PerformTransaction(tx);
    return Results.Ok(AccountService.Accounts);
});

app.MapDelete("/transactions/{id}", (string id) =>
{
    TransactionService.UndoTransaction(id);
    return Results.NoContent();
});

app.MapGet("/transactions", () => Results.Ok(TransactionService.Transactions));

app.MapGet("/accounts/{id}/entries", (string id) => Results.Ok(AccountService.GetEntries(id)));

app.Run();