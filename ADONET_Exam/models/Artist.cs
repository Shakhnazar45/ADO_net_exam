using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ADONET_Exam
{
    public partial class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
        }

        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public int CountryId { get; set; }
        public string ArtistSiteUrl { get; set; }

        public virtual Country IdCountryNavigation { get; set; }
        public virtual Genre IdGenreNavigation { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
