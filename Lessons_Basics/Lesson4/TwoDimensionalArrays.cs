using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

namespace Lessons_Basics.Lesson4
{
    static class TwoDimensArrayExtension
    {
        public static int[,] TwoDimensionalArray(this IEnumerable<IEnumerable<int>> mas)
        {
            var arr = mas.Select(x => x.ToArray()).ToArray();
            var res = new int[arr.Length, arr.Max(x => x.Length)];
            for (var i = 0; i < arr.Length; ++i)
            {
                for (var j = 0; j < arr[i].Length; ++j)
                {
                    res[i, j] = arr[i][j];
                }
            }
            return res;
        }
        public static string IndexOFTwoArray(this int[,] array, int value)
        {
            int width = array.GetLength(0); // width
            int height = array.GetLength(1); // height
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    var num =array[x, y];
                    if (num == value )
                        return $"x: {x}: y: {y}";
                }
            }

            return null;
        }
    }


    //5 а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор,
    //заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива,
    //сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство,
    //возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива
    //(через параметры, используя модификатор ref или out).
    //*б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    //**в) Обработать возможные исключительные ситуации при работе с файлами.


    public class TwoDimensionalArrays
    {
        
        int[,] TwoArray;
        int to;
        int from;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n" >размернсть массива</param>
        /// <param name="min">диапозон от</param>
        /// <param name="max">до</param>
        public TwoDimensionalArrays(int n, int to, int from)
        {
            var e = Enumerable.Range(to, from).ToArray();//.Select(i =>
            var r = new Random();
            TwoArray = Enumerable.Range(to, from).
                Select(l => Enumerable.Range(to, from).
                Select(columnIndex => r.Next(0,1000))).TwoDimensionalArray();
        }

        internal void MaxArrayNumber(out string num)
        {
            int max =TwoArray.Cast<int>().Max();
            num =TwoArray.IndexOFTwoArray(max);
            num = num is not null ? num : "Index error";
        }
        public int Max { get { return TwoArray.Cast<int>().Max(); } }
        public int Min { get { return TwoArray.Cast<int>().Min(); } }
        public double Average { get { return TwoArray.Cast<int>().Average(); } }
        /// <summary>
        /// которые возвращают сумму всех элементов массива
        /// </summary>
        /// <returns></returns>
        /// 
        public double Sum { get {return TwoArray.Cast<int>().Sum(); }  }


        /// <summary>
        /// сумму всех элементов массива больше заданного
        /// </summary>
        /// <param name="min"></param>
        /// <returns></returns>     
        public int SumArrayGreater(int min)
        {

            return TwoArray.Cast<int>().Where(x=> x> min).Sum();
        }
    }

}
