using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class Genre
    {
        public Genre()
        {
            Artists = new HashSet<Artist>();
        }

        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
