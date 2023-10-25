namespace ExaminationSystem
{
	public class ChooseAllQuestion : Question
	{
		public string[] Options { get; set; }
		public int[] Answers { get; set; }

		public ChooseAllQuestion(string body, int marks, string[] options, int[] answers)
			: base(body, marks)
		{
			this.Options = options;
			this.Answers = answers;
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
