using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Bianca_Shop.Models;

namespace Bianca_Shop.Data
{

    public class ShopDatabase
    {
        //obicetul cu care se face conexiunea la baza de date
        public readonly SQLiteAsyncConnection _database;

        //creare baza de date utilizand constructorul clasei
        public ShopDatabase(string dbPath)
        {
            // creare conexiunea cu baza de date 
            _database = new SQLiteAsyncConnection(dbPath);

            // creare products table
            _database.CreateTableAsync<Product>().Wait();

            // creare users table
            _database.CreateTableAsync<User>().Wait();

            // creare returns table
            _database.CreateTableAsync<Return>().Wait();
        }

        // CRUD FOR PRODUCTS /////////////////////////////////////////////
        // get (view)

        //
        public Task<List<Product>> GetProductsAsync()
        {
           // _database.ExecuteAsync("PRAGMA foreign_keys = ON;");

           // returnare produse din baza de date in care fiecare rand din tabel este un produs
            return _database.Table<Product>().ToListAsync();
        }

        // get by ID (view)
        public Task<Product> GetProductAsync(int id)
        {
            // returnare produs cu id cautat din tabelul Product
            return _database.Table<Product>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        // update / create
        public Task<int> SaveProductAsync(Product product)
        {   
            if (product.ID != 0)
            {   // cautare produs existent si update
                return _database.UpdateAsync(product);
            }
            else
            {   //daca este produs nou, adica are ID=0, se face inserare
                return _database.InsertAsync(product);
            }
        }

        // delete
        public Task<int> DeleteProductAsync(Product product)
        {
            return _database.DeleteAsync(product);
        }
        //////////////////////////////////////////////////////////////////


        // CRUD FOR USERS /////////////////////////////////////////////
        // get (view)
        public Task<List<User>> GetUsersAsync()
        {   
            // returnare useri din baza de date in care fiecare rand din tabel este un user
            return _database.Table<User>().ToListAsync();
        }

        // get by ID (view)
        public Task<User> GetUserAsync(int id)
        {   
            // returnare user cu id cautat din tabelul User
            return _database.Table<User>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        // update / create
        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {   // cautare user existent si update
                return _database.UpdateAsync(user);
            }
            else
            {   //daca este user nou, adica are ID=0, se face inserare
                return _database.InsertAsync(user);
            }
        }

        // delete
        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
        //////////////////////////////////////////////////////////////////


        // CRUD FOR RETURNS /////////////////////////////////////////////
        // get (view)
        public Task<List<Return>> GetReturnsAsync()
        {   // returnare returns din baza de date in care fiecare rand din tabel este un return
            return _database.Table<Return>().ToListAsync();
        }

        // get by ID (view)
        public Task<Return> GetReturnAsync(int id)
        {   // returnare return cu id cautat din tabelul Return
            return _database.Table<Return>()
            .Where(i => i.ID == id)
            .FirstOrDefaultAsync();
        }

        // update / create
        public Task<int> SaveReturnAsync(Return returnn)
        {
            if (returnn.ID != 0)
            {   // cautare return existent si update
                return _database.UpdateAsync(returnn);
            }
            else
            {   ////daca este return nou, adica are ID=0, se face inserare
                return _database.InsertAsync(returnn);
            }
        }

        // delete
        public Task<int> DeleteReturnAsync(Return returnn)
        {
            return _database.DeleteAsync(returnn);
        }
        //////////////////////////////////////////////////////////////////

    }
}
