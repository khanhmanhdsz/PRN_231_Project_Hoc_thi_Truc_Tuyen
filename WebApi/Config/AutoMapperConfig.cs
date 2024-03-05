using AutoMapper;
using DataAccess.Models;
using ViewModels.Accounts;
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
                config.CreateMap<AccountVM, Account>()
                        .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
                config.CreateMap<Account, AccountVM>();

                // Mapper Question
                config.CreateMap<Question, QuestionVM>();
                config.CreateMap<QuestionVM, Question>();
                config.CreateMap<ImportQuestionVM, Question>();

                // Mapper QuestionHistory
                config.CreateMap<QuestionHistory, QuestionHistoryVM>();
                config.CreateMap<QuestionHistoryVM, QuestionHistory>();

                // Mapper Quiz
                config.CreateMap<Quiz, QuizVM>();
                config.CreateMap<QuizVM, Quiz>();

                // Mapper QuizHistory
                config.CreateMap<QuizHistory, QuizHistoryVM>()
                                        .ForMember(dest => dest.Quiz, opt => opt.MapFrom(src => src.Quiz));
                config.CreateMap<QuizHistoryVM, QuizHistory>();

                // Mapper Subject
                config.CreateMap<Subject, SubjectVM>();
                config.CreateMap<SubjectVM, Subject>();

            });

            return mapperConfig.CreateMapper();
        }
    }
}
