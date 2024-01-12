using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<UserType> userTypes); 
        //2.04.00
    }
}
