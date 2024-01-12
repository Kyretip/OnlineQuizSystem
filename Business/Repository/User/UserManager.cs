using Business.Aspect.Autofac.Validation;
using Business.Results.Abstract;
using Business.Results.Concrete;
using Business.ValidationRules.FludentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.User
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserTypeDal _userTypeDal;
        public UserManager(IUserDal userDal, IUserTypeDal userTypeDal)
        {
            _userDal = userDal;
            _userTypeDal = userTypeDal;
        }
       // [ValidationAspect(typeof(UserValidator))]
        public IResult Add(Entities.Concrete.User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Delete(Entities.Concrete.User user)
        {
            var removeduser = _userDal.Get(p => p.Id.Equals(user.Id));
            if(removeduser == null)
            {
                return new ErrorResult("Kullanıcı bulunamadı");

            }
            else
            {
                _userDal.Delete(removeduser);
                return new SuccessResult("Kullanıcı başarılı ile silindi");
            }




        }

        public IDataResult<Entities.Concrete.User> Get(int id)
        {
            var result = _userDal.Get(p => p.Id == id);

            return (result != null) ? new SuccessDataResult<Entities.Concrete.User>(result) : new ErrorDataResult<Entities.Concrete.User>("Görev bulunamadı");
        }

        public IDataResult<List<Entities.Concrete.User>> GetAll()
        {
            var data = _userDal.GetAll();
            if (data != null && data.Any())
            {
                return new ErrorDataResult<List<Entities.Concrete.User>>("HATAAAA");

            }
            else
            {
                return new SuccessDataResult<List<Entities.Concrete.User>>(data);
            }
        }

        public Entities.Concrete.User GetByMail(string email)
        {
            var data = _userDal.Get(p => p.Email == email);
            return data;
        }

        public List<UserType> GetClaims(Entities.Concrete.User user)
        {

            var claims = _userTypeDal.GetAll(p => p.ID == user.UserTypeID);
            return claims; 
                /*List<UserType> data = new List<UserType>();
                UserType type = new UserType();
                type.ID = user.UserTypeID;
                type.Name = "Öğrenci";
                data.Add(type);
                return data;*/
            
                

            }

            public IResult Update(Entities.Concrete.User user)
            {
                var updatedUser = _userDal.Get(p => p.Id == user.Id);
                if ( updatedUser == null){
                    return new ErrorResult("Güncellencek kişi bulunamadı");
                }
                else
                {
                    /*updatedUser.Password = user.Password;
                    updatedUser.Email = user.Email;
                    updatedUser.Name = user.Name;
                    updatedUser.UserTypeID = user.UserTypeID;*/

                _userDal.Update(user);
                return new SuccessResult("Günceleem başarılı");
            }
            
        }
    }
}
