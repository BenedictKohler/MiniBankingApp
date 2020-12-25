// Class that communicates with the user authentication web service and provides a way of updating and creating users, etc

using MyManagerShared.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MyManagerUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly HttpClient httpClient;

        public AuthenticationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // Delete user by id
        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            return await httpClient.DeleteAsync("api/Users/" + id.ToString());
        }

        // Get user by id
        public async Task<User> GetUser(int id)
        {
            return await httpClient.GetFromJsonAsync<User>("api/Users/" + id.ToString());
        }

        // Get user by their bank number
        public async Task<User> GetUserByBankNumber(int bankNumber)
        {
            return await httpClient.GetFromJsonAsync<User>("api/Users/transaction/" + bankNumber.ToString());
        }

        // Get user by their email
        public async Task<User> GetUserByEmail(string email)
        {
            return await httpClient.GetFromJsonAsync<User>("api/Users/login/" + email);
        }

        // Returns all users as a list
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetFromJsonAsync<User[]>("api/Users/");
        }

        // Create a new user
        public async Task<HttpResponseMessage> PostUser(User user)
        {
            return await httpClient.PostAsJsonAsync("api/Users/", user);
        }

        // Update an existing user
        public async Task<HttpResponseMessage> PutUser(User user, int id)
        {
            return await httpClient.PutAsJsonAsync("api/Users/" + id.ToString(), user);
        }
    }
}
