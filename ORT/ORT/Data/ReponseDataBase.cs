using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System;
using ORT.ViewModel.QuestionReponse;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORT.Data
{
    /// <summary>
    /// ReponseDataBase :class for DataLayer
    /// </summary>
    /// <remarks>
    /// Manage operations for application functionality
    /// </remarks>
    ///
    public class ReponseDataBase
    {
        private SQLiteAsyncConnection dbConn;//database connection
        public string StatusMessage { get; set; }

        public ReponseDataBase(ISQLitePlatform sqlitePlatform, string dbPath)
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
                dbConn.CreateTableAsync<Reponse>();
            }
        }

        #region DataOperations
        public async Task<List<Reponse>> GetAllChapterAsync()
        {
            //return a list of Reponses saved to the Reponse table in the database
            List<Reponse> Reponses = await dbConn.Table<Reponse>().ToListAsync();
            return Reponses;
        }

        public Task<List<Reponse>> GetReponseforQues1() //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse]");
        }
        public Task<List<Reponse>> GetCorrect_ReponseforQues1() //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE Correction='true'");
        }

        public Task<List<Object>> GetCorrect_ReponseByChapter() //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Object>("SELECT * FROM [Reponse] as rep, [Question] as ques"
                                                        + " WHERE rep.IdQues=ques.IdQues"
                                                        + " AND rep.Correction='true'"
                                                        + " AND ques.IdChapitre=1");
        }

        #region SQLITE DATA
        //public Task<List<Reponse>> GetReponseforQues2() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=2");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues2() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=2 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues3() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=3");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues3() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=3 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues4() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=4");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues4() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=4 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues5() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=5");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues5() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=5 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues6() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=6");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues6() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=6 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues7() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=7");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues7() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=7 AND Correction='true'");
        //}

        //public Task<List<Reponse>> GetReponseforQues8() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=8");
        //}
        //public Task<List<Reponse>> GetCorrect_ReponseforQues8() //GetI tems Not DoneAsync
        //{
        //    return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=8 AND Correction='true'");
        //}
        #endregion
        #endregion
    }
}
