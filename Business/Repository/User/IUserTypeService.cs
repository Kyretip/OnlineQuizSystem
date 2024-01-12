using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.User
{
    public interface IUserTypeService
    {
        IResult Add(UserType userType);
        IResult Delete(int UserTypeId);
        IResult Update(UserType userType);
        IDataResult<UserType> Get(int id);
        IDataResult<List<UserType>> GetAll();
    }
}
