using SQLite.Net.Attributes;

namespace ORT.ViewModel.Cours
{
    [Table("Cours")]
    public class Cours
    {
        [PrimaryKey, AutoIncrement]
        public int IdCours { get; set; }

        [MaxLength(50), Unique]
        public string LibelleCr { get; set; }
        public int NbQCr { get; set; }
        public int NbQCrNew { get; set; }

        [MaxLength(200), Unique]
        public string ImageCr { get; set; }
        public int IdEntite { get; set; }//ForeingKey

    }
}
