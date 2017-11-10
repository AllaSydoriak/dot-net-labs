using System;


namespace lab1
{
    
    class Program
    {
        public static int сountRows(int mult)
        {
            int rows = 0;
            int countInRow = 0;
            int sum = 0;

            while (sum < mult)
            {
                countInRow += 1;
                sum += countInRow;
                rows++;
            }
            return rows;
        }

        static void Main(string[] args)
        {

            Student ob1 = new Student();
            Student ob2 = new Student();


            Exam exam = new Exam();
            Test test = new Test();
        

            ob1.AddExams(exam);
            ob1.AddTests(test);

            Person p2 = (Person)ob1.DeepCopy();

            ob1.AddExams(new Exam());
            Console.WriteLine(ob1.ToString());
            Console.WriteLine("-------");
            Console.WriteLine(p2.ToString());   

        }
    }
}
