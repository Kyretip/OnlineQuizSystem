using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.User
{
    public interface IUserService
    {
        IResult Add(Entities.Concrete.User user);
        IResult Delete(Entities.Concrete.User user);
        IResult Update (Entities.Concrete.User user);

        IDataResult<Entities.Concrete.User> Get(int id);

        IDataResult<List<Entities.Concrete.User>> GetAll();

        public List<UserType> GetClaims(Entities.Concrete.User user);

        public Entities.Concrete.User GetByMail(string email);



    }
}
