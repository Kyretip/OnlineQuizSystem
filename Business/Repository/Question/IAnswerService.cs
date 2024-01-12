using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public interface IAnswerService
    {
        IResult Add(Answer answer);
        IResult Delete(int answerID);

        IResult Update(Answer answer);

        IDataResult<Answer> Get(int id);

        IDataResult<List<Answer>> GetAll(int questionID);

        

    }
}
