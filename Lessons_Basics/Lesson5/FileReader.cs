using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons_Basics.Lesson5
{
    internal class FileReader : IDisposable 
    {
        string Path;
        StreamReader StreamReader;

        public int CountStudent { get; set; }



        public FileReader(string path)
        {
            Path = path;
            if (System.IO.File.Exists(path))
            {
                StreamReader = new StreamReader(path);
                return;
            }
            throw new Exception("error File.Exists");
        }
        public  IEnumerable<string>GetLine()
        {
            while (!StreamReader.EndOfStream)
            {
               var str = StreamReader.ReadLine();

                yield return str;
            }
            StreamReader.Close();
        }



        public void Dispose()
        {
            StreamReader.Dispose();
        }
    }
}
