using System;


namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection sc1 = new StudentCollection("Student collection #1");
            StudentCollection sc2 = new StudentCollection("Student collection #2");
            
            Journal j1 = new Journal();
            Journal j2 = new Journal();

            sc1.StudentCountChanged += j1.OnStudentCountChanged;
            sc1.StudentReferenceChanged += j1.OnStudentReferenceChanged;

            sc1.StudentCountChanged += j2.OnStudentCountChanged;
            sc2.StudentCountChanged += j2.OnStudentCountChanged;
            sc1.StudentReferenceChanged += j2.OnStudentReferenceChanged;
            sc2.StudentReferenceChanged += j2.OnStudentReferenceChanged;

            sc1.AddDefaults();           
            sc2.AddDefaults();

            sc1.Remove(2);            
            sc2.Remove(1);


            Student student = new Student();
            sc1[1] = student;
            student = new Student();
            sc2[0] = student;


            Console.WriteLine(j1 + "\n\n");
            Console.WriteLine(j2 + "\n\n");

        }
    }
}
