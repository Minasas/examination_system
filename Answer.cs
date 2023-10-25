namespace ExaminationSystem
{
	public class Answer
	{
		public string Body { get; set; }
		public bool IsCorrect { get; set; }

		public Answer(string body, bool isCorrect)
		{
			this.Body = body;
			this.IsCorrect = isCorrect;
		}

	}
}
