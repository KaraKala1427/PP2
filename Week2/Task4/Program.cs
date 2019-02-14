using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream f = new FileStream(@"C:\test\test22\copy.txt", FileMode.Create)) { }   //created file
            File.Copy(@"C:\test\test22\copy.txt", @"C:\test\test22\get\copy.txt", true);   //copying it to another directory
            File.Delete(@"C:\test\test22\copy.txt");   //deleting it from his directory

        }
    }
}
