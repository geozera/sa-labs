Implementation of a Ledger system for a financial entry registry.

The main objective of a ledger system is to store events as an append-only database. This means that all entries must never be updated or deleted. All information is incremental.

## Features

- Register a financial entry.
- Reverse a financial entry. (Copy all information from the supplied entry ID, but reverse it's type)
- Retrieve all entries in a date interval.
- Retrieve all entries from a specific account.

## Stack
- .NET 10 Minimal API
- Database: PostreSQL
- Docker for containerization
- Docker compose for

## Usage

#### Pre-requisites

- Docker
- REST Client (e.g Postman, Insomnia or curl)

#### 1. Serve application

```bash
cd ledger
docker compose up -d
```

#### 2. Create entry

`POST /entries`

Sample payload

````json
{
    "amount" : "25.00",
    "type" : "CREDIT", // CREDIT/DEBIT
    "accountId": "1" 
}
````

Response

````json
{

}
````

#### 3. Reverse entry

` PATCH entries/<entryId>`

Sample payload

````json
{

}
````

Response

````json
{

}
````

#### 4. List entries

Response

````json
{

}
````