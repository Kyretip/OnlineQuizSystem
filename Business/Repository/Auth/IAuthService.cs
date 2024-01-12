using Business.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Security.JWT;
using Entities.DTOs;

namespace Business.Repository.Auth
{
    public interface IAuthService
    {
        IDataResult<Entities.Concrete.User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Entities.Concrete.User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(Entities.Concrete.User user);
    }
}
