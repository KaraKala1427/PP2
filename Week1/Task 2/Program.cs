using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student //creating class
    {
        public string name;
        public string id;            //variables of the class
        public int yearofstudy;

        public Student(string name, string id)    //constructor with two parametr
        {
            this.name = name;
            this.id = id;
            PrintInfo();   //calling the method
        }
        public void PrintInfo()
        {
            Console.WriteLine(name+ "  " +id+"  " + 1);  //method that outputs the data of student
            Console.WriteLine(name + "  " + id + "  " + 2);

        }
        public int Incremented(int a)    //method that increment year of student
        {
            yearofstudy = a;
            return yearofstudy + 1;
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your id: ");        //inputting the data of student
            string id = Console.ReadLine();
           
            //string year = Console.ReadLine();
            //int number = int.Parse(year);
            Student student = new Student(name,id);   //constructor
            //Console.WriteLine("incremented year of the student: "+student.Incremented(number));
            
          
        }
    }
}
