namespace ExaminationSystem
{
	public class ShortAnswerQuestion : Question
	{
		public string Answer { get; set; }

		public ShortAnswerQuestion(string body, int marks, string answer)
			: base(body, marks)
		{
			this.Answer = answer;
		}

		public override void Display()
		{
			Console.WriteLine("{0} ({1} marks)", this.Body, this.Marks);
		}
	}
}
