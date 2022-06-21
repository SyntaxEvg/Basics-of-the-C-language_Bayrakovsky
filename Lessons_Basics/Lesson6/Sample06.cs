using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Lessons_Basics.Lesson6
{   // 2. Модифицировать программу нахождения минимума функции так, чтобы можно было
    // передавать функцию в виде делегата.
    // а) Сделать меню с различными функциями и представить пользователю выбор, для какой
    // функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов,
    // в котором хранятся различные функции.
    internal class Sample06
    {
        readonly Func<string, double> ConvertDoubleParse = x => double.TryParse(x, out double parse) ? parse : 0;


        public Sample06()
        {
        }

        internal async void MinValue()
        {
            Console.WriteLine("Для нахождения мин введите  кол-во значений");
            int.TryParse( Console.ReadLine(),out var count);
            ImmutableList<double>.Builder list = ImmutableList.CreateBuilder<double>();
            if (count>0)
            {
                Console.WriteLine($"Введите через  пробел {count} цифр, и нажмите enter");
                var numbers =Console.ReadLine().Split(' ');
                if (numbers.Length>3)
                {
                    foreach (var item in numbers.AsEnumerable().AsParallel())
                    {
                        list.Add(ConvertDoubleParse(item));
                    }
                    list.ToImmutable();
                  
                    var min = list.Min();//из всей последовательности
                    Console.WriteLine($"Min: {min}");
                }
                else
                {//  ну или рандом 
                    Random _rand = new Random();
                    var results = Enumerable.Range(_rand.Next(10), _rand.Next(10000000))
                                            .Select(r => _rand.Next(11));
                     foreach (var item in  results.AsParallel())
                    {
                        list.Add(item);
                    }
                    list.ToImmutable();
                    var min = results.Min();//из всей последовательности
                    Console.WriteLine($"Min: {min}");
                    //диапазон можно и свой задать ,можно и делигат в другой класс.но задание не передает  сути, того что хочет преподаватель(это велосипед слишком простой ))
                    int x1 = list.Count() / 2;
                    int end = _rand.Next(5, 1000);
                    int x2 = list.Count() - end;

                    var minRange = list.Skip(x1-1)
                    .Take(x2).AsParallel().Min();
                    Console.WriteLine($"Min range: {minRange}");

                }
              
            }

        }
    }
}