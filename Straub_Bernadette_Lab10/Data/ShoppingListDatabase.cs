using System.Collections.Generic;
using System.Threading.Tasks;
using Straub_Bernadette_Lab10.Models;
using SQLite;

namespace Straub_Bernadette_Lab10.Data
{
    public class ShoppingListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        
        public ShoppingListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ShopList>().Wait();
        }
        
        public Task<List<ShopList>> GetShopListsAsync()
        {
            return _database.Table<ShopList>().ToListAsync();
        }
        
        public Task<ShopList> GetShopListAsync(int id)
        {
            return _database.Table<ShopList>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ShopList slist)
        {
            return slist.Id != 0 ? _database.UpdateAsync(slist) : _database.InsertAsync(slist);
        }
        public Task<int> DeleteShopListAsync(ShopList slist)
        {
            return _database.DeleteAsync(slist);
        }
    }
}