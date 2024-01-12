using Business.Results.Abstract;
using Business.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.Quiz
{
    public class QuizManager : IQuizService
    {
        IQuizDal _quizDal;
        IQuestionDal _questionDal;
        IAnswerDal _answerDal;
        IQuizUserDal _quizUserDal;
        ILessonDal _lessonDal;
        IUserDal _userDal;
        IUserAnswerDal _userAnswerDal;
        

        public QuizManager(IQuizDal quizDal, IQuestionDal questionDal, IAnswerDal answerDal,IQuizUserDal quizUserDal,
            ILessonDal lessonDal, IUserDal userDal, IUserAnswerDal userAnswerDal  ) {
            _quizDal = quizDal;
            _questionDal = questionDal;
            _answerDal = answerDal;
            _quizUserDal = quizUserDal;
            _lessonDal = lessonDal;
            _userDal = userDal;
            _userAnswerDal = userAnswerDal;
           
        }

        public IResult Add(Entities.Concrete.Quiz quiz)
        {
            _quizDal.Add( quiz );
            return new SuccessResult("Ekleme Başarılı");
        }

        public IResult Delete(int id)
        {
            var deletedQuiz = _quizDal.Get(p => p.Id == id);
            if (deletedQuiz != null )
            {
                _quizDal.Delete(deletedQuiz);
                return new SuccessResult("Silme işlemi başarılı");
            }
            else { return new ErrorResult("Sınav Bulunamadı"); }
        }

        public IDataResult<Entities.Concrete.Quiz> Get(int id)
        {
            var data = _quizDal.Get(p => p.Id == id);

            return (data!= null)
                ? new SuccessDataResult<Entities.Concrete.Quiz>(data)
                : new ErrorDataResult<Entities.Concrete.Quiz>("Sınav bulunamadı");
        }

        public IDataResult<List<Entities.Concrete.Quiz>> GetAllbyUser(int UserId)
        {
            //bir öğrencinin henüz girilmemiş sınavları
            var data = _quizUserDal.GetAll(p=> p.UserId.Equals(UserId));
            
            if(data != null && data.Any())
            {
                
                List<Entities.Concrete.Quiz> quizzes = new List<Entities.Concrete.Quiz>();
                data.ForEach(x => quizzes.Add(_quizDal.Get(p => p.Id == x.QuizId)));

                 return new SuccessDataResult<List<Entities.Concrete.Quiz>>(quizzes);

            }
            else
            {
              return  new ErrorDataResult<List<Entities.Concrete.Quiz>>("Bekleyen Sınav yok");
            }
                
        }

        public IDataResult<List<Entities.Concrete.Quiz>> GetByLessonandUserId(int userId)
        {
            //bir kullanıcının verdiği derslerin gerçekleşmiş ama sonuçlandırılmamış okunmayı bekleyen sınavlarını gönderir
            var lessons = _lessonDal.GetAll(p => p.UserId == userId);
            List< Entities.Concrete.Quiz > quizzes = new List<Entities.Concrete.Quiz> ();
            if(lessons != null && lessons.Any())
            {
                foreach( var lesson in lessons)
                {
                    var data = _quizDal.GetAll(p => p.LessonId == lesson.Id && p.DueDate <= DateTime.Now && p.isFinalized == false);
                    if(data != null && data.Any())
                    {
                        data.ForEach(quiz => quizzes.Add(quiz));
                        return new SuccessDataResult<List<Entities.Concrete.Quiz>>(quizzes);
                    }
                    else
                    {
                        return new ErrorDataResult<List<Entities.Concrete.Quiz>>("Sonuçlandırılmayı bekleyen sınav yok");
                    }
                }

                

              
                
            }
            else { return new ErrorDataResult<List<Entities.Concrete.Quiz>>("Kullanıcı ders vermiyor"); }
            

            throw new NotImplementedException();

        }

        public IDataResult<QuizDTO> GetFullQuizByQuizUser(QuizHomeDto quizHomeDto)
        {
            var quizUser = _quizUserDal.Get(q => q.QuizId.Equals(quizHomeDto.quizId) && q.UserId.Equals(quizHomeDto.userId));
            var quiz = _quizDal.Get(x => x.Id == quizUser.QuizId);
            if (quiz != null)
            {
                if(DateTime.Now >= quiz.StartDate && DateTime.Now <= quiz.DueDate){

                    QuizDTO quizDTO = new QuizDTO();
                    quizDTO.ID = quiz.Id;
                    quizDTO.Name = quiz.Name;
                    quizDTO.LessonID = quiz.LessonId;
                    quizDTO.DueDate = quiz.DueDate;
                    List<QuestionDTO> questionsDTOs = new List<QuestionDTO>();
                    var questions = _questionDal.GetAll(p => p.QuizId == quiz.Id);
                    if(questions != null && questions.Any())//sorulara giriş
                    {
                        foreach(var question in questions)
                        {
                            QuestionDTO questionDTO = new QuestionDTO();
                            questionDTO.QuestionID = question.Id;
                            questionDTO.Name = question.Name;
                            questionDTO.AnswerType = question.AnswerType;
                            questionDTO.Photo = question.Photo;
                            questionDTO.Point = question.Point;
                            if(question.AnswerType == true)
                            {
                                List<Answer> answers = new List<Answer>();
                                var answerlist = _answerDal.GetAll(p => p.QuestionId == question.Id);
                                if (answerlist != null && answerlist.Any())
                                {
                                    answerlist.ForEach(x =>  answers.Add(x) );
                                    questionDTO.Answers = answers;
                                }
                                

                            }
                            
                            //oluşturulan question DTO lar oluşup eklenir
                            questionsDTOs.Add(questionDTO);
                            

                        }

                    }
                    else
                    {
                        return new ErrorDataResult<QuizDTO>("Bu Sınava Ait soru bulunamadı");
                    }
                    //oluşturulup listelenen dtolar QuizDTOsuna yerleştirilir
                    quizDTO.Questions = questionsDTOs;
                    //Başarılı Gönderme işlemi
                    quizUser.Entered = true;
                    quiz.Return = true;
                    _quizUserDal.Update(quizUser);
                    _quizDal.Update(quiz);
                    return new SuccessDataResult<QuizDTO>(quizDTO);


                }
                else
                {
                    return new ErrorDataResult<QuizDTO>("Sınav Saatleri arasında değilsiniz!");
                }

            }
            else { return new ErrorDataResult<QuizDTO>("Böyle bir Sınav Bulunamadı"); }

        }

        public IDataResult<UserQuizDTO> GetFullUserQuizForStudent(QuizUser quizUser)
        {
            //bir kullanıcının girdiği sınavın tüm sorularını ve kullanıcının cevaplarını tek parça halinde gönderir
            var user = _quizUserDal.Get(p => p.Id == quizUser.Id);
            if (user != null)
            {
                UserQuizDTO userQuiz = new UserQuizDTO();
                var quiz = _quizDal.Get(p => p.Id == quizUser.QuizId);
                userQuiz.QuizName = quiz.Name;
                userQuiz.UserID = quizUser.UserId;
                userQuiz.QuizId = quiz.Id;
                userQuiz.LessonID = quiz.LessonId;
                userQuiz.UserName = _userDal.Get(p => p.Id == quizUser.UserId).Name;
                userQuiz.LessonName = _lessonDal.Get(p => p.Id == quiz.LessonId).Name;
                List<UserAnswerDTO> userAnswers = new List<UserAnswerDTO>();
                var questions = _questionDal.GetAll(p => p.QuizId == quiz.Id);
               
                foreach (var question in questions)
                {
                    UserAnswerDTO userAnswerDTO = new UserAnswerDTO();
                    QuestionDTO questionDTO = new QuestionDTO();
                    questionDTO.Name = question.Name;
                    questionDTO.QuestionID = question.Id;
                    questionDTO.AnswerType = question.AnswerType;
                    questionDTO.Point = question.Point;
                    questionDTO.Photo = question.Photo;
                    if (question.AnswerType == true)
                    {
                        List<Answer> answers = new List<Answer>();
                        var answerlist = _answerDal.GetAll(p => p.QuestionId == question.Id);
                        if (answerlist != null)
                        {
                            answerlist.ForEach(x => answers.Add(x));
                            questionDTO.Answers = answers;
                        }
                        
                    }
                    userAnswerDTO.question = questionDTO;
                    var useranswer = _userAnswerDal.Get(p => p.QustionId == question.Id && p.UserId == quizUser.UserId);
                    if(useranswer != null)
                    {
                        userAnswerDTO.UserAnswerID = useranswer.Id;
                        userAnswerDTO.AnswerText = useranswer.AnswerText;
                    }
                    userAnswers.Add(userAnswerDTO);
                    
                    
                }

                userQuiz.Answers = userAnswers;

                return new SuccessDataResult<UserQuizDTO>(userQuiz);

            }
            else
            {
                return new ErrorDataResult<UserQuizDTO>("Kiş bulunamadı");
            }

            
        }

        public IResult Update(Entities.Concrete.Quiz quiz)
        {
            var updatedQuiz = _quizDal.Get(p => p.Id == quiz.Id);
            if (updatedQuiz != null) { 
            _quizDal.Update(quiz);
                return new SuccessResult("Güncelleme işlemi başarılı");
            }
            else
            {
                return new ErrorResult("Sınav Bulunamadı!");
            }
        }
    }
}
