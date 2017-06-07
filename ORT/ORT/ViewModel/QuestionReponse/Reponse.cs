using SQLite.Net.Attributes;

namespace ORT.ViewModel.QuestionReponse
{
    [Table("Reponse")]
    public class Reponse
    {
        [PrimaryKey, AutoIncrement]
        public int IdRep { get; set; }

        [MaxLength(254), Unique]
        public string TextR { get; set; }
        public string Correction { get; set; }
        public int IdQues { get; set; }//ForeingKey
    }
}
