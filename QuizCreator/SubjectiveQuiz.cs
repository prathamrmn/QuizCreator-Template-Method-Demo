using System;
using System.Collections.Generic;

namespace QuizCreator
{
    /// <summary>
    /// Represents a subjective quiz with open-ended questions.
    /// </summary>
    public class SubjectiveQuiz : Quiz
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubjectiveQuiz"/> class.
        /// </summary>
        /// <param name="questions">An array of subjective quiz questions.</param>
        /// <param name="answers">An array of correct answers for the questions.</param>
        /// <param name="instructions">Instructions for the quiz.</param>
        public SubjectiveQuiz( string[] questions , string[] answers , string instructions )
            : base( questions , answers , instructions )
        {
        }

        /// <summary>
        /// Asks the subjective questions to the candidate.
        /// </summary>
        protected override void AskQuestions()
        {
            List<string> candidateAnswers = new();

            for (int i = 0; i < Questions.Length; ++i)
            {
                Console.WriteLine( Questions[i] );

                string? answer = Console.ReadLine();

                while (string.IsNullOrWhiteSpace( answer ))
                {
                    Console.WriteLine( "Invalid answer, please try again." );
                    answer = Console.ReadLine();
                }

                candidateAnswers.Add( answer );
            }

            CandidateAnswers = candidateAnswers.ToArray();
        }
    }
}
