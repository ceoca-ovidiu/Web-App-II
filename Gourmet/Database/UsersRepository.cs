using Microsoft.EntityFrameworkCore;

namespace Gourmet.Database
{
    internal sealed class UsersRepository
    {
        internal async static Task<List<Users>> GetUsersAsync(AppDatabaseContext db)
        {
            return await db.UsersDbSet.ToListAsync();
        }

        internal async static Task<Users> GetUsersByUsernameAsync(String username, AppDatabaseContext db)
        {
            return await db.UsersDbSet.FirstOrDefaultAsync(users => users.Username == username);
        }

        internal async static Task<bool> CreateUserAsync(Users userToCreate, AppDatabaseContext db)
        {
            try
            {
                await db.UsersDbSet.AddAsync(userToCreate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> UpdateUserAsync(Users userToUpdate, AppDatabaseContext db)
        {
            try
            {
                db.UsersDbSet.Update(userToUpdate);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        internal async static Task<bool> DeleteUserAsync(String username, AppDatabaseContext db)
        {
            try
            {
                Users userToDelete = await GetUsersByUsernameAsync(username, db);

                db.Remove(userToDelete);

                return await db.SaveChangesAsync() >= 1;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
