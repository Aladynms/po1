using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException();

            int betterThan = 0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade > averageGrade)
                    betterThan++;
            }

            double studentAverageBetter = ((double)betterThan / (double)Students.Count) * 100;

            if (studentAverageBetter < 20) return 'A';
            else if (studentAverageBetter >= 20 && studentAverageBetter < 40) return 'B';
            else if (studentAverageBetter >= 40 && studentAverageBetter < 60) return 'C';
            else if (studentAverageBetter >= 60 && studentAverageBetter < 80) return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) Console.WriteLine("Ranked grading require at least 5 students");
            else base.CalculateStatistics();
        }

    }
}
