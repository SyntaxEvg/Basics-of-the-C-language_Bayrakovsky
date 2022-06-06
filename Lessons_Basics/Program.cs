using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar
{
    internal class Sample01
    {
        //1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
        //а) используя склеивание;
        //б) используя форматированный вывод;
        //в) используя вывод со знаком $.2. Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
        //3.
        //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
        //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
        //4. Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
        //а) с использованием третьей переменной;
        // б) *без использования третьей переменной.


        static async Task Main(string[] args)
        {
            Console.WriteLine("Выбрать задания от 1 до 1 или 6- если хотите выйти из программы");
            while (true)
            {
                var temp = Console.ReadLine();
                int count = 0;
                int.TryParse(temp, out count);
                if (count != 0)
                {
                    switch (count)
                    {
                        case 1:
                            Form(out var growth, out var weight);
                            MassaBody(ref growth, ref weight);
                            break;
                        case 2:
                            DistanceBetweenPoints();
                            break;
                        case 3:
                            exchangevalue();
                            break;
                        case 4:
                            PrintFullName();
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

        /// <summary>
        /// Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
        /// </summary>
        private static void PrintFullName()
        {
            Console.WriteLine("Имя Фамилия через пробел");
            string full = Console.ReadLine();
            int X = (Console.WindowWidth / 2) - (full.Length / 2);
            int Y = (Console.WindowHeight / 2) - 1;
            printConsole(full, ref X, ref Y);
            // а) 
            //б) Сделать задание, только вывод организовать в центре экрана.
            //*Сделать задание б с использованием собственных методов(например, Print(string ms, int x, int y).
        }

        private static void printConsole(in string full, ref int X, ref int Y)
        {
            Console.SetCursorPosition(X, Y);
            Console.WriteLine($"{full}");
        }

        /// <summary>
        /// Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
        /// </summary>
        private static void exchangevalue()
        {
            Random random = new Random();
            int var1 = random.Next(0, 1000);
            int var2 = random.Next(0, 100);
            int temp = var1;
            var1 = var2;
            var2 = temp;
            Console.WriteLine($"после обмена {var1}:{var2}");
            var1 += var2;
            var2 -= var1;
            var2 = -var2;
            var1 -= var2;
            Console.WriteLine($"после обмена 2 способ:{var1}:{var2}");
        }

        /// <summary>
        /// Написать программу, которая подсчитает расстояние между точками с координатами
        /// </summary>
        private static void DistanceBetweenPoints()
        {
            Console.WriteLine("Pасстояние между точками с координатами.\nВведи х1:");
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            Console.WriteLine($"Результат: {Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)):F2}");
        }

        /// <summary>
        /// Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле
        /// </summary>
        private static void MassaBody(ref double growth, ref double weight)
        {
            double result = (growth * growth) / weight;
            Console.WriteLine($"Индекс массы тела: {(growth * growth) / weight:F2}");
        }

        /// <summary>
        /// Анкета
        /// </summary>
        private static void Form(out double growth, out double weight)
        {
            //без проверок 
            Console.WriteLine("Анкета:");
            Console.WriteLine("Имя?\n");
            string name = Console.ReadLine();
            Console.WriteLine($"Фамилия?");
            string lastName = Console.ReadLine();
            Console.WriteLine($"{name} {lastName}");
            Console.WriteLine("Возраст?");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Рост?");
            growth = double.Parse(Console.ReadLine());
            Console.WriteLine("Вес");
            weight = double.Parse(Console.ReadLine());

            string final = "Имя фамилия: " + name + " " + lastName + "." + " Возраст: " + age + ". Рост: " + growth + " Вес: " + weight;
            Console.WriteLine(final);
            Console.WriteLine("Имя фамилия: " + name + " "
                + lastName + ". Возраст {0}, рост {1:F2}, вес {2:F2}",
                age, growth, weight);
            Console.WriteLine($"Тебя зовут: {name} {lastName} " +
                $"Твой рост: {growth} вес: {weight}");
        }
    }


}
