using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseHelper
{
    readonly SQLiteAsyncConnection _database;

    public DatabaseHelper(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<User>().Wait();
    }

    public Task<List<User>> GetUsersAsync()
    {
        return _database.Table<User>().ToListAsync();
    }

    public Task<int> SaveUserAsync(User user)
    {
        return _database.InsertAsync(user);
    }

    public Task<User> GetUserByUsernameAsync(string username)
    {
        return _database.Table<User>().Where(u => u.Username == username).FirstOrDefaultAsync();
    }
}
