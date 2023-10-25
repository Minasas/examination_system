using System;
using System.IO;

namespace ExaminationSystem
{
	public enum ExamMode { Starting, Queued, Finished }

	class Program
	{
		static void Main(string[] args)
		{


			string input = string.Empty;
			while (input != "1" && input != "2")
			{
				Console.WriteLine("Please select the exam type:");
				Console.WriteLine("1. Practice Exam");
				Console.WriteLine("2. Final Exam");

				input = Console.ReadLine();

				if (input != "1" && input != "2")
				{
					Console.WriteLine("Invalid input. Please enter 1 for Practice Exam or 2 for Final Exam.");
				}
			}



			QuestionList questions = new QuestionList("questions.txt");

			TrueFalseQuestion tfq = new TrueFalseQuestion("Is C# an object-oriented programming language?", 1, true);
			TrueFalseQuestion tfq2 = new TrueFalseQuestion(" Can we obtain the array index using foreach loop in C#?", 1, false);

			MultipleChoiceQuestion mcq = new MultipleChoiceQuestion("Which data type is used to store text value in C#?", 2, new string[] { "text", "string", "txt", "str" }, 2);
			MultipleChoiceQuestion mcq2 = new MultipleChoiceQuestion("Which is not a valid C# data type?", 2, new string[] { "long", "int", "float", "complex" }, 4);

			ChooseAllQuestion caq = new ChooseAllQuestion("What is the correct syntax to declare a variable in C#?", 3, new string[] { "type variableName = value;", "type variableName;", "variableName as type = value;", "typevariable Name;" }, new int[] { 1, 2 });
			ChooseAllQuestion caq2 = new ChooseAllQuestion("Which is/are the correct method(s) to input a float value in C#?", 3, new string[] { "ToFloat(Console.ReadLine());", "Parse(Console.ReadLine())", "ToSingle(Console.ReadLine())", "Toint(Console.ReadLine())" }, new int[] { 2, 3 });

			ShortAnswerQuestion saq = new ShortAnswerQuestion("Which C# keyword is used to define a constant?", 4, "const");
			ShortAnswerQuestion saq2 = new ShortAnswerQuestion("Which array property is used to get the total number of elements in C#?", 4, "Length");

			questions.Add(tfq);
			questions.Add(tfq2);

			questions.Add(mcq);
			questions.Add(mcq2);

			questions.Add(caq);
			questions.Add(caq2);

			questions.Add(saq);
			questions.Add(saq2);






			Exam exam = new Exam(questions, 5);

			exam.Start();




			if (input == "1")
			{
				exam.ShowAnswerPractice();
			}
			else if (input == "2")
			{
				exam.ShowUserAnswerFinal();
			}



			exam.Grade();
			//Environment.Exit(0);
			Console.WriteLine("Press any key to exit.");
			Console.ReadKey(true);


		}
	}
}
