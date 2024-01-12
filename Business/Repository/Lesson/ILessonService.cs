using Business.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repository.Lesson
{
    public interface ILessonService
    {
        IResult Add(Entities.Concrete.Lesson lesson);
        IResult Delete(int lessonID);
        IResult Update(Entities.Concrete.Lesson lesson);

        IDataResult<Entities.Concrete.Lesson> Get(int id);
        IDataResult<List<Entities.Concrete.Lesson>> GetAll();
        IDataResult<List<Entities.Concrete.Lesson>> GetAllByUser(int userId);

        IDataResult<List<Entities.Concrete.Lesson>> GetForTeacher(int userId);

        



    }
}
