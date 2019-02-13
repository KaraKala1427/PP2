using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Solve(string str)
        {
            bool ok = true;
            for (int i = 0; i < str.Length; ++i)
            {
                if (str[i] != str[str.Length - 1 - i])
                {
                    ok = false; break;
                }

            }
            if (ok)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static void Main(string[] args) {
            FileStream fs = new FileStream(@"C:\test\php.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadLine();
            Solve(line);
            sr.Close();
            fs.Close();
       
        }
    }
}
