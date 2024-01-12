using Business.Repository.User;
using Business.Results.Abstract;
using Business.Results.Concrete;
using Business.Security.Hashing;
using Business.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Auth
{

    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<Entities.Concrete.User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new Entities.Concrete.User
            {
                Email = userForRegisterDto.Email,
                Name = userForRegisterDto.Name,
                UserTypeID = userForRegisterDto.UserTypeId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

                
                //3:44:31
            };
            _userService.Add(user);
            return new SuccessDataResult<Entities.Concrete.User>(user, "Kullanıcı Başarı ile kayıt edildi.");
        }

        public IDataResult<Entities.Concrete.User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<Entities.Concrete.User>("Login fonksiyonu hatası");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<Entities.Concrete.User>("Hatalı Şifre");
            }

            return new SuccessDataResult<Entities.Concrete.User>(userToCheck, "Giriş başarılı");
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult("Kullanıcı Bulunamadı");
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(Entities.Concrete.User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, "Token Oluşturuldu");  
        }
    }
}
