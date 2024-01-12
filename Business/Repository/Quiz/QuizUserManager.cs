using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Quiz
{
    public class QuizUserManager : IQuizUserService
    {
        IQuizUserDal _quizUserDal;
        ILessonUserDal _lessonUserDal;
        IQuizDal _quizDal;

        public QuizUserManager(IQuizUserDal quizUser, ILessonUserDal lessonUserDal, IQuizDal quizDal) {
        _quizUserDal = quizUser;
        _lessonUserDal = lessonUserDal;
            _quizDal = quizDal;
       
        }

        public IResult Add(QuizUser quizUser)
        {
           _quizUserDal.Add(quizUser);
            return new SuccessResult("EklemeBaşarılı");
        }

        public IResult AddList(List<QuizUser> userList)
        {
            userList.ForEach(p => _quizUserDal.Add(p));
            return new SuccessResult("Ekleme başarılı");
        }

        public IResult AddScore(QuizUser user, float score, bool success)
        {
            var data = _quizUserDal.Get(p => p.Id == user.Id && p.QuizId == user.QuizId);
            if(data != null)
            {
                data.Score = score;
                data.IsActive = success;
                _quizUserDal.Update(data);
                if (success)
                {
                    var quiz = _quizDal.Get(p => p.Id == data.QuizId);
                    var lessonUser = _lessonUserDal.Get(p => p.LessonId ==quiz.LessonId && p.UserId == data.UserId);
                    lessonUser.isActive = false;
                    _lessonUserDal.Update(lessonUser);
                   
                }
                return new SuccessResult("Öğrencinin Sınav notu ve başarı durumu güncellendi");


            }
            else
            {
                return new ErrorResult("Böyle bir kişi bulunamadı");
            }
        }

        public IResult Delete(int id)
        {
            var deletedUSer = _quizUserDal.Get(p => p.Id == id);
            if (deletedUSer != null) { 
            _quizUserDal.Delete(deletedUSer);
               return new SuccessResult("Silme işlemi başarılı");

            }
            else { return new ErrorResult("Silenecek öğe bulunamadı"); }

        }

        public IDataResult<QuizUser> Get(int id)
        {
            var data = _quizUserDal.Get(p => p.Id == id);
            return (data != null)
                ? new SuccessDataResult<QuizUser>(data)
                : new ErrorDataResult<QuizUser>("Böyle bir öğe yok!!");
           
        }

        public IDataResult<List<QuizUser>> GetAllByQuiz(int quizID)
        {
            var data = _quizUserDal.GetAll(p => p.QuizId == quizID);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<QuizUser>>(data)
                : new ErrorDataResult<List<QuizUser>>("Öğe yok!");
        }

        public IDataResult<List<QuizUser>> GetAllByUser(int UserId)
        {
            var data = _quizUserDal.GetAll(p => p.UserId == UserId);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<QuizUser>>(data)
                : new ErrorDataResult<List<QuizUser>>("Öğe yok!");
        }

        public IDataResult<List<QuizUser>> GetAllByUserActive(int UserId)
        {
            // öğrencinin girmediği tarihi yaklaşmakta olan, henüz girmediği sınav listesi
            var data = _quizUserDal.GetAll(p => p.UserId == UserId && p.IsActive == true && p.Entered == false);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<QuizUser>>(data)
                : new ErrorDataResult<List<QuizUser>>("Öğe yok!");
        }

        public IDataResult<List<QuizUser>> GetAllByUserNotActive(int UserId)
        {
            var data = _quizUserDal.GetAll(p => p.UserId == UserId && p.IsActive == false);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<QuizUser>>(data)
                : new ErrorDataResult<List<QuizUser>>("Öğe yok!");
        }

        public IDataResult<List<QuizUser>> GettAllQuizHistory(int userID)
        {
            var data = _quizUserDal.GetAll(p => p.UserId == userID && p.Entered == true);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<QuizUser>>(data)
                : new ErrorDataResult<List<QuizUser>>("sınav geçmişi bulunamadı");
        }

        public IResult Update(QuizUser quizUser)
        {
            var updateduser = _quizUserDal.Get(p => p.Id == quizUser.Id);
            if (updateduser != null)
            {
                _quizUserDal.Update(quizUser);
                return new SuccessResult("Güncelleme başarılı");
            }
            else
            {
                return new ErrorResult("Güncellenecek öğe bulunamaduı");
            }
        }
    }
}
