using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public class AnswerManager : IAnswerService
    {
        IAnswerDal _answerdal;

        public AnswerManager(IAnswerDal answerdal)
        {
            _answerdal = answerdal;
        }

        public IResult Add(Answer answer)
        {
            _answerdal.Add(answer);
            return new SuccessResult("Ekleme Başarılı");

        }

        public IResult Delete(int answerID)
        {
            var deletedAnswer = _answerdal.Get(p => p.Id == answerID);
            if (deletedAnswer != null)
            {
                _answerdal.Delete(deletedAnswer);
                return new SuccessResult("Silme işlemi başarılı");
            }
            else { return new ErrorResult("Öğe bulunamadı"); }
        }

        public IDataResult<Answer> Get(int id)
        {
            var data = _answerdal.Get(p => p.Id == id);
            return (data != null)
                ? new SuccessDataResult<Answer>(data) : new ErrorDataResult<Answer>("Soru Bulunamadı");
        }

        public IDataResult<List<Answer>> GetAll(int questionID)
        {
            var data = _answerdal.GetAll(p => p.QuestionId == questionID);
            return (data != null && data.Any())
                ? new SuccessDataResult<List<Answer>>(data) : new ErrorDataResult<List<Answer>>("Cevap Bulunamadı");
        }

        public IResult Update(Answer answer)
        {
            var updatedAnswer = _answerdal.Get(p => p.Id == answer.Id);
            if (updatedAnswer != null)
            {
                _answerdal.Update(answer);
                return new SuccessResult("Güncelleme başarılı");

            }
            else
            {
                return new ErrorResult("Öğe bulunamadı!");
            }
        }
    }
}
