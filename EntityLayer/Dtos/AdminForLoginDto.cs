using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class AdminForLoginDto :IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
