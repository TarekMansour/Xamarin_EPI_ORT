using SQLite.Net.Attributes;

namespace ORT.ViewModel.Chapitre
{
    [Table("Chapitre")]
    public class Chapitre
    {
        [PrimaryKey, AutoIncrement]
        public int IdChapitre { get; set; }

        [MaxLength(50), Unique]
        public string LibelleCh { get; set; }
        public int NbQCh { get; set; }
        public int NbQChNew { get; set; }

        public int IdCours { get; set; } //ForeingKey
    }
}
