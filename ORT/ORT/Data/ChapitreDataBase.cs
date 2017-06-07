using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System;
using ORT.ViewModel.Chapitre;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ORT.Data
{
    /// <summary>
    /// ChapitreDataBase :class for DataLayer
    /// </summary>
    /// <remarks>
    /// Manage operations for application functionality
    /// </remarks>
    /// 
    public class ChapitreDataBase
    {
        private SQLiteAsyncConnection dbConn;//database connection
        public string StatusMessage { get; set; }

        public ChapitreDataBase(ISQLitePlatform sqlitePlatform, string dbPath)
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
                dbConn.CreateTableAsync<Chapitre>();
            }
        }

        #region DataOperations
        public async Task<List<Chapitre>> GetAllChapterAsync()
        {
            //return a list of Chapitres saved to the Chapitre table in the database
            List<Chapitre> chapitres = await dbConn.Table<Chapitre>().ToListAsync();
            return chapitres;
        }

        public Task<List<Chapitre>> GetChapitreForCours1(int idCr) //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Chapitre>("SELECT * FROM [Chapitre] WHERE IdCours=" + idCr.ToString());
        }
        #endregion
    }
}
