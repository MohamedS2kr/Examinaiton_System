namespace ConsoleApp2
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        // Constructor
        public Answer()
        {
            AnswerId = 0;
            AnswerText = string.Empty;
        }
    }
    // Base class for Question
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public Answer[] AnswerList { get; set; }
        public int RightAnswer {  get; set; }

        public List<int> ChoiceUser { get; set; }

        public Question()
        {
            Header = string.Empty;
            Body = string.Empty;
            Mark = 0;
            AnswerList = new Answer[0]; // Initialize the array
        }
    }

    public class MCQAndChoices : Question
    {
        public MCQAndChoices()
        {
            AnswerList = new Answer[3]; // Initialize the array
            for (int i = 0; i < AnswerList.Length; i++)
            {
                AnswerList[i] = new Answer();
            }
        }
    }
    public class TFQuestion : Question
    {
        
    }

    // Base class for Exam
    public abstract class Exam
    {
        public int TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }

     

        public abstract void ShowExam();
    }

  
    

    // Subject class
    public class Subject : Exam
    {

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam exam { get; set; }

        int TypeOfExam, TimeOfExam, NumberOfQuestions, typeOfQuestion;


        List<Question> questions = new List<Question>();
        List<int> answeruser = new List<int>();
        DateTime startTime;
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public void CreateExam()
        {
            startTime = DateTime.Now;
            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create (1 for Practical and 2 for Final): ");

            } while (!int.TryParse(Console.ReadLine(), out TypeOfExam));
            do
            {
                Console.Write("Please Enter The Time Of in Miuntes: ");
            } while (!int.TryParse(Console.ReadLine(), out TimeOfExam));

            do
            {
                Console.Write("Please Enter The Number Of Questions You Wanted To Create: ");

            } while (!int.TryParse(Console.ReadLine(), out NumberOfQuestions));
            


            Console.Clear();
            
            
            if(TypeOfExam == 2) 
            {
                
                for (int i = 0; i < NumberOfQuestions; i++)
                {

                    do 
                    {
                    Console.WriteLine($"Please Choose The Type Of Question Number({i+1}) (1 for True Or False || 2 For Mcq) ");
                    }while(!int.TryParse(Console.ReadLine(),out typeOfQuestion));
                    

                    Console.Clear();

                    if(typeOfQuestion == 1)
                    {
                        TFQuestion tfQuestion = new TFQuestion();
                        
                        Console.WriteLine("True | False Qusetion");
                        tfQuestion.Header = "True | False Qusetion";
                        
                        do
                        {
                            Console.WriteLine("Please Enter The Body of Question");
                            tfQuestion.Body = Console.ReadLine();
                        } while (string.IsNullOrEmpty(tfQuestion.Body));


                        int mark;
                        do
                        {
                            Console.WriteLine("Please Enter The Marks of Question");

                        }while(!int.TryParse(Console.ReadLine(),out mark)); 

                        tfQuestion.Mark = mark;

                        int ans;
                        do
                        {

                        Console.WriteLine("Please Enter The Right Answer of Question (1 for True and 2 for False):");
                        }while(!int.TryParse(Console.ReadLine(),out ans));

                        tfQuestion.RightAnswer = ans;


                        
                        questions.Add(tfQuestion);
                        Console.Clear();
                    }
                    else
                    {
                        MCQAndChoices mCQAndChoices = new MCQAndChoices();
                        
                        Console.WriteLine("Choose One Answer Question");
                        mCQAndChoices.Header = "Choose One Answer Question";
                        Console.WriteLine("Please Enter The Body of Question");
                        mCQAndChoices.Body = Console.ReadLine();

                        int mark;
                        do
                        {
                            Console.WriteLine("Please Enter The Marks of Question");
                        } while (!int.TryParse(Console.ReadLine(), out mark));

                        mCQAndChoices.Mark = mark;

                        Console.WriteLine("The Choices Of Question:");

                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write($"Please Enter The Choice Number {j + 1}:");
                            string answer = Console.ReadLine();
                            mCQAndChoices.AnswerList[j].AnswerText = answer;
                        }

                        int rightChoice;
                        do
                        {
                            Console.WriteLine("Please Specify The Right Choice of Question");
                        } while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice < 1 || rightChoice > 3);
                        mCQAndChoices.RightAnswer = rightChoice;

                        questions.Add(mCQAndChoices);
                        Console.Clear();
                    }
                }

            }
            else
            {
                for(int i = 0; i < NumberOfQuestions;i++)
                {
                    MCQAndChoices mCQAndChoices = new MCQAndChoices();

                    Console.WriteLine("Choose One Answer Question");
                    mCQAndChoices.Header = "Choose One Answer Question";
                    Console.WriteLine("Please Enter The Body of Question");
                    mCQAndChoices.Body = Console.ReadLine();

                    int mark;
                    do
                    {
                        Console.WriteLine("Please Enter The Marks of Question");
                    } while (!int.TryParse(Console.ReadLine(), out mark));

                    mCQAndChoices.Mark = mark;

                    Console.WriteLine("The Choices Of Question:");

                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write($"Please Enter The Choice Number {j + 1}:");
                        string answer = Console.ReadLine();
                        mCQAndChoices.AnswerList[j].AnswerText = answer;
                    }

                    int rightChoice;
                    do
                    {
                        Console.WriteLine("Please Specify The Right Choice of Question");
                    } while (!int.TryParse(Console.ReadLine(), out rightChoice) || rightChoice < 1 || rightChoice > 3);
                    mCQAndChoices.RightAnswer = rightChoice;

                    questions.Add(mCQAndChoices);
                    Console.Clear();
                }
            }
        }

        public override void ShowExam()
        {
                    
                    foreach (Question question in questions)
                    {
                        Console.Write(question.Header);
                        Console.WriteLine($"           {question.Mark} Mark");
                        Console.WriteLine(question.Body);
                        if (question.Header == "True | False Qusetion")
                        {
                            Console.WriteLine("1.True                            2. False");
                        }
                        else
                        {
                             for (int i = 0; i < 3; i++)
                             {
                               Console.WriteLine($"{i + 1}.{question.AnswerList[i].AnswerText}            ");
                             }
                        }
                        Console.WriteLine("--------------------------------------------");
                        int answer = Convert.ToInt32(Console.ReadLine());
                        answeruser.Add(answer);
                        Console.WriteLine("============================================");
                    }

                Console.Clear();
                Console.WriteLine("Your Answers:");
                int grade = 0;
            int totalgrade =0;
                for (int i = 0;i<NumberOfQuestions;i++) 
                {
                    Console.Write($"Q{i+1}     {questions[i].Body} :");
                    if (questions[i].RightAnswer == answeruser[i])
                    {
                        Console.WriteLine("true");
                        grade += questions[i].Mark;
                    }
                    else 
                    {   
                        Console.WriteLine("false");
                        Console.WriteLine("Your Grade : 0 "); 

                    }
                   totalgrade += questions[i].Mark;
                }
                Console.WriteLine($"Your Grade is : {grade} from {totalgrade} ");
                DateTime endTime = DateTime.Now;
                TimeSpan elapsedTime = endTime - startTime;
                Console.WriteLine($"Time taken: {elapsedTime.TotalSeconds} seconds");
        }
    }

    class Program
    {
        static void Main()
        {
            
            Subject subject = new Subject(10, "C#");
            
            subject.CreateExam();

            Console.WriteLine("Do you want to start the exam? (Y/N)");
            string startExam = Console.ReadLine();

            if (startExam.ToUpper() == "Y")
            {
                subject.ShowExam();
            }
        }
    }
}