using Lessons_Basics.Lesson3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar
{









    internal class Sample03
    {
//3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
//Предусмотреть методы сложения, вычитания, умножения и деления дробей.
//Написать программу, демонстрирующую все разработанные элементы класса.
//    Добавить свойства типа int для доступа к числителю и знаменателю;
//    Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
//    ** Добавить проверку, чтобы знаменатель не равнялся 0.
//    Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0"); *** Добавить упрощение дробей.



        public void Main()
        {
            Console.WriteLine("Выбрать задания 3 или  6- если хотите выйти из программы");
            while (true)
            {
                var temp = Console.ReadLine();
                int count = 0;
                int.TryParse(temp, out count);
                if (count != 0)
                {
                    switch (count)
                    {
                        case 3:
                            Form_class();
                            break;                      
                      case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }

            }
            Console.ReadLine();
        }

        private static void Form_class()
        {
            Console.WriteLine("Выбрать задания от 1 до 1 или 6- если хотите выйти из программы");
           
                IFormClass formClassOperation = new FormClass();
                Console.WriteLine("укажите значение x1 через пробел ");
                EnterNumber(out var a, out var b);
                var x1 = new FormClass(ref a,ref  b);
                Console.WriteLine("укажите значение x2 через пробел ");
                EnterNumber(out var c, out var d);
                var x2 = new FormClass(ref c, ref d);
                Console.WriteLine($"X1 : {x1}");
                Console.WriteLine($"X2 : {x2}");           
                var res = formClassOperation.Additions(x1, x2);
                Console.WriteLine($"Additions : {res}");
                res = formClassOperation.Subtraction(x1, x2);
                Console.WriteLine($"Subtraction : {res}");
                res = formClassOperation.Division(x1, x2);
                Console.WriteLine($"Division : {res}");
                res = formClassOperation.Multiplication(x1, x2);
                Console.WriteLine($"Multiplication : {res}");
        }

        private static void EnterNumber(out int a, out int b)
        {
            var temp = Console.ReadLine().Split(' ');
             a = int.MinValue;
             b = int.MinValue;
            if (temp.Length == 2)
            {
                int.TryParse(temp[0], out a);
                int.TryParse(temp[1], out b);
                if (a != int.MinValue && b != int.MinValue && b != 0)
                {
                    return;
                }
                else
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
            }
        }
    }


}
