using SQLite;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORT.ViewModel.Home
{
    [Table("Entite")]
    public class Entite
    {
        [PrimaryKey, AutoIncrement]
        public int IdEntite { get; set; }

        [MaxLength(50), Unique]
        public string LibelleEnt {get; set; }

        public int NbQAll { get; set; }

        public int NbQNew { get; set; }

        public string IMAGE { get; set; }
    }
}
