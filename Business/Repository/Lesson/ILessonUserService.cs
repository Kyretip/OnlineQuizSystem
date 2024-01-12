using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Lesson
{
    public interface ILessonUserService
    {
        IResult Add(LessonUser lessonUser);

        IResult AddAll(List<LessonUser> userList);

        IResult Delete (int id);
        IResult Update (LessonUser lessonUser);
        IDataResult<LessonUser> Get(int id);
        IDataResult<List<LessonUser>> GetAll ();
        IDataResult<List<LessonUser>> GetAllByLesson(int lessonId);
        IDataResult<List<LessonUser>> GetAllByLessonActive(int lessonId);
        IDataResult<List<LessonUser>> GetAllByLessonNotActive(int lessonId);

        IDataResult<List<LessonUser>> GetAllByStudendId(int studendId);


    }
}
