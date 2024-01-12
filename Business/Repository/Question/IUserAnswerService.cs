using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Question
{
    public interface IUserAnswerService
    {
        IResult Add(UserAnswer userAnswer);
        IResult Delete(int id);
        IResult updateByTeacher(UserAnswer userAnswer);

        IResult updateByStudent(UserAnswer userAnswer);

        IDataResult<List<UserAnswer>> GetAllByUserId(int userID, int QuizId);

        
    }
}
