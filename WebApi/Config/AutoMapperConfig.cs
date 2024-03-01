using AutoMapper;
using DataAccess.Models;
using ViewModels.Accounts;
using ViewModels.Answers;
using ViewModels.Questions;
using ViewModels.QuestionHistories;
using ViewModels.Quizzes;
using ViewModels.QuizHistories;
using ViewModels.Subjects;

namespace WebApi.Config
{
    public class AutoMapperConfig : Profile
    {
        public static IMapper Initialize()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                // Mapper Account
                config.CreateMap<AccountVM, Account>();
                config.CreateMap<Account, AccountVM>();

                // Mapper Answer
                config.CreateMap<Answer, AnswerVM>();
                config.CreateMap<AnswerVM, Answer>();

                // Mapper Question
                config.CreateMap<Question, QuestionVM>();
                config.CreateMap<QuestionVM, Question>();

                // Mapper QuestionHistory
                config.CreateMap<QuestionHistory, QuestionHistoryVM>();
                config.CreateMap<QuestionHistoryVM, QuestionHistory>();

                // Mapper Quiz
                config.CreateMap<Quiz, QuizVM>();
                config.CreateMap<QuizVM, Quiz>();

                // Mapper QuizHistory
                config.CreateMap<QuizHistory, QuizHistoryVM>();
                config.CreateMap<QuizHistoryVM, QuizHistory>();

                // Mapper Subject
                config.CreateMap<Subject, SubjectVM>();
                config.CreateMap<SubjectVM, Subject>();

            });

            return mapperConfig.CreateMapper();
        }
    }
}
