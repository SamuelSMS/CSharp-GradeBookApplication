using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name)
            : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("At least five students are required for ranked grading.");
            }

            List<double> sortedAverageGrades = Students.Select(s => s.AverageGrade).ToList();
            sortedAverageGrades.OrderByDescending(g => g);

            int studentIndex = sortedAverageGrades.FindIndex(g => g == averageGrade);
            char grade = (char)((int)'A' + (studentIndex / (Students.Count / 5)));
            return (studentIndex == -1 || grade == 'E') ? 'F' : grade;
        }
    }
}
