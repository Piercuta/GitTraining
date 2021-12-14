using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class AlbumArtist
    {
        public ushort Id { get; set; }
        public ushort IdAlbum { get; set; }
        public ushort IdArtist { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Artist IdArtistNavigation { get; set; }
    }
}
