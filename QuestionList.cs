namespace ExaminationSystem
{
	public class QuestionList : System.Collections.Generic.List<Question>
	{
		private string fileName;

		public QuestionList(string fileName)
		{
			this.fileName = fileName;
		}

		public new void Add(Question question)
		{
			base.Add(question);
			LogQuestion(question);
		}

		private void LogQuestion(Question question)
		{
			using (StreamWriter writer = new StreamWriter(this.fileName, true))
			{
				writer.WriteLine("Question:");
				writer.WriteLine("Marks: " + question.Marks);
				writer.WriteLine("Body: " + question.Body);

				if (question is TrueFalseQuestion)
				{
					TrueFalseQuestion tfq = (TrueFalseQuestion)question;
					writer.WriteLine("Type: True/False");
					writer.WriteLine("Answer: " + tfq.Answer);
				}
				else if (question is MultipleChoiceQuestion)
				{
					MultipleChoiceQuestion mcq = (MultipleChoiceQuestion)question;
					writer.WriteLine("Type: Multiple Choice");
					writer.WriteLine("Options:");
					for (int i = 0; i < mcq.Options.Length; i++)
					{
						writer.WriteLine((i + 1) + ". " + mcq.Options[i]);
					}
					writer.WriteLine("Answer: " + mcq.Answer);
				}
				else if (question is ChooseAllQuestion)
				{
					ChooseAllQuestion caq = (ChooseAllQuestion)question;
					writer.WriteLine("Type: Choose All");
					writer.WriteLine("Options:");
					for (int i = 0; i < caq.Options.Length; i++)
					{
						writer.WriteLine((i + 1) + ". " + caq.Options[i]);
					}
					writer.WriteLine("Answers: " + string.Join(", ", caq.Answers));
				}
				else if (question is ShortAnswerQuestion)
				{
					ShortAnswerQuestion saq = (ShortAnswerQuestion)question;
					writer.WriteLine("Type: Short Answer");
					writer.WriteLine("Answer: " + saq.Answer);
				}

				writer.WriteLine();
			}
		}
	}
}
