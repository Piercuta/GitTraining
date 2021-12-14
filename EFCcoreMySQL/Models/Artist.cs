using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class Artist
    {
        public Artist()
        {
            AlbumArtist = new HashSet<AlbumArtist>();
        }

        public ushort Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public virtual ICollection<AlbumArtist> AlbumArtist { get; set; }
    }
}
