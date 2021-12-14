using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class Album
    {
        public Album()
        {
            AlbumArtist = new HashSet<AlbumArtist>();
        }

        public ushort Id { get; set; }
        public string Title { get; set; }
        public short CreatedYear { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ICollection<AlbumArtist> AlbumArtist { get; set; }
    }
}
