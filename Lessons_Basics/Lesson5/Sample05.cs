using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Lessons_Basics.Lesson5
{
    internal class Sample05
    {
        readonly Func<string, int> StringParse = x => int.TryParse(x, out int assessment1) ? assessment1 : new int();

        //Converter<string, uint> convertuint = d => Convert.ToUInt32(d);

        //4. *Задача ЕГЭ.На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов
        //некоторой средней школы. В первой строке сообщается количество учеников N,
        //которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        //<Фамилия> <Имя> <оценки>, где <Фамилия> — строка,
        //состоящая не более чем из 20 символов, <Имя> — строка,
        //состоящая не более чем из 15 символов, <оценки> —
        //через пробел три целых числа, соответствующие оценкам по пятибалльной
        //системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом. Пример входной строки:
        //Иванов Петр 4 5 3 Требуется написать как можно более эффективную
        //программу, которая будет выводить на экран фамилии и имена
        //трёх худших по среднему баллу учеников. Если среди остальных
        //есть ученики, набравшие тот же средний балл, что и один из трёх худших,
        //следует вывести и их фамилии и имена.
        internal void ListStudents()
        {
            var wath = new Stopwatch();
            wath.Start();
            Console.WriteLine("Задача ЕГЭ.На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов");
            string path = @"Students.txt";
            var stream= new FileReader(path);
            bool flag = true; 
            int CountSt = 0;
            var student =new Students();
             foreach (string item in  stream.GetLine())
            {
                if (flag && int.TryParse(item,out var count) && count >0 )
                {
                    CountSt = count;
                    flag=false;
                    student.CountStudent = count;
                    continue;
                }
                var splitstr =item.Split(' ');
                if (splitstr.Length ==5)
                {
                   
                   var student1 = new Student();
                    student1.LastName = splitstr[0];
                    student1.Name = splitstr[1];

                    student1.assessments[0] = StringParse(splitstr[2]);
                    student1.assessments[1] = StringParse(splitstr[3]);
                    student1.assessments[2] = StringParse(splitstr[4]);
                    student.GetStudents.Add(student1);
                }

            }
            if (student.CountStudent <10)// по требованию меньше 10(нельзя)
            {
                Environment.Exit(-1);
            }
            student.ToImmutable();

           var minAver = student.GetStudents.Min(x => x.Average);
            var Lousers = student.GetStudents.Where(x => x.Average == minAver);//.Take(3);//сортируем и вы выводим всех аутсайдеров 
                                                                               // var Lousers= student.GetStudents.OrderBy(x => x.Average).Take(3);//сортируем и вы выводим 3 аутсайдера
            int i = 0;
            foreach (var item in Lousers)
            { 
                Console.WriteLine($"{++i}:{item.LastName} {item.Name} {item.Average}");
            }

            wath.Stop();
            Console.WriteLine($"Затрачено:{wath.ElapsedMilliseconds }");
            Console.ReadLine();

        }
    }
}
