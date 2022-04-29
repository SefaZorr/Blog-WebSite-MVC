using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class AdminForRegisterDto:IDto
    {
        public string AdminFirstName { get; set; }
        public string AdminLastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AdminRole { get; set; }
    }
}
