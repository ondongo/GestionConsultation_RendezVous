using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consultationProjet.repository
{
    public class BaseRepository
    {
        private String connectionString;
        public string ConnectionString { get => connectionString; set => connectionString = value; }
    }
}
