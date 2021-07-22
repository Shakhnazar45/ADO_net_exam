using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class Person
    {
        public int ArtistId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public DateTime Birthday { get; set; }
        public string Sex { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
    }
}
