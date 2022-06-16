using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons_Basics.Lesson4
{
    internal class Sample04
    {
        //4. Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
        //5 а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор,
        //заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива,
        //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство,
        //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива
        //(через параметры, используя модификатор ref или out).

        /// <summary>
        /// внутренний класс
        /// </summary>
        struct Account
        {
            public string Login;
            public string Password;
        }

        public void Main()
        {
            Console.WriteLine("Выбрать задания 4,5 или  6- если хотите выйти из программы");
            while (true)
            {
                var temp = Console.ReadLine();
                int count = 0;
                int.TryParse(temp, out count);
                if (count != 0)
                {
                    switch (count)
                    {
                        case 4:
                            ReadFileToString();
                            break;
                        case 5:
                            TwoDimensionalArray();
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
        /// метод паблик поэтому,можно перенестив в отдельную dll
        /// </summary>
        private void TwoDimensionalArray()
        {
            var Matrix =new TwoDimensionalArrays(1,2,3);
            Console.WriteLine($"Общая сумма: {Matrix.Sum}");
            Console.WriteLine($"Не меньше заданного:  {Matrix.SumArrayGreater(30)}");
            Console.WriteLine($"Мин элемент:  {Matrix.Min}");
            Console.WriteLine($"Мах элемент:  {Matrix.Max}");
            Console.WriteLine($"Средний :  {Matrix.Average}");
            Console.Write("Nомер максимального элемента массива:");
            Matrix.MaxArrayNumber(out string num);
            Console.WriteLine($"{num}");
            Console.ReadLine();
        }

        private void ReadFileToString()
        {
            var Puth = "Account.json";

            while (true)
            {
                if (File.Exists(Puth))
                {
                    try
                    {
                        using (StreamReader file = File.OpenText(Puth))
                        {
                            JsonSerializer serializer = new JsonSerializer();
                            var NewAccount = (Account)serializer.Deserialize(file, typeof(Account));
                            Console.WriteLine($"Login :{NewAccount.Login} Pass: {NewAccount.Password}");

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Не удалось прочитать: {ex.Message}");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Имя Фамилия через пробел");
                    var full = Console.ReadLine().Split(' ');
                    if (full is not null && full.Length == 2)
                    {
                        Account account = new()
                        {
                            Login = full[0],
                            Password = full[1],
                        };
                        File.WriteAllText(Puth, JsonConvert.SerializeObject(account));
                        Console.WriteLine("Считали из  файла");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
