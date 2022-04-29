using BusinessLayer.Abstract;
using BusinessLayer.Security;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;

        public AuthManager(IAdminService adminService,IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }
        public bool AdminLogin(AdminForLoginDto adminForLoginDto)
        {
            var userToCheck = _adminService.GetByMail(adminForLoginDto.Email);
            if (userToCheck == null)
            {
                return false;
            }

            if (!HashingHelper.VerifyPasswordHash(adminForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return false;
            }

            return true;
        }

        public void AdminRegister(AdminForRegisterDto adminForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Admin
            {
                Email = adminForRegisterDto.Email,
                AdminFirstName = adminForRegisterDto.AdminFirstName,
                AdminLastName = adminForRegisterDto.AdminLastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                AdminRole = adminForRegisterDto.AdminRole,
            };
            _adminService.AdminAdd(user);
        }

        public bool AdminExists(string email)
        {
            if (_adminService.GetByMail(email) != null)
            {
                return false;
            }
            return true;
        }

        public bool WriterExists(string email)
        {
            if (_writerService.GetByEmail(email) != null)
            {
                return false;
            }
            return true;
        }

        public bool WriterLogin(WriterForLoginDto writerForLoginDto)
        {
            var userToCheck = _writerService.GetByEmail(writerForLoginDto.Email);
            if (userToCheck == null)
            {
                return false;
            }
            if (!HashingHelper.VerifyPasswordHash(writerForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return false;
            }

            return true;
        }

        public void WriterRegister(WriterForRegisterDto writerForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Writer
            {
                WriterEmail = writerForRegisterDto.Email,
                WriterName = writerForRegisterDto.WriterFirstName,
                WriterSurname = writerForRegisterDto.WriterLastName,
                WriterImage = writerForRegisterDto.WriterImage,
                WriterAbout = writerForRegisterDto.WriterAbout,
                WriterTitle = writerForRegisterDto.WriterTitle,
                WriterStatus = true,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            _writerService.WriterAdd(user);
        }
    }
}
