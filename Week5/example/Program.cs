using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Example1
{
    public class Student
    {
        public string name;
        public string gpa;
        public Student()
        {
            name = "AAA";
            gpa = "3.52";
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            F2();
        }
        private static void F2()
        {
            FileStream fs = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            Student t = xs.Deserialize(fs) as Student;
            fs.Close();
            
        }
        private static void F1()
        {
            Student s = new Student();
            FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            xs.Serialize(fs, s);
            fs.Close();
        }
    }
}
