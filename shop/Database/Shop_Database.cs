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
            database.CreateTableAsync<Category>().Wait();
            database.CreateTableAsync<Item>().Wait();
            database.CreateTableAsync<CartItem>().Wait();
            database.CreateTableAsync<Order>().Wait();
            database.CreateTableAsync<Cart>().Wait();


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
        public Task<int> SaveItemAsync(Cart item)
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
        public Task<int> SaveItemAsync(Category item)
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
        public Task<int> SaveItemAsync(Item item)
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

        public Task<int> SaveItemAsync(CartItem item)
        {
                return database.InsertAsync(item);

        }

        public Task<User> GetUserAsync(string Mail)
        {
            return database.Table<User>().Where(i => i.Mail == Mail).FirstOrDefaultAsync();
        }
        public Task<Category> GetIdbyName(string Name)
        {
            return database.Table<Category>().Where(i => i.Name == Name).FirstOrDefaultAsync();
        }
        public Task<List<Category>> GetCategoriesAsync()
        {
            return database.Table<Category>().ToListAsync();
        }
        public Task<List<Item>> GetItemsByCategoryId(int Id)
        {
            return database.Table<Item>().Where(i => i.Category_Id == Id).ToListAsync();
        }
        public Task<List<Item>> GetItemsByName(string Name)
        {
            return database.Table<Item>().Where(i => i.Name == Name).ToListAsync();
        }
        public Task<Item> GetItemById(int Id)
        {
            return database.Table<Item>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public Task<List<CartItem>> GetItemsToCartById_Cart(int Id)
        {
            return database.Table<CartItem>().Where(i => i.ID_Cart == Id).ToListAsync();
        }

        public Task<Item> GetI(int Id)
        {
            return database.Table<Item>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }
    }
}
