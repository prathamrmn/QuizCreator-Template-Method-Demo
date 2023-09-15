using System;
using System.Collections.Generic;

namespace QuizCreator
{
    /// <summary>
    /// Represents a quiz with multiple correct multiple-choice questions.
    /// </summary>
    public class MultiCorrectMultipleChoiceQuiz : Quiz
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCorrectMultipleChoiceQuiz"/> class.
        /// </summary>
        /// <param name="questions">An array of quiz questions.</param>
        /// <param name="answers">An array of correct answers for the questions.</param>
        /// <param name="instructions">Instructions for the quiz.</param>
        public MultiCorrectMultipleChoiceQuiz( string[] questions , string[] answers , string instructions )
            : base( questions , answers , instructions )
        {
        }

        /// <summary>
        /// Asks the multiple-choice questions to the candidate.
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
        /// Validates a candidate's answer to ensure it follows the required format.
        /// </summary>
        /// <param name="candidateAnswer">The candidate's answer.</param>
        /// <returns>True if the answer is valid; otherwise, false.</returns>
        private bool IsValidAnswer( string? candidateAnswer )
        {
            if (string.IsNullOrWhiteSpace( candidateAnswer ))
            {
                return false;
            }

            string[] answers = candidateAnswer.Split( ' ' );

            if (answers.Length > 4 || answers.Length == 0)
            {
                return false;
            }

            HashSet<string> uniqueOptions = new();

            foreach (string option in answers)
            {
                if (!(option == "A" || option == "B" || option == "C" || option == "D"))
                {
                    return false;
                }

                if (!uniqueOptions.Add( option ))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Calculates the candidate's score based on their answers.
        /// </summary>
        protected override void CalculateScore()
        {
            if (CandidateAnswers == null)
            {
                return;
            }

            for (int i = 0; i < CandidateAnswers.Length; ++i)
            {
                string[] correctAnswers = Answers[i].Split( ' ' );
                string[] candidateAnswers = CandidateAnswers[i].Split( ' ' );

                if (correctAnswers.Length > candidateAnswers.Length)
                {
                    Score -= 0.25;
                    continue;
                }

                int correct = 0;

                foreach (string option in candidateAnswers)
                {
                    if (Array.Exists( correctAnswers , a => a == option ))
                    {
                        correct++;
                    }
                }

                if (correct == correctAnswers.Length)
                {
                    Score++;
                }
                else
                {
                    Score -= 0.25;
                }
            }
        }
    }
}
