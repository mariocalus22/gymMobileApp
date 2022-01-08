using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Calus_Mario_GymMobileApp.Models;

namespace Calus_Mario_GymMobileApp.Data
{
    public class GymDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public GymDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<GymList>().Wait();
            _database.CreateTableAsync<Item>().Wait();
            _database.CreateTableAsync<ListItem>().Wait();
        }

        public Task<int> SaveItemAsync(Item item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }
        public Task<int> DeleteItemAsync(Item item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<List<Item>> GetItemsAsync()
        {
            return _database.Table<Item>().ToListAsync();
        }
        public Task<List<GymList>> GetGymListsAsync()
        {
            return _database.Table<GymList>().ToListAsync();
        }
        public Task<GymList> GetGymListAsync(int id)
        {
            return _database.Table<GymList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveGymListAsync(GymList elist)
        {
            if (elist.ID != 0)
            {
                return _database.UpdateAsync(elist);
            }
            else
            {
                return _database.InsertAsync(elist);
            }
        }
        public Task<int> DeleteGymListAsync(GymList elist)
        {
            return _database.DeleteAsync(elist);
        }

        public Task<int> SaveListItemAsync(ListItem listi)
        {
            if (listi.ID != 0)
            {
                return _database.UpdateAsync(listi);
            }
            else
            {
                return _database.InsertAsync(listi);
            }
        }
        public Task<List<Item>> GetListItemsAsync(int gymlistid)
        {
            return _database.QueryAsync<Item>(
            "select I.ID, I.Description from Item I"
            + " inner join ListItem LI"
            + " on I.ID = LI.ItemID where LI.GymListID = ?",
            gymlistid);
        }


    }
}
