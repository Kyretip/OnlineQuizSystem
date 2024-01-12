using Business.BusinessAspects.AutoFac;
using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public class QuestionManager : IQuestionService
    {
        IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        //[SecuredOperation("Question.add,Ogretmen")]
        public IResult Add(Entities.Concrete.Question question)
        {
            _questionDal.Add(question);
            return new SuccessResult("Soru Eklendi");
        }

        public IResult Delete(int id)
        {
            var deletedQuestion = _questionDal.Get(p => p.Id == id);
            if (deletedQuestion != null)
            {
                _questionDal.Delete(deletedQuestion);
                return new SuccessResult("Silme işlemi başarılı");
            }
            else { return new ErrorResult("Soru bulunamadı");
            }
        }

        public IDataResult<Entities.Concrete.Question> Get(int id)
        {
            var data = _questionDal.Get(p => p.Id == id);
            return (data!= null)
                ? new SuccessDataResult<Entities.Concrete.Question>(data) 
                : new ErrorDataResult<Entities.Concrete.Question>("Soru bulunamadı");
        }

        public IDataResult<List<Entities.Concrete.Question>> GetAllByQuiz(int Quizid)
        {
            var data = _questionDal.GetAll(p => p.QuizId == Quizid);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<Entities.Concrete.Question>>(data)
                : new ErrorDataResult<List<Entities.Concrete.Question>>("Soru bulunamadı");
        }

        public IResult update(Entities.Concrete.Question question)
        {
           var updatedQuestion = _questionDal.Get(p => p.Id == question.Id);
            if(updatedQuestion != null)
            {
                _questionDal.Update(question);
                return new SuccessResult("SOru başarıyla güncellendi.");
            }
            else
            {
                return new ErrorResult("Hata Soru bulunamadı!");
            }
        }
    }

      
    }

