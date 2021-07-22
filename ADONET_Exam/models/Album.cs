using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class Album
    {
        public Album()
        {
            Albums_Songs = new HashSet<AlbumsSong>();
        }
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
        public string AlbumTitle { get; set; }
        public DateTime? AlbumYear { get; set; }
        public string AlbumTracks { get; set; }
        public virtual ICollection<AlbumsSong> Albums_Songs { get; set; }
        public virtual Artist IdArtistNavigation { get; set; }
    }
}
