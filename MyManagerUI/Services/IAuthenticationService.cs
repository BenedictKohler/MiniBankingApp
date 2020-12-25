// Authentication service interface

using MyManagerShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyManagerUI.Services
{
    public interface IAuthenticationService
    {
        Task<IEnumerable<User>> GetUsers();

        Task<HttpResponseMessage> PostUser(User user); // Create a new user

        Task<User> GetUser(int id);

        Task<User> GetUserByEmail(string email);

        Task<User> GetUserByBankNumber(int bankNumber);

        Task<HttpResponseMessage> PutUser(User user, int id); // Update a user

        Task<HttpResponseMessage> DeleteUser(int id);
    }
}
