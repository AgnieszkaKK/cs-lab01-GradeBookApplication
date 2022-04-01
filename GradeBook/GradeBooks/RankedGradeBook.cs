using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
   public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            name = Name;
            Type = Enums.GradeBookType.Ranked;
        }
        
          public override char GetLetterGrade(double averageGrade)
        {
            /*try 
            { 
                if(Students.Count<5 )
             {
                    Console.WriteLine(InvalidOperationException);
             }*/
            
             if (Students.Count<5)
                throw new ArgumentException("InvalidOperationException. More than 5 students must be taken into the consideration. ");
            List<double> sortedGrades = new List<double>();

            foreach (Student student in Students)
            {
                sortedGrades.Add(student.AverageGrade);   
            }

            sortedGrades.Reverse();

            //nowe 100%
            double maxAverageGrade =sortedGrades[0];
            double Mark80p = maxAverageGrade * 0.8;
            double Mark60p = maxAverageGrade * 0.6;
            double Mark40p = maxAverageGrade * 0.4;
            double Mark20p = maxAverageGrade * 0.2;



            if (averageGrade >= Mark80p)
                return 'A';
            else if (averageGrade >= Mark60p && averageGrade <= Mark80p)
                return 'B';
            else if (averageGrade >= Mark40p && averageGrade < Mark60p)
                return 'C';
            else if (averageGrade >= Mark20p && averageGrade < Mark40p)
                return 'D';
            else
                return 'F';
        }

              

            
    }
}
