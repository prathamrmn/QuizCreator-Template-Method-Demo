# Quiz Creator

## Introduction

The Quiz Creator is a C# application that allows you to create and administer quizzes of various types, including single correct multiple-choice quizzes, multiple correct multiple-choice quizzes, and subjective quizzes. It utilizes the Template Method design pattern to define the structure of the quiz-taking process while allowing customization for different quiz types.

## Template Method Design Pattern

The Template Method design pattern is a behavioral pattern that defines the skeleton of an algorithm in the base class but lets subclasses override specific steps of the algorithm without changing its structure. In this application, the `Quiz` class serves as the template with the following key methods:

- `AskCandidateDetails()`: Asks the candidate for their name and ID.
- `DisplayInstructions()`: Displays quiz instructions.
- `AskQuestions()`: Abstract method for asking quiz questions (customized by subclasses).
- `CalculateScore()`: Calculates the candidate's quiz score.
- `DisplayResults()`: Displays quiz results, including candidate details and score.

## Quiz Types

### 1. Single Correct Multiple-Choice Quiz (`SingleCorrectMultipleChoiceQuiz`)

This quiz type allows candidates to select a single correct option (A, B, C, or D) for each multiple-choice question.

### 2. Multiple Correct Multiple-Choice Quiz (`MultiCorrectMultipleChoiceQuiz`)

This quiz type allows candidates to select multiple correct options for each multiple-choice question. The template method calculates the score based on correct answers.

### 3. Subjective Quiz (`SubjectiveQuiz`)

This quiz type includes open-ended questions, and candidates provide text answers. The template method ensures candidates provide answers for all questions.

## Usage

1. Create instances of the quiz types you want to administer.
2. Customize quiz questions, correct answers, and instructions as needed.
3. Call the `AttemptQuiz()` method to start the quiz-taking process.
4. Candidates will be prompted for their details, and then the quiz will be administered.
5. The quiz results, including the candidate's score, will be displayed.

## Example

```csharp
// Create a single correct multiple-choice quiz
var singleChoiceQuiz = new SingleCorrectMultipleChoiceQuiz(
    questions,
    answers,
    instructions
);

// Start the quiz
singleChoiceQuiz.AttemptQuiz();
