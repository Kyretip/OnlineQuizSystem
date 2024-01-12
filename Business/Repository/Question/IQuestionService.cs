using Business.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public interface IQuestionService
    {
        IResult Add(Entities.Concrete.Question question);
        IResult Delete(int id);
        IResult update(Entities.Concrete.Question question);

        IDataResult<Entities.Concrete.Question> Get(int id);
        IDataResult<List<Entities.Concrete.Question>> GetAllByQuiz(int Quizid);
    }
}
