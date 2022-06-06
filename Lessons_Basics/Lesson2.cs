using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lessons_Basics
{
    public class Lesson2
    {
        //1. Написать метод, возвращающий минимальное из трёх чисел.
        //2. Написать метод подсчета количества цифр числа.
        //3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        //4. Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
      
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
                           var min= Min();
                            Console.WriteLine($"{min}");
                            break;
                        case 2:
                             CountingNumber();
                            break;
                        case 3:
                            Notzero();
                            break;
                        case 4:
                            Authenticated("root","GeekBrains");
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

        record Account(string Login,string Password);

        private static void Authenticated(string login, string password)
        {
            int bag = 3;
            Predicate<Account> predicate = Check;

            Console.Write("Введите логин и пароль через пробел");
            while (true)
            {
                var log = Console.ReadLine().Split(' ');
                if (predicate != null && log.Length > 0)
                {
                    if (bag == 0)
                    {
                        Console.WriteLine("Кол-во попыток исчерпано");
                        break;
                    }
                    var account = new Account(login, password);
                    bool OK = predicate(account);
                    if (OK)
                    {
                        //вход
                        Console.WriteLine("Successfully");
                        break;
                    }
                    else
                    {
                        bag--;
                    }
                }
            }
           
           


        }
        // root, Password: GeekBrains
        static bool Check(Account obj)
        {
            return obj.Login == "root" && obj.Password == "GeekBrains" ? true : false;
        }
        /// <summary>
        /// С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        /// </summary>
        private static void Notzero()
        {
            Console.Write("Введите число: ");
            int summ = 0;
            while (true)
            {
                int n = int.Parse(Console.ReadLine());
                if (n != 0 && n % 2 == 1)
                {
                    summ += n;
                }
                else if (n == 0)
                {
                    break;
                }
                
            }
            Console.WriteLine("Summ: " + summ);
        }

        /// <summary>
        /// Написать метод подсчета количества цифр числа.
        /// </summary>
        private static void CountingNumber()
        {
            Console.Write("Введите число : ");

            while (true)
            {
                int n = int.Parse(Console.ReadLine()),
                count = 0;               
                if (n != 0)
                {
                    count++;
                    n /= 10;
                }
                else
                {
                    Console.WriteLine($"Кол-во цифр введенного числа: {count}");
                    break;
                }
            }

        }

        /// <summary>
        /// 1. Написать метод, возвращающий минимальное из трёх чисел.
        /// </summary>
        /// <returns></returns>
        private static int Min()
        {
            var kit =Enumerable.Range(0, 40);
            return kit.Min();
        }
    }
}
