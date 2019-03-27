using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weeek1
{
    class Program
    {
        public static bool Prime(int b)//функция которая проверяет на чисел простое оно или нет
        {
            if (b == 1) return false;
            for (int i = 2; i < b; ++i)
            {

                if (b % i == 0) return false;
            }
            return true;

        }

        static void Main(string[] args)
        {
            string d = Console.ReadLine();//ввожу как cin символ
            int n = int.Parse(d);// меняю на цифру

            int[] a = new int[n];//создаю массив 
            string s= Console.ReadLine();
            string [] ss= s.Split();
            int cnt = 0; // создаю счетчик который предназначен на количество простых чисел
            for (int i = 0; i < n; ++i)
            {
               
                a[i] = int.Parse(ss[i]);

            }
            for (int i = 0; i < n; ++i)
            {
                if (Prime(a[i]))//проверяя чисел на Prime(вызванная функция),количеств простых чисел возрастает если оно простое 
                {
                    cnt++;
                }
            }
            Console.WriteLine(cnt);// в итоге показываю количество простых чисел

            for (int i = 0; i < n; ++i)
            {
                if (Prime(a[i]))//проверяя элементы на Prime, вывожу их
                {
                    Console.Write(a[i] + " ");
                }
            }
 

        }
    }
}

