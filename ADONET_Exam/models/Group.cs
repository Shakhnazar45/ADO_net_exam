using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable

namespace ADONET_Exam
{
    public partial class Group
    {
        public int ArtistId { get; set; }
        public string GroupName { get; set; }

        public virtual Artist IdArtistNavigation { get; set; }
    }
}
