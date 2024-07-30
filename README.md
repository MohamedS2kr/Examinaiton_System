# Examination system according

## Overview
This project is an Examination System designed to handle both Final and Practical exams. The system is structured to manage various types of questions, display exams, and show results based on the exam type. It is built with a focus on object-oriented principles, utilizing class inheritance and interfaces.

## Features
- Supports two types of exams: Final and Practical.
- Handles different types of questions:
  - True/False and Multiple Choice Questions (MCQ) for Final Exams.
  - Multiple Choice Questions (MCQ) for Practical Exams.
- Displays correct answers at the end of Practical Exams.
- Shows questions, answers, and grades at the end of Final Exams.
- Each exam is associated with a subject.

## Class Design

### Question Class
Represents a question with:
- `Header` - The question's header.
- `Body` - The question's body.
- `Mark` - The mark allocated to the question.

### Question Types
Inherits from the base `Question` class:
- `TrueFalseQuestion` - Represents a True/False question.
- `MCQQuestion` - Represents a Multiple Choice Question.

### Answer Class
Represents an answer option with:
- `AnswerId` - The unique identifier for the answer.
- `AnswerText` - The text of the answer.

### Exam Class
Base class for all exams, containing:
- `Time` - The time allocated for the exam.
- `NumberOfQuestions` - The number of questions in the exam.
- `ShowExam` - A method to display the exam; implementation varies based on exam type.

### Exam Types
Inherits from the base `Exam` class:
- `FinalExam` - Implements functionality specific to final exams.
- `PracticalExam` - Implements functionality specific to practical exams.

### Subject Class
Represents a subject associated with an exam:
- `SubjectId` - The unique identifier for the subject.
- `SubjectName` - The name of the subject.
- `Exam` - The exam associated with the subject.

## Interfaces and Overrides
- Implements `ICloneable` and `IComparable`.
- Overrides `ToString` method for meaningful output.
- Uses constructor chaining where necessary.

## Usage
To create and run an exam, instantiate a `Subject` object and use it to create an exam of the desired type. For example:

```csharp
// Example code to create and run an exam
Subject subject = new Subject(1, "Mathematics");
Exam exam = new FinalExam(subject);
exam.ShowExam();
