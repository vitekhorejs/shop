using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace shop
{
    public class Shop_Database
    {
        private SQLiteAsyncConnection database;

        public Shop_Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<User>().Wait();
            //database.CreateTableAsync<Reminder>().Wait();
            //database.CreateTableAsync<Notification>().Wait();
        }

        public Task<int> SaveUserAsync(User item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }
    }
}
