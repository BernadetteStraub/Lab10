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
            _database.CreateTableAsync<Product>().Wait();
            _database.CreateTableAsync<ListProduct>().Wait();
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

        public Task<int> SaveProductAsync(Product product)
        {
            return product.Id != 0 ? _database.UpdateAsync(product) : _database.InsertAsync(product);
        }

        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }
        
        public Task<int> SaveListProductAsync(ListProduct listp)
        {
            return listp.Id != 0 ? _database.UpdateAsync(listp) : _database.InsertAsync(listp);
        }
        public Task<List<Product>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Product>(
                "select P.ID, P.Description from Product P"
                + " inner join ListProduct LP"
                + " on P.ID = LP.ProductID where LP.ShopListID = ?",
                shoplistid);
        }
    }
}