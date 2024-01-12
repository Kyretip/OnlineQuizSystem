using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Business.Repository.User
{
    public class UserTypeManager : IUserTypeService
    {
        IUserTypeDal _userTypeDal;

        public UserTypeManager(IUserTypeDal userTypedal) {
            _userTypeDal = userTypedal;    
        }

        public IResult Add(UserType userType)
        {
            _userTypeDal.Add(userType);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Delete(int UserTypeId)
        {
          var deletedType =  _userTypeDal.Get(p => p.ID == UserTypeId);
            if (deletedType != null)
            {
                _userTypeDal.Delete(deletedType);
                return new SuccessResult("Silme işlemi başarılı");
            }
            else
            {
                return new ErrorResult("Tip bulunamadı");
            }
        }

        public IDataResult<UserType> Get(int id)
        {
            var data = _userTypeDal.Get(p => p.ID == id);

            return (data != null) ? new SuccessDataResult<UserType>(data) : new ErrorDataResult<UserType>("Kullanıcı Tipi Bulunamadı");
            
        }

        public IDataResult<List<UserType>> GetAll()
        {
            var data = _userTypeDal.GetAll();
            return (data != null && data.Any()) ? new SuccessDataResult<List<UserType>>(data) : new ErrorDataResult<List<UserType>>("Hiç kullanıcı tipi tanımlanmamış");
        }

        public IResult Update(UserType userType)
        {
            var updatedType = _userTypeDal.Get(p => p.ID == userType.ID);
            if(updatedType != null)
            {
                _userTypeDal.Update(updatedType);
                return new SuccessResult("Güncelleme Başarılı");

            }
            else
            {
                return new ErrorResult("Kullanıcı tipi bulunamadı");
            }
        }
    }
}
