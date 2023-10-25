namespace ExaminationSystem
{
	public class MultipleChoiceQuestion : Question
	{
		public string[] Options { get; set; }
		public int Answer { get; set; }

		public MultipleChoiceQuestion(string body, int marks, string[] options, int answer)
			: base(body, marks)
		{
			this.Options = options;
			this.Answer = answer;
		}

		public override void Display()
		{
			Console.WriteLine("{0} ({1} marks)", this.Body, this.Marks);
			for (int i = 0; i < this.Options.Length; i++)
			{
				Console.WriteLine("{0}. {1}", i + 1, this.Options[i]);
			}
		}
	}
}
