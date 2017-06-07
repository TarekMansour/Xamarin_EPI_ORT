using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System;
using ORT.ViewModel.Home;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORT.Data
{
    /// <summary>
    /// CoursDataBase :class for DataLayer
    /// </summary>
    /// <remarks>
    /// Manage operations for application functionality
    /// </remarks>
    /// 
    public class EntityDataBase
    {
        private SQLiteAsyncConnection dbConn;
        public string StatusMessage { get; set; }

        public EntityDataBase(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock
                    (
                        sqlitePlatform,
                        new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
                    ));

                dbConn = new SQLiteAsyncConnection(connectionFunc);
                dbConn.CreateTableAsync<Entite>();
            }
        }

        #region DataOperations
        public async Task<List<Entite>> GetAllEntitiesAsync()
        {
            //return a list of Entites saved to the Entite table in the database
            List<Entite> entities = await dbConn.Table<Entite>().ToListAsync();
            return entities;
        }

        public Task<List<Entite>> GetItemsNotDoneAsync()
        {
            return dbConn.QueryAsync<Entite>("SELECT * FROM [Entite]");
        }

        public Task<Entite> GetItemAsync(int id)
        {
            return dbConn.Table<Entite>().Where(i => i.IdEntite == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Entite item)
        {
            if (item.IdEntite != 0)
            {
                return dbConn.UpdateAsync(item);
            }
            else
            {
                return dbConn.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Entite item)
        {
            return dbConn.DeleteAsync(item);
        }
        #endregion
    }
}
