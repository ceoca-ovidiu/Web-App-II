using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Gourmet.Database
{
    public class UsersRepository
    {
        public List<User> GetUsersList()
        {
            using (var db = new AppDatabaseContext())
            {
                List<User> users = db.UsersDbSet.ToList();
                if (users == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The users list is null. NULL will be returned");
                    return null;
                }
                else if (users.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The users list is empty. An empty list will be returned");
                    return users;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The users list returned");
                    return users;
                }
            }
        }

        public User GetUserByUsername(string username)
        {
            using (var db = new AppDatabaseContext())
            {
                User user = db.UsersDbSet.FirstOrDefault(users => users.Username == username);
                if (user == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The user is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The user with username : " + user.Username + " is returned");
                    return user;
                }
            }

        }

        public User GetUserByEmail(string email)
        {
            using (var db = new AppDatabaseContext())
            {
                User user = db.UsersDbSet.FirstOrDefault(users => users.UserEmail == email);
                if (user == null)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The user is null. NULL will be returned");
                    return null;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The user with username : " + user.Username + " is returned");
                    return user;
                }
            }
        }

        public Boolean CreateUser(User userToCreate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (userToCreate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The user received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to add the user");
                        db.UsersDbSet.Add(userToCreate);
                        db.SaveChanges();
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The user was added to dataset. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The user could not be added");
                    return false;
                }
            }
        }

        public Boolean UpdateUser(User userToUpdate)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    if (userToUpdate == null)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The user received is null");
                        return false;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to update the user");
                        db.UsersDbSet.Update(userToUpdate);
                        db.SaveChanges();
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The user was updated. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The user could not be updated");
                    return false;
                }
            }
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

        public Boolean IsEmailValid(String emailToCheck)
        {
            using (var db = new AppDatabaseContext())
            {
                List<User> usersList = GetUsersList();

                foreach (User user in usersList)
                {
                    if (user.UserEmail == emailToCheck)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => There is already a user with the email : " + emailToCheck + " in database");
                        return false;
                    }
                }

                if (IsEmailCorrectWritten(emailToCheck))
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => The email is valid");
                    return true;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The email : " + emailToCheck + " is not correct written");
                    return false;
                }
            }
        }

        public Boolean DeleteUserByUsername(String username)
        {
            using (var db = new AppDatabaseContext())
            {
                try
                {
                    System.Diagnostics.Debug.WriteLine("ACCEPTED => Trying to remove a user...");
                    User userToDelete = GetUserByUsername(username);
                    if (userToDelete != null)
                    {
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Found the user with username : " + username);
                        db.Remove(userToDelete);
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => The user was removed. Saving changes...");
                        System.Diagnostics.Debug.WriteLine("ACCEPTED => Done");
                        return db.SaveChanges() >= 1;
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => The user is null and could not be removed");
                        return false;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine("DECLINED => The user with username " + username + " could not be found or could not be removed");
                    return false;
                }
            }
        }

        public Boolean IsUsernameValid(String usernameToCheck)
        {
            using (var db = new AppDatabaseContext())
            {
                List<User> usersList = GetUsersList();

                foreach (User user in usersList)
                {
                    if (user.Username == usernameToCheck)
                    {
                        System.Diagnostics.Debug.WriteLine("DECLINED => There is already a user with the username : " + usernameToCheck + " in database");
                        return false;
                    }
                }
                System.Diagnostics.Debug.WriteLine("ACCEPTED => The username is valid");
                return true;
            }
        }
    }
}
