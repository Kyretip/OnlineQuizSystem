using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public class UserAnswerManager : IUserAnswerService
    {
        IUserAnswerDal _userAnwserdal;
        IQuestionDal _questionDal;
        IQuizDal _quizDal;

        public UserAnswerManager(IUserAnswerDal userAnswerdal, IQuestionDal questionDal, IQuizDal quizDal)
        {
            _userAnwserdal = userAnswerdal;
            _questionDal = questionDal;
            _quizDal = quizDal;
        }

        public IResult Add(UserAnswer userAnswer)
        {
            var question = _questionDal.Get(p => p.Id == userAnswer.QustionId);
           if (question != null)
            {
                int questionId = question.Id;
                var time = _quizDal.Get(p => p.Id == questionId).DueDate;
                if (DateTime.Now <= time)
                {
                    _userAnwserdal.Add(userAnswer);
                    return new SuccessResult("Cevap Eklendi");
                }
                else
                {
                    return new ErrorResult("Sınav Süresi Doldu");
                }
            }
            else
            {
                return new ErrorResult("Cevaplanacak bir soru bulunamadı");
            }

        }

        public IResult Delete(int id)
        {
            var deletedAnswer = _userAnwserdal.Get(p => p.Id == id);
            if(deletedAnswer != null)
            {
                _userAnwserdal.Delete(deletedAnswer);
                return new SuccessResult("Cevap Silindi");
            }
            else
            {
                return new ErrorResult("Cevap bulunamadı");
            }
        }

        public IDataResult<List<UserAnswer>> GetAllByUserId(int userID, int QuizId)
        {
            var dataQuestions = _questionDal.GetAll(p => p.QuizId == QuizId);
            var data = new List<UserAnswer>();
            foreach (var dataQuestion in dataQuestions)
            {
                var answer = _userAnwserdal.Get(p => p.UserId == userID && p.QustionId == dataQuestion.Id);
                if (answer != null) {
                    data.Add(answer);
                }
                
            }
            return (data.Count !=0) 
                ? new SuccessDataResult<List<UserAnswer>>(data) 
                : new ErrorDataResult<List<UserAnswer>>("Bu kullanıcıya ait cevap girişi yok.");
        }

        public IResult updateByStudent(UserAnswer userAnswer)
        {
            int quizId = _questionDal.Get(p => p.Id == userAnswer.QustionId).QuizId;
            var time = _quizDal.Get(p => p.Id == quizId).DueDate;
            if(DateTime.Now <= time) {
                var answer = _userAnwserdal.Get(p => p.QustionId == userAnswer.QustionId && p.UserId == userAnswer.UserId);
                if(answer != null)
                {
                    userAnswer.Id = answer.Id;
                    _userAnwserdal.Update(userAnswer);
                    return new SuccessResult("cevap Güncellendi");
                }
                else
                {
                    _userAnwserdal.Add(userAnswer);
                    return new SuccessResult("cevap eklendi");

                }
            }
            else { return new ErrorResult("Sınav Süresi Dolduéé"); }
            

        }

        public IResult updateByTeacher(UserAnswer userAnswer)
        {
            var updatedAnswer = _userAnwserdal.Get(p => p.Id == userAnswer.Id);
            if(updatedAnswer != null)
            {
                _userAnwserdal.Update(userAnswer);
                return new SuccessResult("Puanlandı");
            }
            else
            {
                return new ErrorResult("Cevap bulunamadı");
            }
        }
    }
}
