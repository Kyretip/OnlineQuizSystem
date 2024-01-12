using Business.Repository.Quiz;
using DataAccess.EntityFramework;
using Entities.Concrete;

class Program
{

    static void Main()
    {


        var manager = new QuizUserManager(new EfQuizUserDal(), new EfLessonUserDal(), new EfQuizDal());
     

        var list = manager.GetAllByQuiz(1).Data;

        

        foreach (var item in list) {
            Console.WriteLine(item.Id);

        }








    }
}
