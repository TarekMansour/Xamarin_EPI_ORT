using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System;
using ORT.ViewModel.Cours;
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
    public class CoursDataBase
    {
        private SQLiteAsyncConnection dbConn;
        public string StatusMessage { get; set; }

        public CoursDataBase(ISQLitePlatform sqlitePlatform, string dbPath)
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
                dbConn.CreateTableAsync<Cours>();
            }
        }

        #region DataOperations
        public async Task<List<Cours>> GetAllCoursAsync()
        {
            //return a list of 'Cours' saved to the 'Cours' table in the database
            List<Cours> myCours = await dbConn.Table<Cours>().ToListAsync();
            return myCours;
        }

        public Task<List<Cours>> GetCoursByEntity(int idEntity) //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Cours>("SELECT * FROM [Cours] WHERE IdEntite=" + idEntity.ToString());
        }
        #endregion
    }
}
