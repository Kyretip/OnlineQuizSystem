using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Lesson
{
    public class LessonManager : ILessonService
    {
        ILessonDal _lessondal;

        public LessonManager(ILessonDal leesondal)
        {
            _lessondal = leesondal;
        }

        public IResult Add(Entities.Concrete.Lesson lesson)
        {
            _lessondal.Add(lesson);
            return new SuccessResult("Ekleme işlemi Başarılı");
        }

        public IResult Delete(int lessonID)
        {
            var deletedLesson = _lessondal.Get(p => p.Id == lessonID);
            if (deletedLesson != null)
            {
                _lessondal.Delete(deletedLesson);
                return new SuccessResult("Silme İşlemi Başarılı");
            }
            else
            {
                return new ErrorResult("Silinecek öğe bulunamadı");
            }

        }

        public IDataResult<Entities.Concrete.Lesson> Get(int id)
        {
            var data = _lessondal.Get(p => p.Id == id);
            return (data != null) ? new SuccessDataResult<Entities.Concrete.Lesson>(data) : new ErrorDataResult<Entities.Concrete.Lesson>("Ders Bulunamadı");
        }

        public IDataResult<List<Entities.Concrete.Lesson>> GetAll()
        {
           var data = _lessondal.GetAll();
            return (data != null && data.Any()) ? new SuccessDataResult<List<Entities.Concrete.Lesson>>(data) : new ErrorDataResult<List<Entities.Concrete.Lesson>>("Hiç Ders Bulunmamakta");
        }

        public IDataResult<List<Entities.Concrete.Lesson>> GetAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Entities.Concrete.Lesson>> GetForTeacher(int userId)
        {
            var data= _lessondal.GetAll(p => p.UserId == userId);
            return (data != null && data.Any()) ? new SuccessDataResult<List<Entities.Concrete.Lesson>>(data) : new ErrorDataResult<List<Entities.Concrete.Lesson>>("Hiç Ders Bulunmamakta");

        }

        public IResult Update(Entities.Concrete.Lesson lesson)
        {
            var updatedLesson = _lessondal.Get(p => p.Id == lesson.Id);
            if (updatedLesson != null)
            {
                _lessondal.Update(lesson);
                return new SuccessResult("Güncelleme Başarılı");
            }
            else { return new ErrorResult("Güncellenecek Ders Bulunamadı"); }
        }
    }
}
