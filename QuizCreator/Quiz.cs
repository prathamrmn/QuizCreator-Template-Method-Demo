namespace QuizCreator
{
    /// <summary>
    /// Base class for creating a quiz.
    /// </summary>
    public abstract class Quiz
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Quiz"/> class.
        /// </summary>
        /// <param name="questions">An array of quiz questions.</param>
        /// <param name="answers">An array of correct answers for the questions.</param>
        /// <param name="instructions">Instructions for the quiz.</param>
        public Quiz( string[] questions , string[] answers , string instructions )
        {
            Questions = questions;
            Answers = answers;
            Instructions = instructions;
        }

        /// <summary>
        /// Gets the candidate details.
        /// </summary>
        public CandidateDetails? CandidateDetails { get; protected set; }

        /// <summary>
        /// Gets the quiz questions.
        /// </summary>
        public string[] Questions { get; }

        /// <summary>
        /// Gets the correct answers for the quiz questions.
        /// </summary>
        public string[] Answers { get; }

        /// <summary>
        /// Gets the candidate's answers to the quiz questions.
        /// </summary>
        public string[]? CandidateAnswers { get; protected set; }

        /// <summary>
        /// Gets the quiz instructions.
        /// </summary>
        public string Instructions { get; }

        /// <summary>
        /// Gets the quiz score.
        /// </summary>
        public double Score { get; protected set; } = 0;

        /// <summary>
        /// Starts the quiz
        /// </summary>
        public void AttemptQuiz()
        {
            AskCandidateDetails();
            DisplayInstructions();
            AskQuestions();
            CalculateScore();
            DisplayResults();
        }

        /// <summary>
        /// Asks the candidate for their name and ID.
        /// </summary>
        protected virtual void AskCandidateDetails()
        {
            Console.WriteLine( "Enter your Name: " );
            string? name = Console.ReadLine();
            Console.WriteLine( "Enter your ID: " );
            string? candidateID = Console.ReadLine();
            CandidateDetails = new CandidateDetails( name , candidateID );
        }

        /// <summary>
        /// Abstract method for asking quiz questions (to be implemented by derived classes).
        /// </summary>
        protected abstract void AskQuestions();

        /// <summary>
        /// Calculates the candidate's quiz score.
        /// </summary>
        protected virtual void CalculateScore()
        {
            int score = 0;
            if (CandidateAnswers == null)
            {
                return;
            }

            for (int i = 0; i < Questions.Length; ++i)
            {
                if (CandidateAnswers[i] == Answers[i])
                {
                    score++;
                }
            }
            Score = score;
        }

        /// <summary>
        /// Displays the quiz results, including candidate details and score.
        /// </summary>
        protected virtual void DisplayResults()
        {
            Console.WriteLine( "-------------------------------------" );
            Console.WriteLine( $"Results" );
            Console.WriteLine( $"Name : {CandidateDetails.Name}" );
            Console.WriteLine( $"ID : {CandidateDetails.CandidateID}" );
            Console.WriteLine( $"Your score is {Score}/{Questions.Length}." );
            Console.WriteLine( "-------------------------------------" );
        }

        /// <summary>
        /// Displays the quiz instructions.
        /// </summary>
        protected virtual void DisplayInstructions()
        {
            Console.WriteLine( "Instructions:" );
            Console.WriteLine( Instructions );
            Console.WriteLine( "-" );
        }
    }
}
