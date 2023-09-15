using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace QuizCreator.Tests
{
    [TestClass]
    public class QuizTests
    {
        [TestMethod]
        public void MultiCorrectMultipleChoiceQuiz_AllCorrectAnswers1()
        {
            string[] questions = new string[]
            {
                "1. Which of the following are examples of renewable resources?\r\n* A. Solar energy\r\n* B. Wind energy\r\n* C. Hydro energy\r\n* D. Fossil fuels",
                "2. Which of the following are mammals?\r\n* A. Dogs\r\n* B. Cats\r\n* C. Fish\r\n* D. Birds",
                "3. Which of the following are fruits?\r\n* A. Apples\r\n* B. Bananas\r\n* C. Grass\r\n* D. Flowers"
            };
            string[] answers = new string[]
            {
                "C A B",
                "A B",
                "B A"
            };
            string instructions = "These questions have multiple correct answers, write the letter of the options separated by spaces to answer";
            Quiz quiz = new MultiCorrectMultipleChoiceQuiz(questions, answers, instructions);
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nThese questions have multiple correct answers, write the letter of the options separated by spaces to answer\r\n-\r\n1. Which of the following are examples of renewable resources?\r\n* A. Solar energy\r\n* B. Wind energy\r\n* C. Hydro energy\r\n* D. Fossil fuels\r\n2. Which of the following are mammals?\r\n* A. Dogs\r\n* B. Cats\r\n* C. Fish\r\n* D. Birds\r\n3. Which of the following are fruits?\r\n* A. Apples\r\n* B. Bananas\r\n* C. Grass\r\n* D. Flowers\r\n-------------------------------------\r\nResults\r\nName : Pratham\r\nID : 21\r\nYour score is 3/3.\r\n-------------------------------------";
            string input = "Pratham\r\n21\r\nA B C\r\nA B\r\nA B";
            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();
            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SingleCorrectMultipleChoiceQuiz_SomeCorrectAnswers()
        {
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
            string instructions = "These are single correct answer questions, write the letter of the option you think is the answer";
            Quiz quiz = new SingleCorrectMultipleChoiceQuiz(questions, answers, instructions);
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nThese are single correct answer questions, write the letter of the option you think is the answer\r\n-\r\n1. Which planet is closest to the Sun?\r\n* A. Venus\r\n* B. Mercury\r\n* C. Earth\r\n* D. Mars\r\n2. What is the most common element in the universe?\r\n* A. Hydrogen\r\n* B. Helium\r\n* C. Oxygen\r\n* D. Nitrogen\r\n3. What is the largest land animal on Earth?\r\n* A. Rhinoceros\r\n* B. Elephant\r\n* C. Hippopotamus\r\n* D. Lion\r\n-------------------------------------\r\nResults\r\nName : Pratham\r\nID : 21\r\nYour score is 1/3.\r\n-------------------------------------";
            string input = "Pratham\r\n21\r\nC\r\nA\r\nA";
            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();
            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SubjectiveQuiz_AllCorrectAnswers()
        {
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
            Quiz quiz = new SubjectiveQuiz( questions , answers , instructions );
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nThese are subjective questions.\r\n-\r\nWhat is the capital of France?\r\nWhat is the capital of India?\r\nWhat is the capital of Australia\r\n-------------------------------------\r\nResults\r\nName : Pratham\r\nID : 21\r\nYour score is 3/3.\r\n-------------------------------------";
            string input = "Pratham\r\n21\r\nParis\r\nNew Delhi\r\nCanberra";
            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();
            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void MultiCorrectMultipleChoiceQuiz_AllCorrectAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question",
                "2. Question",
                "3. Question"
            };
            string[] answers = new string[]
            {
                "A B C",
                "A B",
                "A B C"
            };
            string instructions = "Instructions";
            Quiz quiz = new MultiCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nA B C\r\nA B\r\nA B C";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question\r\n2. Question\r\n3. Question\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 3/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void MultiCorrectMultipleChoiceQuiz_SomeIncorrectAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question A",
                "2. Question B",
                "3. Question C"
            };
            string[] answers = new string[]
            {
                "A B C",
                "A B",
                "A B C"
            };
            string instructions = "Instructions";
            Quiz quiz = new MultiCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nA B D\r\nA C\r\nA B C";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question A\r\n2. Question B\r\n3. Question C\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 0.5/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SingleCorrectMultipleChoiceQuiz_AllCorrectAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question A",
                "2. Question B",
                "3. Question C"
            };
            string[] answers = new string[]
            {
                "A",
                "B",
                "C"
            };
            string instructions = "Instructions";
            Quiz quiz = new SingleCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nA\r\nB\r\nC";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question A\r\n2. Question B\r\n3. Question C\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 3/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SingleCorrectMultipleChoiceQuiz_SomeIncorrectAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question A",
                "2. Question B",
                "3. Question C"
            };
            string[] answers = new string[]
            {
                "A",
                "B",
                "C"
            };
            string instructions = "Instructions";
            Quiz quiz = new SingleCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nB\r\nA\r\nA";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question A\r\n2. Question B\r\n3. Question C\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 0/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SubjectiveQuiz_AllCorrectAnswers2()
        {
            string[] questions = new string[]
            {
                "1. What is 2 + 2?",
                "2. What is the capital of France?",
                "3. Who wrote Romeo and Juliet?"
            };
            string[] answers = new string[]
            {
                "4",
                "Paris",
                "William Shakespeare"
            };
            string instructions = "Instructions";
            Quiz quiz = new SubjectiveQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\n4\r\nParis\r\nWilliam Shakespeare";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. What is 2 + 2?\r\n2. What is the capital of France?\r\n3. Who wrote Romeo and Juliet?\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 3/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SubjectiveQuiz_SomeIncorrectAnswers()
        {
            string[] questions = new string[]
            {
                "1. What is 2 + 2?",
                "2. What is the capital of France?",
                "3. Who wrote Romeo and Juliet?"
            };
            string[] answers = new string[]
            {
                "4",
                "Paris",
                "William Shakespeare"
            };
            string instructions = "Instructions";
            Quiz quiz = new SubjectiveQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\n3\r\nLondon\r\nWilliam Shakespeare";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. What is 2 + 2?\r\n2. What is the capital of France?\r\n3. Who wrote Romeo and Juliet?\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 1/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void MultiCorrectMultipleChoiceQuiz_InvalidAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question A",
                "2. Question B",
                "3. Question C"
            };
            string[] answers = new string[]
            {
                "A B C",
                "A B",
                "A B C"
            };
            string instructions = "Instructions";
            Quiz quiz = new MultiCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nA B C D\r\nX Y Z\r\nasdf\r\nA\nA B";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question A\r\n2. Question B\r\nPlease try answering again.\r\nPlease try answering again.\r\n3. Question C\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 0.5/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SingleCorrectMultipleChoiceQuiz_InvalidAnswers()
        {
            string[] questions = new string[]
            {
                "1. Question A",
                "2. Question B",
                "3. Question C"
            };
            string[] answers = new string[]
            {
                "A",
                "B",
                "C"
            };
            string instructions = "Instructions";
            Quiz quiz = new SingleCorrectMultipleChoiceQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\nX Y\r\nA B C D\r\nB C D A\r\nB\r\nD\r\nC";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. Question A\r\nPlease try answering again.\r\nPlease try answering again.\r\nPlease try answering again.\r\n2. Question B\r\n3. Question C\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 1/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }

        [TestMethod]
        public void SubjectiveQuiz_EmptyAnswers()
        {
            string[] questions = new string[]
            {
                "1. What is 2 + 2?",
                "2. What is the capital of France?",
                "3. Who wrote Romeo and Juliet?"
            };
            string[] answers = new string[]
            {
                "4",
                "Paris",
                "William Shakespeare"
            };
            string instructions = "Instructions";
            Quiz quiz = new SubjectiveQuiz( questions , answers , instructions );
            string input = "Name\r\nID\r\n\r\n\r\n\r\nA\r\nB\r\nC\r\n";
            string expected = "Enter your Name: \r\nEnter your ID: \r\nInstructions:\r\nInstructions\r\n-\r\n1. What is 2 + 2?\r\nInvalid answer, please try again.\r\nInvalid answer, please try again.\r\nInvalid answer, please try again.\r\n2. What is the capital of France?\r\n3. Who wrote Romeo and Juliet?\r\n-------------------------------------\r\nResults\r\nName : Name\r\nID : ID\r\nYour score is 0/3.\r\n-------------------------------------";

            using var sr = new StringReader( input );
            using var sw = new StringWriter();
            Console.SetOut( sw );
            Console.SetIn( sr );
            quiz.AttemptQuiz();
            string result = sw.ToString().Trim();

            Assert.AreEqual( expected , result );
        }
    }
}
