using System;
using ORT.Views.Dashboard;
using ORT.Data;
using SQLite.Net.Interop;
using Xamarin.Forms;
using ORT.Views.ChapitreByCours.Informatique;

namespace ORT
{
    public partial class App : Application
    {
        //object references on Data Access Layer
        public static ChapitreDataBase ChapitreDb { get; private set; }
        public static EntityDataBase EntiteDb { get; private set; }
        public static CoursDataBase CoursDb { get; private set; }
        public static QuestionDataBase QuestionDb { get; private set; }
        public static ReponseDataBase ReponseDb { get; private set; }

        public App()
        { }

        public App(string dbPath, ISQLitePlatform sqlitePlatform, int id)
        {
            //set database path first, then retrieve main page
            ChapitreDb = new ChapitreDataBase(sqlitePlatform, dbPath);
            EntiteDb = new EntityDataBase(sqlitePlatform, dbPath);
            CoursDb = new CoursDataBase(sqlitePlatform, dbPath);
            QuestionDb = new QuestionDataBase(sqlitePlatform, dbPath, id);
            ReponseDb = new ReponseDataBase(sqlitePlatform, dbPath);

            this.MainPage = new Menu();
            //this.MainPage = new TestPage();
            //this.MainPage = new Hello();

            //this.MainPage = new ListeChapitre_CSharp();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
