using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class AlbumsSong
    {
        public int AlbumId { get; set; }
        public int SongId { get; set; }
        public int TrackNumber { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Song IdSongNavigation { get; set; }
    }
}
