// Class that communicates with the transaction web service and provides a way for users to make payment, deposits, view transactions, etc

using MyManagerShared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManagerUI.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly HttpClient httpClient;

        public TransactionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // Delete transaction by id
        public async Task<HttpResponseMessage> DeleteTransaction(int id)
        {
            return await httpClient.DeleteAsync("api/Transactions/" + id.ToString());
        }

        // Get transaction by id
        public async Task<Transaction> GetTransaction(int id)
        {
            return await httpClient.GetFromJsonAsync<Transaction>("api/Transactions/" + id.ToString());
        }

        // Gets a list of previous transactions
        public async Task<IEnumerable<Transaction>> GetTransactions()
        {
            return await httpClient.GetFromJsonAsync<Transaction[]>("api/Transactions/");
        }

        // Get transaction by a user id
        public async Task<IEnumerable<Transaction>> GetTransactionsByUser(int userId)
        {
            return await httpClient.GetFromJsonAsync<Transaction[]>("api/Transactions/ByUser/" + userId.ToString());
        }

        // Add a new transaction
        public async Task<HttpResponseMessage> PostTransaction(Transaction transaction)
        {
            return await httpClient.PostAsJsonAsync("api/Transactions/", transaction);
        }

        // Update an existing transaction
        public async Task<HttpResponseMessage> PutTransaction(Transaction transaction, int id)
        {
            return await httpClient.PutAsJsonAsync("api/Transactions/" + id.ToString(), transaction);
        }
    }
}
