namespace ExaminationSystem
{
	public class Exam
	{
		private ExamMode mode;
		private QuestionList questions;
		private AnswerList answers;
		private int timeLeft;

		public Exam(QuestionList questions, int timeLimitMinutes)
		{
			this.mode = ExamMode.Starting;
			this.questions = questions;
			this.answers = new AnswerList(questions.Count);
			this.timeLeft = timeLimitMinutes * 60;
		}

		public void Start()
		{
			this.mode = ExamMode.Queued;

			while (this.mode == ExamMode.Queued)
			{
				if (this.timeLeft <= 0)
				{
					Console.WriteLine("Time's up!");
					this.mode = ExamMode.Finished;
				}

				Console.WriteLine("Time left: {0} seconds", this.timeLeft);

				for (int i = 0; i < this.questions.Count; i++)
				{
					Question question = this.questions[i];
					Answer answer = this.answers.GetAnswer(i);

					Console.WriteLine("Question {0}:", i + 1);
					question.Display();

					if (answer != null)
					{
						Console.WriteLine("Your answer: {0}", answer.Body);
					}

					Console.Write("Your answer: ");
					string input = Console.ReadLine();

					if (question is TrueFalseQuestion)
					{
						bool boolInput = Boolean.Parse(input);
						answer = new Answer(boolInput.ToString(), boolInput == ((TrueFalseQuestion)question).Answer);
					}
					else if (question is MultipleChoiceQuestion)
					{
						int intInput = Int32.Parse(input);
						answer = new Answer(intInput.ToString(), intInput == ((MultipleChoiceQuestion)question).Answer);
					}
					else if (question is ChooseAllQuestion)
					{
						int[] intInputs = Array.ConvertAll(input.Split(','), int.Parse);
						bool isCorrect = intInputs.OrderBy(i => i).SequenceEqual(((ChooseAllQuestion)question).Answers.OrderBy(i => i));
						answer = new Answer(string.Join(", ", intInputs), isCorrect);
					}
					else if (question is ShortAnswerQuestion)
					{
						answer = new Answer(input, input.ToLower() == ((ShortAnswerQuestion)question).Answer.ToLower());
					}


					this.answers.SetAnswer(i, answer);
				}

				Console.WriteLine("Press any key to submit your answers.\n\n\n");
				Console.ReadKey(true);



				this.mode = ExamMode.Finished;


			}
		}

		public void ShowAnswerPractice()
		{
			int questionCount = questions.Count;

			for (int i = 0; i < questionCount; i++)
			{
				Question q = questions[i];

				if (q is TrueFalseQuestion)
				{
					Console.WriteLine("\tCorrect answer for question {0}: {1}\n", i + 1, ((TrueFalseQuestion)q).Answer);
				}
				else if (q is MultipleChoiceQuestion)
				{
					Console.WriteLine("\tCorrect answer for question {0}: {1}\n", i + 1, ((MultipleChoiceQuestion)q).Answer);
				}
				else if (q is ChooseAllQuestion)
				{
					Console.WriteLine("\tCorrect answer for question {0}: {1}\n", i + 1, string.Join(",", ((ChooseAllQuestion)q).Answers));
				}
				else if (q is ShortAnswerQuestion)
				{
					Console.WriteLine("\tCorrect answer for question {0}: {1}\n", i + 1, ((ShortAnswerQuestion)q).Answer);
				}
			}
		}

		public void ShowUserAnswerFinal()
		{
			int questionCount = questions.Count;

			for (int i = 0; i < questionCount; i++)
			{
				Question q = questions[i];

				Console.WriteLine("Question {0}:\n", i + 1);
				Console.WriteLine($"{q.Body}\n");
				Answer userAnswer = answers.GetAnswer(i);
				if (userAnswer != null)
				{
					Console.WriteLine("Your answer: {0}\n", userAnswer.Body);
				}
				else
				{
					Console.WriteLine("You did not answer this question.\n");
				}
			}
		}


		public void Grade()
		{
			if (this.mode != ExamMode.Finished)
			{
				Console.WriteLine("Cannot grade unfinished exam.");
				return;
			}

			this.answers.Grade(this.questions);
		}
	}
}
