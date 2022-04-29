using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [StringLength(50)]
        public string AdminFirstName{ get; set; }

        [StringLength(50)]
        public string AdminLastName { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }

        public bool AdminStatus { get; set; }
    }
}
