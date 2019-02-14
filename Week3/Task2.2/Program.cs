using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\Users\Ernar\Documents\kaza"); //implyinf the path
            FileSystemInfo[] arr = d.GetFileSystemInfos();  //getting all directories and files from KAZA
            foreach(FileSystemInfo x in arr)
            {
                x.Delete();   //deleting
            }
        }
    }
}
