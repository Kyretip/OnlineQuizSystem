using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Lesson
{
    public class LessonUserManager : ILessonUserService
    {
        ILessonUserDal _lessonUserDal;

        public LessonUserManager(ILessonUserDal lessonUserDal)
        {
            _lessonUserDal = lessonUserDal;
        }

        public IResult Add(LessonUser lessonUser)
        {
            _lessonUserDal.Add(lessonUser);
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult AddAll(List<LessonUser> userList)
        {
            userList.ForEach(p => _lessonUserDal.Add(p));
            return new SuccessResult("Öğrenciler eklendi. işlem Başarılı");
        }

        public IResult Delete(int id)
        {
            var deletedUser = _lessonUserDal.Get(p => p.Id == id);
            if (deletedUser != null)
            {
                _lessonUserDal.Delete(deletedUser);
                return new SuccessResult("Silme işlemi başarılı");
            }
            else { return new ErrorResult("Silinecek öğe bulunamadı"); }
        }

        public IDataResult<LessonUser> Get(int id)
        {
            var data = _lessonUserDal.Get(p => p.Id == id);
            return (data != null) 
                ? new SuccessDataResult<LessonUser>(data) 
                : new ErrorDataResult<LessonUser>("Öğe Bulunamadı");
        }

        public IDataResult<List<LessonUser>> GetAll()
        {
            var data = _lessonUserDal.GetAll();
            return (data != null && data.Any())
                ? new SuccessDataResult<List<LessonUser>>(data)
                : new ErrorDataResult<List<LessonUser>>("İçerik yok");
        }

        public IDataResult<List<LessonUser>> GetAllByLesson(int lessonId)
        {
            var data = _lessonUserDal.GetAll(p => p.LessonId == lessonId);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<LessonUser>>(data)
                : new ErrorDataResult<List<LessonUser>>("İçerik yok");

        }

        public IDataResult<List<LessonUser>> GetAllByLessonActive(int lessonId)
        {
            var data = _lessonUserDal.GetAll(p => p.LessonId == lessonId && p.isActive == true);
            return (data != null && data.Any())
               ? new SuccessDataResult<List<LessonUser>>(data)
               : new ErrorDataResult<List<LessonUser>>("İçerik yok");

        }

        public IDataResult<List<LessonUser>> GetAllByLessonNotActive(int lessonId)
        {
            var data = _lessonUserDal.GetAll(p => p.LessonId == lessonId && p.isActive == false);
            return (data != null && data.Any())
               ? new SuccessDataResult<List<LessonUser>>(data)
               : new ErrorDataResult<List<LessonUser>>("İçerik yok");
        }

        public IDataResult<List<LessonUser>> GetAllByStudendId(int studendId)
        {
            var data = _lessonUserDal.GetAll(p => p.UserId == studendId);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<LessonUser>>(data)
                : new ErrorDataResult<List<LessonUser>>("Öğrenciye ait ders bulunamadı");
                }

        public IResult Update(LessonUser lessonUser)
        {
            var updatedUser = _lessonUserDal.Get(p => p.Id == lessonUser.Id);
            if (updatedUser != null)
            {
                _lessonUserDal.Update(lessonUser);
                return new SuccessResult("Güncelleme işlemi başarılı");
            }
            else
            {
                return new ErrorResult("Güncellenecek Öğe bulunamadı");
            }

        }
    }
}
