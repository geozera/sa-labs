Implementation of a Ledger system for a financial double-entry registry.

The main objective of a ledger system is to store events as an append-only database. This means that all entries must never be updated or deleted. All information is incremental.

The double-entry pattern serves as a complementary layer of security, since it increases the rastreability of each entry by recording the credits and debits at the same time.

## Features

- Register a financial entry.
- Reverse a financial entry. (Copy all information from the supplied entry ID, but reverse it's type).
- Retrieve all entries from a specific account.

## Stack
- .NET 10 Minimal API
- Docker for containerization

## Usage

#### Pre-requisites

- Docker
- REST Client (e.g Postman, Insomnia or curl)

#### 1. Serve application

```bash
cd ledger
docker compose up -d
```

#### 2. Create transaction

`POST /transactions`

Sample payload

````json
{
    "amount" : "2500",
    "fromAccountId": "1",
    "toAccountId": "2"
}
````

Response

````json
[
  {
    "id": "1",
    "name": "John",
    "balance": 2500,
    "entries": [
      {
        "id": "6eec927b-92a4-4fb7-9272-c8db97d3fff7",
        "transactionId": "413bf83d-3082-4a01-8344-af30b8b25cac",
        "amount": 5000,
        "type": "CREDIT"
      },
      {
        "id": "7b2f31a6-10bb-4b22-877e-3e54ac29307f",
        "transactionId": "ab902525-565f-4cda-80a5-316d5d07a903",
        "amount": 2500,
        "type": "DEBIT"
      }
    ]
  },
  {
    "id": "2",
    "name": "Mary",
    "balance": 5400,
    "entries": [
      {
        "id": "e2641427-6b6c-44fc-9235-ede1b18cb538",
        "transactionId": "417f2077-3c5a-4a4f-bd49-5131c7534848",
        "amount": 2900,
        "type": "DEBIT"
      },
      {
        "id": "54ab03f5-0c5f-46ef-a4c7-6e18af5bb52c",
        "transactionId": "ab902525-565f-4cda-80a5-316d5d07a903",
        "amount": 2500,
        "type": "CREDIT"
      }
    ]
  }
]
````

#### 3. Reverse entry

` DELETE /transactions/{id}`

#### 4. List Transactions

GET /transactions