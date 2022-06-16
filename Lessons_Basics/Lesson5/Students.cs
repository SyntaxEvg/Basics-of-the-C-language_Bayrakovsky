using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons_Basics.Lesson5
{
    internal class Students
    {
        public int CountStudent { get; set; }
        public ImmutableList<Student>.Builder GetStudents  = ImmutableList.CreateBuilder<Student>();
        //public Student MyProperty { get; set; }

        public Students()
        {

        }
        public void ToImmutable()
        {
            GetStudents.ToImmutable();
        }


    }

    public class Student
    { //<Фамилия> и<Имя>, а также<Имя> и<оценки>
        public string LastName { get; set; }
        public string Name { get; set; }

       // public readonly ImmutableArray<Assessment> assessment = new ImmutableArray<Assessment>();
       // public readonly List<Assessment> assessment = new List<Assessment>();
        public double Average { get { return assessments.Cast<int>().Average(); } }
        
        public int[] assessments =new int[3];



    }
    ///// <summary>
    ///// оценки 
    ///// </summary>
    //public class Assessment
    //{
    //    public int assessment1 { get; set; }
    //    public int assessment2 { get; set; }
    //    public int assessment3 { get; set; }
    //    public int Average { get;private set; }

    //    public Assessment()
    //    {

    //    }


    //    public IEnumerator<Assessment> GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
