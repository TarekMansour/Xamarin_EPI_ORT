using System;
using SQLite.Net.Attributes;
using System.Collections.Generic;
using ORT.ViewModel.QuestionReponse;
using System.Collections.ObjectModel;

namespace ORT.ViewModel.Question
{
    [Table("Question")]
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int IdQues { get; set; }

        [MaxLength(254), Unique]
        public string TextQ { get; set; }
        public string TypeQ { get; set; }
        public string DateQ { get; set; }
        public string ObservationQ { get; set; }
        public int IdChapitre { get; set; }//ForeingKey

        //list des reponses
        public List<Reponse> listRep {get; set; }

        //ctor
        public Question()
        {
            listRep = new List<Reponse>();
        }
    }
}
