using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class WriterForRegisterDto
    {
        public string WriterFirstName { get; set; }
        public string WriterLastName { get; set; }
        public string WriterImage { get; set; }
        public string WriterAbout { get; set; }
        public string WriterTitle { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
