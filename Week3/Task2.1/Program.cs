using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task2._1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\test");
            FileSystemInfo[] arr = d.GetFileSystemInfos();   //created massive
            foreach (FileSystemInfo i in arr)
            {
                Console.WriteLine(i);    //outputting the containing directories and files
            }
        }
    }
}
