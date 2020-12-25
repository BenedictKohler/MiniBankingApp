// Transaction service interface

using MyManagerShared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManagerUI.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> GetTransactions();

        Task<HttpResponseMessage> PostTransaction(Transaction transaction); // Create a new transaction

        Task<Transaction> GetTransaction(int id);

        Task<IEnumerable<Transaction>> GetTransactionsByUser(int userId);

        Task<HttpResponseMessage> PutTransaction(Transaction transaction, int id); // Update a transaction

        Task<HttpResponseMessage> DeleteTransaction(int id);
    }
}
