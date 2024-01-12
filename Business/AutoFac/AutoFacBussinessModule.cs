using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Repository.Auth;
using Business.Repository.Lesson;
using Business.Repository.Question;
using Business.Repository.Quiz;
using Business.Repository.User;
using Business.Security.JWT;
using Business.ValidationRules.Interceptors;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoFac
{
    public class AutoFacBussinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfQuizDal>().As<IQuizDal>();
            builder.RegisterType<QuizManager>().As<IQuizService>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EfUserTypeDal>().As<IUserTypeDal>();
            builder.RegisterType<UserTypeManager>().As<IUserTypeService>();

            builder.RegisterType<EfLessonUserDal>().As<ILessonUserDal>();
            builder.RegisterType<LessonUserManager>().As<ILessonUserService>();

            builder.RegisterType<EfLessonDal>().As<ILessonDal>();
            builder.RegisterType<LessonManager>().As<ILessonService>();

            builder.RegisterType<EfQuizUserDal>().As<IQuizUserDal>();
            builder.RegisterType<QuizUserManager>().As<IQuizUserService>();

            builder.RegisterType<EfQuestionDal>().As<IQuestionDal>();
            builder.RegisterType<QuestionManager>().As<IQuestionService>();

            builder.RegisterType<EfUserAnswerDal>().As<IUserAnswerDal>();
            builder.RegisterType<UserAnswerManager>().As<IUserAnswerService>();

            builder.RegisterType<EfAnswerDal>().As<IAnswerDal>();
            builder.RegisterType<AnswerManager>().As<IAnswerService>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
          


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();






        }
    }
}
