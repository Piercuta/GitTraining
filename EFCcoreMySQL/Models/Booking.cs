using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class Booking
    {
        public ushort Id { get; set; }
        public DateTime BookedAt { get; set; }
        public ushort IdContact { get; set; }
        public ushort IdAlbum { get; set; }

        public virtual Album IdAlbumNavigation { get; set; }
        public virtual Contact IdContactNavigation { get; set; }
    }
}
