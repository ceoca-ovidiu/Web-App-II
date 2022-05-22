using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Gourmet.Database.Models;
using Gourmet.Database.Views;
using Microsoft.AspNetCore.Mvc;

namespace Gourmet.Database.Repositories
{
    public class UsersRepository
    {
        public List<User> GetAllUsers()
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            List<User> users = appDatabaseContext.UsersDbSet.ToList();
            if (users == null)
            {
                Debug.WriteLine("DECLINED => The users list is null. NULL will be returned");
                return null;
            }
            else if (users.Count == 0)
            {
                Debug.WriteLine("DECLINED => The users list is empty. An empty list will be returned");
                return users;
            }
            else
            {
                Debug.WriteLine("ACCEPTED => The users list returned");
                return users;
            }
        }

        public async Task<User> Login(UserVM user)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.Username.Equals(user.Username))
                {
                    if (user.Password.Equals(DecodePassword(userIterator.UserPassword)))
                    {
                        Debug.WriteLine("=======================================> Found user " + userIterator.Username + " " + userIterator.UserEmail);
                        return userIterator;
                    }
                    else
                    {
                        return new User(new UserVM("wrong pass", "wrong pass"));
                    }
                }
            }
            return null;
        }

        public async Task<ActionResult<string>> ChangeEmail(UserSignUp user)
        {
            if (IsEmailValid(user.Email))
            {
                AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                foreach (User userIterator in appDatabaseContext.UsersDbSet)
                {
                    Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                    if (userIterator.Username.Equals(user.Username))
                    {
                        Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                        User userToAdd = new User();
                        userToAdd.Username = user.Username;
                        userToAdd.UserPassword = userIterator.UserPassword;
                        userToAdd.UserEmail = user.Email;
                        userToAdd.UserPhoneNumber = userIterator.UserPhoneNumber;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "Succes";
                    }
                }
                return "Failed";
            }
            else
            {
                return "Email not valid";
            }
        }

        public async Task<ActionResult<string>> ChangePhone(UserSignUp user)
        {
            if (IsPhoneNumberValid(user.Phone))
            {
                AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                foreach (User userIterator in appDatabaseContext.UsersDbSet)
                {
                    Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                    if (userIterator.Username.Equals(user.Username))
                    {
                        Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                        User userToAdd = new User();
                        userToAdd.Username = user.Username;
                        userToAdd.UserPassword = userIterator.UserPassword;
                        userToAdd.UserEmail = userIterator.UserEmail;
                        userToAdd.UserPhoneNumber = user.Phone;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "Succes";
                    }
                }
                return "Failed";
            }
            else
            {
                return "Phone number not valid";
            }
        }

        public async Task<ActionResult<string>> ChangePassword(UserSignUp user)
        {
            if (user.Password.Equals(user.Username) || String.IsNullOrEmpty(user.Password))
            {
                return "Failed";
            }
            else
            {
                AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                foreach (User userIterator in appDatabaseContext.UsersDbSet)
                {
                    Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                    if (userIterator.Username.Equals(user.Username))
                    {
                        Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                        User userToAdd = new User();
                        userToAdd.Username = user.Username;
                        userToAdd.UserPassword = EncodePassword(user.Password);
                        userToAdd.UserEmail = userIterator.UserEmail;
                        userToAdd.UserPhoneNumber = userIterator.UserPhoneNumber;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "Succes";
                    }
                }
                return "Failed";
            }
        }

        public async Task<ActionResult<User>> GetUser(string username)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.Username.Equals(username))
                {
                    Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                    return userIterator;
                }
            }
            return null;
        }

        public async Task<ActionResult<String>> SignUp(UserSignUp user)
        {
            if (IsUsernameValid(user.Username))
            {
                if (IsEmailValid(user.Email))
                {
                    if (String.IsNullOrEmpty(user.Password) || String.IsNullOrEmpty(user.Phone))
                    {
                        return "User password or phone number empty";
                    }
                    else
                    {
                        if (user.Password.Equals(user.Username))
                        {
                            return "User password is the same as username";
                        }
                        else
                        {
                            if (user.Password.Length >= 5)
                            {
                                if (IsPasswordValid(user.Password))
                                {
                                    if (IsPhoneNumberValid(user.Phone))
                                    {
                                        AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                                        foreach (User userIterator in appDatabaseContext.UsersDbSet)
                                        {
                                            if (userIterator.Username.Equals(user.Username))
                                            {
                                                return "User exists";
                                            }
                                        }
                                        user.Password = EncodePassword(user.Password);
                                        appDatabaseContext.UsersDbSet.Add(new User(user));
                                        appDatabaseContext.SaveChanges();
                                        return "User added";
                                    }
                                    else
                                    {
                                        return "Phone number not valid";
                                    }
                                }
                                else
                                {
                                    return "Password not valid";

                                }
                            }
                            else
                            {
                                return "The password is too short";
                            }
                        }
                    }
                }
                else
                {
                    return "Email not valid";
                }
            }
            else
            {
                return "Username not valid";
            }
        }

        private string DecodePassword(string normalPassword)
        {
            var base64EncodedBytes = Convert.FromBase64String(normalPassword);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        private string EncodePassword(string encodedPassword)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(encodedPassword);
            return Convert.ToBase64String(plainTextBytes);
        }

        public User GetUserByEmail(User user)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.UserEmail.Equals(user.UserEmail))
                {
                    Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                    return userIterator;
                }
            }
            return null;
        }

        public Boolean DeleteUserByUsername(User user)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.Username.Equals(user.Username))
                {
                    Debug.WriteLine("=======================================> The user " + userIterator.Username + " has been found and will be deleted");
                    appDatabaseContext.UsersDbSet.Remove(userIterator);
                    return true;
                }
            }
            return false;
        }

        public Boolean IsPasswordValid(string passwordToCheck)
        {
            Debug.WriteLine("ACCEPTED => Password is " + passwordToCheck);
            if (string.IsNullOrEmpty(passwordToCheck))
            {
                Debug.WriteLine("DECLINED => Password or username is not correct");
                return false;
            }
            else if (IsAllWhitespaces(passwordToCheck))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Boolean IsEmailCorrectWritten(String email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                System.Diagnostics.Debug.WriteLine("DECLINED => The email string passed is null or empty");
                return false;
            }
            else
            {
                if ((email.Contains(".com") || email.Contains(".ro")) && email.Contains("@"))
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The email string passed is OK");
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The email string passed does not contains specific elements");
                    return false;
                }
            }
        }

        private Boolean IsUsernameValid(string username)
        {
            if (String.IsNullOrEmpty(username) || username.Length > 15)
            {
                return false;
            }
            else if (username.Contains("`") ||
                    username.Contains("~") ||
                    username.Contains("!") ||
                    username.Contains("@") ||
                    username.Contains("#") ||
                    username.Contains("$") ||
                    username.Contains("%") ||
                    username.Contains("^") ||
                    username.Contains("&") ||
                    username.Contains("*") ||
                    username.Contains("(") ||
                    username.Contains(")") ||
                    username.Contains("-") ||
                    username.Contains("_") ||
                    username.Contains("+") ||
                    username.Contains("=") ||
                    username.Contains("[") ||
                    username.Contains("]") ||
                    username.Contains("{") ||
                    username.Contains("}") ||
                    username.Contains("|") ||
                    username.Contains(";") ||
                    username.Contains(":") ||
                    username.Contains("'") ||
                    username.Contains("<") ||
                    username.Contains(">") ||
                    username.Contains(",") ||
                    username.Contains(".") ||
                    username.Contains("?") ||
                    username.Contains("/"))
            {
                return false;
            }
            else if (IsAllWhitespaces(username))
            {
                return false;
            }
            else if (itIsNumber(username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean IsEmailValid(string email)
        {
            Debug.WriteLine("=======================================> EMAIL IS : " + email);
            if (String.IsNullOrEmpty(email))
            {
                Debug.WriteLine("=======================================> EMAIL is empty");
                return false;
            }
            else
            {
                if (email.Contains("@"))
                {
                    if (email.Contains("com") || email.Contains("net") || email.Contains("ro"))
                    {
                        if (email.Contains("gmail") || email.Contains("yahoo") || email.Contains("outlook") || email.Contains("hotmail"))
                        {
                            return true;

                        }
                        else
                        {
                            Debug.WriteLine("=======================================> EMAIL does not contains gmail, yahoo, outlook, hotmail");
                            return false;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("=======================================> EMAIL does not contains .com, .net, .ro");
                        return false;
                    }
                }
                else
                {
                    Debug.WriteLine("=======================================> EMAIL does not contain @");
                    return false;
                }
            }
        }

        private Boolean IsAllWhitespaces(string str)
        {
            int aux = 0;
            foreach (char c in str)
            {
                if (char.IsWhiteSpace(c))
                {
                    aux++;
                }
            }
            return aux == str.Length;
        }

        private Boolean IsPhoneNumberValid(string phoneNumber)
        {
            Debug.WriteLine("=======================================> Phone number is " + phoneNumber);
            if (phoneNumber.Length == 10)
            {
                if (itIsNumber(phoneNumber))
                {
                    if (phoneNumber[0] == '0' && phoneNumber[1] == '7')
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Debug.WriteLine("=======================================> Phone does not have 10 chars");
                return false;
            }
        }

        private Boolean itIsNumber(string passedString)
        {
            int aux = 0;
            foreach (char c in passedString)
            {
                if (char.IsDigit(c))
                {
                    aux++;
                }
            }
            return aux == passedString.Length;
        }
    }
}
