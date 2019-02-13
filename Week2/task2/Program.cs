using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace task2
{
    class Program
    {
        public static int[] F(string s)
        {
            string[] str = s.Split();
            int[] b = new int[str.Length];
            for(int i=0;i<str.Length;++i)
            {
                b[i]= int.Parse(str[i]);

                
            }
            return b;
        }
         public static bool F2(int b)
        {
            if (b == 1) return false;
            for(int i = 2; i < b; ++i)
            {
                if (b % i == 0) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\test\prime.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            int[] arr = F(line); //calling the function that making integer from string
            sr.Close();
            fs.Close();

            FileStream fw = new FileStream(@"C:\test\prime1.txt", FileMode.Open, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fw);
            foreach(int n in arr)
            {
                if (F2(n))   //taking only prime numbers by function F2
                    sw.Write(n + " ");  //output of result
            }
            sw.Close();
            fw.Close();
        }
    }
}
