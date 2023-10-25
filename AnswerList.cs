namespace ExaminationSystem
{
	public class AnswerList
	{
		private Answer[] answers;

		public AnswerList(int count)
		{
			this.answers = new Answer[count];
		}

		public void SetAnswer(int index, Answer answer)
		{
			this.answers[index] = answer;
		}

		public Answer GetAnswer(int index)
		{
			return this.answers[index];
		}

		public int Grade(QuestionList questions)
		{
			int totalMarks = 0;
			int marksEarned = 0;

			for (int i = 0; i < questions.Count; i++)
			{
				Question question = questions[i];
				Answer answer = this.answers[i];

				if (answer == null)
				{
					Console.WriteLine("You did not answer question {0}.", i + 1);
				}
				else
				{
					if (answer.IsCorrect)
					{
						marksEarned += question.Marks;
					}
				}

				totalMarks += question.Marks;
			}

			Console.WriteLine("You scored {0}/{1} marks.", marksEarned, totalMarks);

			return marksEarned;
		}
	}
}
