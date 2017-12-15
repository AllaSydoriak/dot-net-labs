using System;


namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Student s1 = new Student();
            s1.AddExams(new Exam());
            s1.AddTests(new Test());
            s1.AddExamFromConsole();
            Console.WriteLine(s1.ToString());
            Student s2 = (Student)s1.DeepCopy();
            Console.WriteLine(s2.ToString());
            Student s3 = new Student();
            s3.Load("student.json");
            Console.WriteLine(s3.ToString());
            s1.AddExamFromConsole();
            s1.Save("student.json");  
            Console.WriteLine(s1);
            
            
        }
    }
}
