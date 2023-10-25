namespace ExaminationSystem
{
	public class TrueFalseQuestion : Question
	{
		public bool Answer { get; set; }

		public TrueFalseQuestion(string body, int marks, bool answer)
			: base(body, marks)
		{
			this.Answer = answer;
		}

		public override void Display()
		{
			Console.WriteLine("{0} ({1} marks)", this.Body, this.Marks);
			Console.WriteLine("True or False?");
		}
	}
}
