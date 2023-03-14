using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name) : base(name)
		{
			Type = Enums.GradeBookType.Ranked;
		}

        public override char GetLetterGrade(double averageGrade)
        {
			if (Students.Count < 5)
				throw new InvalidOperationException();

			int treshold = (int)Math.Ceiling(Students.Count * 0.2);

			var sortedGrades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

			var rank = sortedGrades.FindIndex(e => e == averageGrade) + 1;

			if (rank <= treshold)
				return 'A';
			else if (rank <= treshold * 2)
				return 'B';
			else if (rank <= treshold * 3)
				return 'C';
			else if (rank <= treshold * 4)
				return 'D';
			else
				return 'F';
        }

        public override void CalculateStatistics()
        {
			if (Students.Count < 5)
				Console.WriteLine("Ranked grading requires at least 5 students.");
			else
				base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
			if (Students.Count < 5)
				Console.WriteLine("Ranked grading requires at least 5 students.");
			else
				base.CalculateStudentStatistics(name);
        }
    }
}

