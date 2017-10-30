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

            Student ob = new Student();
            Student ob1 = new Student();

            Console.WriteLine(ob==ob1);
            
            
        }
    }
}
