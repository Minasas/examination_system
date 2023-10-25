namespace ExaminationSystem
{
	public abstract class Question
	{
		public string Body { get; set; }
		public int Marks { get; set; }

		public Question(string body, int marks)
		{
			this.Body = body;
			this.Marks = marks;
		}

		public abstract void Display();
	}
}
