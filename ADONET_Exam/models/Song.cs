using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class Song
    {
        public Song()
        {
            Albums_Songs = new HashSet<AlbumsSong>();
        }
        public int SongId { get; set; }
        public string SongTitle { get; set; }
        public int SongDuration { get; set; }
        public virtual ICollection<AlbumsSong> Albums_Songs { get; set; }
    }
}
