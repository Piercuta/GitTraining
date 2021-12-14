using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EFCcoreMySQL.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Booking = new HashSet<Booking>();
        }

        public ushort Id { get; set; }
        public string Mail { get; set; }
        public string FisrtName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
