using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = new FileStream(@"C:\test\php.txt", FileMode.Open, FileAccess.Read);  //path that i want to read
            StreamReader w = new StreamReader(f);
                string s = w.ReadToEnd();
            Console.WriteLine(s);   //reading the file
            w.Close();
            f.Close();
        }
    }
}
