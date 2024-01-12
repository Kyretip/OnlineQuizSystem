using Business.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Quiz
{
    public interface IQuizService
    {
        IResult Add(Entities.Concrete.Quiz quiz);
        IResult Delete(int id);
        IResult Update(Entities.Concrete.Quiz quiz);

        IDataResult<Entities.Concrete.Quiz> Get(int id);
        IDataResult<List<Entities.Concrete.Quiz>> GetAllbyUser(int UserId);

        IDataResult<List<Entities.Concrete.Quiz>> GetByLessonandUserId(int userId);

        IDataResult<QuizDTO> GetFullQuizByQuizUser(QuizHomeDto quizHomeDto);
        IDataResult<UserQuizDTO> GetFullUserQuizForStudent(QuizUser quizUser);



    }
}
