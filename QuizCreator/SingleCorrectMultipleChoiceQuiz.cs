using System;
using System.Collections.Generic;

namespace QuizCreator
{
    /// <summary>
    /// Represents a quiz with single correct multiple-choice questions.
    /// </summary>
    public class SingleCorrectMultipleChoiceQuiz : Quiz
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleCorrectMultipleChoiceQuiz"/> class.
        /// </summary>
        /// <param name="questions">An array of quiz questions.</param>
        /// <param name="answers">An array of correct answers for the questions.</param>
        /// <param name="instructions">Instructions for the quiz.</param>
        public SingleCorrectMultipleChoiceQuiz( string[] questions , string[] answers , string instructions )
            : base( questions , answers , instructions )
        {
        }

        /// <summary>
        /// Asks the single correct multiple-choice questions to the candidate.
        /// </summary>
        protected override void AskQuestions()
        {
            List<string> candidateAnswers = new();

            for (int i = 0; i < Questions.Length; ++i)
            {
                Console.WriteLine( Questions[i] );

                while (true)
                {
                    string? candidateAnswer = Console.ReadLine();

                    if (IsValidAnswer( candidateAnswer ))
                    {
                        candidateAnswers.Add( candidateAnswer );
                        break;
                    }

                    Console.WriteLine( "Please try answering again." );
                }
            }

            CandidateAnswers = candidateAnswers.ToArray();
        }

        /// <summary>
        /// Validates a candidate's answer to ensure it's one of the valid choices (A, B, C, or D).
        /// </summary>
        /// <param name="candidateAnswer">The candidate's answer.</param>
        /// <returns>True if the answer is valid; otherwise, false.</returns>
        private bool IsValidAnswer( string? candidateAnswer )
        {
            return !string.IsNullOrWhiteSpace( candidateAnswer ) &&
                   (candidateAnswer == "A" || candidateAnswer == "B" || candidateAnswer == "C" || candidateAnswer == "D");
        }
    }
}
