namespace ViewModels.Questions
{
    public class ImportQuestionVM
    {
        public string Index { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string AnswerA { get; set; } = string.Empty;
        public string AnswerB { get; set; } = string.Empty;
        public string AnswerC { get; set; } = string.Empty;
        public string AnswerD { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty;
        public string? ImportMessage { get; set; } = string.Empty;
        public int QuizId { get; set; }
    }
}
