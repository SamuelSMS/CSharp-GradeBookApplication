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

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
