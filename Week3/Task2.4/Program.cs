using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo f = new FileInfo(@"C:\Users\Ernar\Documents\name1.txt");  //file
            f.MoveTo(@"C:\Users\Ernar\Documents\nameF.txt");   //renaming the file
            Directory.Move(@"C:\Users\Ernar\Documents\name1", @"C:\Users\Ernar\Documents\name2");   // renaming the directory
        }
    }
}
