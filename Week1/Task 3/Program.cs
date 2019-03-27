using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        public static void Duble(int x)
        {

            for (int j = 0; j < 2; ++j)//it is for repeating each element of the array
            {
                Console.Write(x + " ");//presenting the repeated elements that i need
            }
        }
        static void Main(string[] args)
        {
            string s = Console.ReadLine();//inputting the symbol, which will be size of array
            int n = int.Parse(s);//making the number from symbol s
            int[] a = new int[n];//creating an array
            for (int i = 0; i < n; ++i)
            {
                string ss = Console.ReadLine();//inputting the symbol,which will be elements of the array
                int b = int.Parse(ss);
                a[i] = b;
            }
            for (int i = 0; i < n; ++i)
            {
                Duble(a[i]);
                
            }
        }
    }
}
