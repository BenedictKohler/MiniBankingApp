// Global class that provides authentication and details about the current user that is logged in 

using MyManagerShared.Models;
using System;

namespace MyManagerUI
{
    public class AuthUser
    {
        private static User CurrentUser { get; set; }

        public static User GetCurrentUser() { return CurrentUser; }
        public static bool IsAuthenticated() { return CurrentUser != null; }
        public static int GetUserID() { return CurrentUser.userID; }
        public static void UpdateBalance(double amount) { CurrentUser.BankBalance += amount; }
        public static double GetBankBalance() { return CurrentUser.BankBalance; }
        public static void SetUser(User newUser) { CurrentUser = newUser; }
        public static string GetFirstName() { return CurrentUser.FirstName; }
        public static string GetLastName() { return CurrentUser.LastName; }
        public static int GetBankNumber() { return CurrentUser.BankNumber; }
        public static string GetEmail() { return CurrentUser.Email; }
        public static string GetPassword() { return CurrentUser.Password; }
        public static DateTime? GetDateJoined() { return CurrentUser.DateJoined; }
    }
}
