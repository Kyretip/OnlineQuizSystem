using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Quiz
{
    public interface IQuizUserService
    {
        IResult Add(QuizUser quizUser);
        IResult Delete(int id);
        IResult Update(QuizUser quizUser); 
        
        IResult AddList(List<QuizUser> userList);

        IResult AddScore(QuizUser user, float score, bool success);
        IDataResult<QuizUser> Get(int id);


        IDataResult<List<QuizUser>> GetAllByQuiz(int quizID);
        IDataResult<List<QuizUser>> GetAllByUser(int UserId);
        IDataResult<List<QuizUser>> GetAllByUserActive(int UserId);
        IDataResult<List<QuizUser>> GetAllByUserNotActive(int UserId);

        IDataResult<List<QuizUser>>GettAllQuizHistory(int userID);


    }
}
