using QuizCreator;

// Display the quiz selection menu
Console.WriteLine( "+----+" );
Console.WriteLine( "|Quiz|" );
Console.WriteLine( "+----+" );
Console.WriteLine( "Quiz options:" );
Console.WriteLine( "1. Multi correct MCQ" );
Console.WriteLine( "2. Single correct MCQ" );
Console.WriteLine( "3. Subjective" );
Console.WriteLine( "Enter your choice:" );

Quiz? quiz = null;

while (quiz == null)
{
    // Read the user's choice
    string? input = Console.ReadLine();
    if (int.TryParse( input , out int choice ))
    {
        switch (choice)
        {
            case 1:
                {
                    // Questions, answers, and instructions for MultiCorrectMultipleChoiceQuiz
                    string[] questions = new string[]
                    {
                        "1. Which of the following are examples of renewable resources?\r\n* A. Solar energy\r\n* B. Wind energy\r\n* C. Hydro energy\r\n* D. Fossil fuels",
                        "2. Which of the following are mammals?\r\n* A. Dogs\r\n* B. Cats\r\n* C. Fish\r\n* D. Birds",
                        "3. Which of the following are fruits?\r\n* A. Apples\r\n* B. Bananas\r\n* C. Grass\r\n* D. Flowers"
                    };
                    string[] answers = new string[]
                    {
                        "A B C",
                        "A B",
                        "A B"
                    };
                    string instructions = "These questions have multiple correct answers.\r\nWrite the letter of the options separated by spaces to answer.\r\nIf the answer does not match exactly then -0.25 marks";

                    // Create a MultiCorrectMultipleChoiceQuiz
                    quiz = new MultiCorrectMultipleChoiceQuiz( questions , answers , instructions );
                    break;
                }
            case 2:
                {
                    // Questions, answers, and instructions for SingleCorrectMultipleChoiceQuiz
                    string[] questions = new string[]
                    {
                        "1. Which planet is closest to the Sun?\r\n* A. Venus\r\n* B. Mercury\r\n* C. Earth\r\n* D. Mars",
                        "2. What is the most common element in the universe?\r\n* A. Hydrogen\r\n* B. Helium\r\n* C. Oxygen\r\n* D. Nitrogen",
                        "3. What is the largest land animal on Earth?\r\n* A. Rhinoceros\r\n* B. Elephant\r\n* C. Hippopotamus\r\n* D. Lion"
                    };
                    string[] answers = new string[]
                    {
                        "B",
                        "A",
                        "B"
                    };
                    string instructions = "These are single correct answer questions.\r\nWrite the letter of the option you think is the answer.";

                    // Create a SingleCorrectMultipleChoiceQuiz
                    quiz = new SingleCorrectMultipleChoiceQuiz( questions , answers , instructions );
                    break;
                }
            case 3:
                {
                    // Questions, answers, and instructions for SubjectiveQuiz
                    string[] questions = new string[]
                    {
                        "What is the capital of France?",
                        "What is the capital of India?",
                        "What is the capital of Australia"
                    };
                    string[] answers = new string[]
                    {
                        "Paris",
                        "New Delhi",
                        "Canberra"
                    };
                    string instructions = "These are subjective questions.";

                    // Create a SubjectiveQuiz
                    quiz = new SubjectiveQuiz( questions , answers , instructions );
                    break;
                }
            default:
                {
                    Console.WriteLine( "Invalid choice, please try again." );
                    break;
                }
        }
    }
    else
    {
        Console.WriteLine( "Invalid choice, please try again." );
    }
}

// Attempt the selected quiz
quiz?.AttemptQuiz();
