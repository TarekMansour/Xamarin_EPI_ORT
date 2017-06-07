using SQLite.Net;
using SQLite.Net.Interop;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ORT.ViewModel.Question;
using ORT.ViewModel.QuestionReponse;
using ORT.ViewModel.Chapitre;

namespace ORT.Data
{
    /// <summary>
    /// QuestionDataBase :class for DataLayer
    /// </summary>
    /// <remarks>
    /// Manage operations for application functionality
    /// </remarks>
    /// 
    public class QuestionDataBase
    {
        //public int idchp { get; set; }
        private SQLiteAsyncConnection dbConn;//database connection
        public QuestionDataBase(ISQLitePlatform sqlitePlatform, string dbPath, int idchp)
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
                dbConn.CreateTableAsync<Question>();
            }

            //this.idchp = idchp;
        }

       
        public Task<List<Question>> GetQuestionByChapter(int idchp)
        {

            return dbConn.QueryAsync<Question>("SELECT * FROM [Question] WHERE IdChapitre="+ idchp.ToString());

            //return dbConn.QueryAsync<Tuple<Question, Chapitre>>("SELECT * FROM [Question] as qs, [Chapitre] as chp"
            //                                            + " WHERE qs.IdChapitre=chp.IdChapitre"
            //                                            + " AND Question.IdChapitre=" + idchp.ToString()
            //                                            + " AND chp.IdCours="+ idCr.ToString());
        }

        public Task<List<Reponse>> GetReponseforQues() //GetI tems Not DoneAsync
        {
            return dbConn.QueryAsync<Reponse>("SELECT * FROM [Reponse] WHERE IdQues=1");
        }
    }
}
