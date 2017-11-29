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
            StudentCollection collection = new StudentCollection();
            collection.AddDefaults();
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by surname: \n");
            collection.SortBySurname();
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by birthday: \n");
            collection.SortByBirthday();
            Console.WriteLine(collection.ToString());

            Console.WriteLine("Sorted by avarage mark: \n");
            collection.SortByAvgMark();
            Console.WriteLine(collection.ToShortString());

            Console.WriteLine("Max avarage mark: \n");
            Console.WriteLine(collection.GetMaxAvgMark);

            Console.WriteLine("Education form Master: \n");
            Console.WriteLine(collection.GetMaster);

            TestCollections test = new TestCollections();
            test.TestCollection(15000);
            test.GetTime();

        }
    }
}
