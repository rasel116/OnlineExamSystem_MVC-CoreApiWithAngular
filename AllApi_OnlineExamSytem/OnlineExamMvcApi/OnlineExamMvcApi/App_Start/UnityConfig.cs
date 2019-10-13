using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

using OnlineExamMvcApi.Models.Repository;
using OnlineExamMvcApi.Models;

namespace OnlineExamMvcApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //add for student
            container.RegisterType<IDataAccessRepository<Student, int>, ClsStudent>();

            //add for Registration
            container.RegisterType<IDataAccessRepository<Registration, int>, ClsRegistration>();

            //add for Test
            container.RegisterType<IDataAccessRepository<Test, int>, ClsTest>();

            //add for QuestionXDuration
            container.RegisterType<IDataAccessRepository<QuestionXDuration, int>, ClsQuestionXDuration>();

            //add for TestXPaper
            container.RegisterType<IDataAccessRepository<TestXPaper, int>, ClsTestXPaper>();

            //add for TestXQuestion
            container.RegisterType<IDataAccessRepository<TestXQuestion, int>, ClsTestXQuestion>();

            //add for Choice
            container.RegisterType<IDataAccessRepository<Choice, int>, ClsChoice>();

            //add for Question
            container.RegisterType<IDataAccessRepository<Question, int>, ClsQuestion>();

            //add for Exhibit
            container.RegisterType<IDataAccessRepository<Exhibit, int>, ClsExhibit>();

            //add for Subject
            container.RegisterType<IDataAccessRepository<Subject, int>, ClsSubject>();

            //add for QuestionCategory
            container.RegisterType<IDataAccessRepository<QuestionCategory, int>, ClsQuestionCategory>();

            //add for Organization
            container.RegisterType<IDataAccessRepository<Organization, int>, ClsOrganization>();

            //add for AdminPanel
            container.RegisterType<IDataAccessRepository<AdminPanel, int>, ClsAdminPanel>();
            //add for QuizQuestion
            container.RegisterType<IDataAccessRepository<QuizQuestion, int>, ClsQuizQuestion>();


            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}