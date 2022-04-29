using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        void AdminRegister(AdminForRegisterDto adminForRegisterDto, string password);
        bool AdminLogin(AdminForLoginDto adminForLoginDto);
        bool AdminExists(string email);
        void WriterRegister(WriterForRegisterDto writerForRegisterDto, string password);
        bool WriterLogin(WriterForLoginDto writerForLoginDto);
        bool WriterExists(string email);
    }
}
