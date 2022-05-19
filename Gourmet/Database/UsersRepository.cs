using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Gourmet.Database
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

        public string Login(User user)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.Username.Equals(user.Username))
                {
                    if (user.UserPassword.Equals(DecodePassword(userIterator.UserPassword)))
                    {
                        Debug.WriteLine("=======================================> Found user " + userIterator.Username + " " + userIterator.UserEmail);
                        return userIterator.Username + "<--->" + DecodePassword(userIterator.UserPassword); // TOFIX IF NEEDED
                    }
                }
            }
            return "The user could not be found";
        }

        public string ChangeEmail(User user)
        {
            if (IsEmailValid(user.UserEmail))
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
                        userToAdd.UserEmail = user.UserEmail;
                        userToAdd.UserPhoneNumber = userIterator.UserPhoneNumber;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "The user email has been updated successfully";
                    }
                }
                return "Could not update user email";
            }
            else
            {
                return "The email is not valid";
            }
        }

        public string ChangePhone(User user)
        {
            if (IsPhoneNumberValid(user.UserPhoneNumber))
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
                        userToAdd.UserPhoneNumber = user.UserPhoneNumber;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "The user phone number has been updated successfully";
                    }
                }
                return "Could not update user phone number";
            }
            else
            {
                return "The phone number is not valid";
            }
        }

        public string ChangePassword(User user)
        {
            if (user.UserPassword.Equals(user.Username) || String.IsNullOrEmpty(user.UserPassword))
            {
                return "The password is the same as the username or is empty ==> ERROR";
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
                        userToAdd.UserPassword = EncodePassword(user.UserPassword);
                        userToAdd.UserEmail = userIterator.UserEmail;
                        userToAdd.UserPhoneNumber = userIterator.UserPhoneNumber;
                        appDatabaseContext.UsersDbSet.Remove(userIterator);
                        appDatabaseContext.UsersDbSet.Add(userToAdd);
                        appDatabaseContext.SaveChanges();
                        return "The user password has been updated successfully";
                    }
                }
                return "Could not update user password";
            }
        }

        public User GetUser(User user)
        {
            AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
            foreach (User userIterator in appDatabaseContext.UsersDbSet)
            {
                Debug.WriteLine("=======================================> Checking user " + userIterator.Username + " " + userIterator.UserEmail);
                if (userIterator.Username.Equals(user.Username))
                {
                    Debug.WriteLine("=======================================> The user has been found " + userIterator.Username);
                    return userIterator;
                }
            }
            return null;
        }

        public string SignUp(User user)
        {
            if (IsUsernameValid(user.Username))
            {
                if (IsEmailValid(user.UserEmail))
                {
                    if (String.IsNullOrEmpty(user.UserPassword) || String.IsNullOrEmpty(user.UserPhoneNumber))
                    {
                        return "User password or phone number empty";
                    }
                    else
                    {
                        if (user.UserPassword.Equals(user.Username))
                        {
                            return "User password is the same as username";
                        }
                        else
                        {
                            if (user.UserPassword.Length >= 5)
                            {
                                if (IsPhoneNumberValid(user.UserPhoneNumber))
                                {
                                    AppDatabaseContext appDatabaseContext = new AppDatabaseContext();
                                    foreach (User userIterator in appDatabaseContext.UsersDbSet)
                                    {
                                        if (userIterator.Username.Equals(user.Username))
                                        {
                                            return "The user already exists in database";
                                        }
                                    }
                                    user.UserPassword = EncodePassword(user.UserPassword);
                                    appDatabaseContext.UsersDbSet.Add(user);
                                    appDatabaseContext.SaveChanges();
                                    return "User added successfully";
                                }
                                else
                                {
                                    return "The phone number is not valid";
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

        public Boolean IsPasswordValid(string passwordToCheck, string userName)
        {
            if (string.IsNullOrEmpty(passwordToCheck) || string.IsNullOrEmpty(userName))
            {
                System.Diagnostics.Debug.WriteLine("DECLINED => Password or username is not correct");
                return false;
            }
            else if (passwordToCheck.Contains(userName))
            {
                System.Diagnostics.Debug.WriteLine("DECLINED => Password contains username");
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
            else if (username.Contains("@") ||
                    username.Contains("#") ||
                    username.Contains("$") ||
                    username.Contains("%") ||
                    username.Contains("!") ||
                    username.Contains("&") ||
                    username.Contains("*") ||
                    username.Contains("+") ||
                    username.Contains("=") ||
                    username.Contains("?") ||
                    username.Contains("^") ||
                    username.Contains(";") ||
                    username.Contains(":") ||
                    username.Contains("]") ||
                    username.Contains("[") ||
                    username.Contains("~") ||
                    username.Contains(",") ||
                    username.Contains("`") ||
                    username.Contains("<") ||
                    username.Contains(">") ||
                    username.Contains("|"))
            {
                return false;
            }
            else if (IsAllWhitespaces(username))
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
            int aux = 0;
            if (phoneNumber.Length == 10)
            {
                foreach (char c in phoneNumber)
                {
                    if (char.IsDigit(c))
                    {
                        aux++;
                    }
                }
                Debug.WriteLine("=======================================> The number of chars (aux) is " + aux.ToString());
                return aux == phoneNumber.Length;
            }
            else
            {
                Debug.WriteLine("=======================================> Phone does not have 10 chars");
                return false;
            }
        }
    }
}
