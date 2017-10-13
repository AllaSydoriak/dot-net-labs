﻿using System;


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
            
            Console.WriteLine(ob.ToString());
            Console.WriteLine(ob.ToShortString());

            Console.WriteLine(ob[Education.Master]);
            Console.WriteLine(ob[Education.Bachelor]);
            Console.WriteLine(ob[Education.SecondEducation]);
            
            ob.Information.Name = "Alla";
            ob.Information.Surname = "Sydoriak";
            ob.Information.Birthday = new DateTime(1997, 06, 23);
            ob.EducationForm = Education.Bachelor;
            ob.Group = 401;
            ob.Exams = new Exam[2];
            ob.Exams[0] = new Exam("DataBase", 5, new DateTime(2017, 06, 24));
            ob.Exams[1] = new Exam("Excel", 4, new DateTime(2017, 06, 13));

            Exam[] NewExams = new Exam[2];
            NewExams[0] = new Exam("PHP", 5, new DateTime(2016, 12, 25));
            NewExams[1] = new Exam("Probability Theory", 5, new DateTime(2017, 06, 18));
            
            ob.AddExams(NewExams);

            Console.WriteLine(ob.ToString());

            // Console.WriteLine("Input the number of rows and columns. Separate them with one of the separators: ' ', ',', '.' ");
            // string userLine = Console.ReadLine();
            // string[] result = userLine.Split(new Char [] {' ', ',', '.' });
            
            // int nRows = Int32.Parse(result[0]);
            // int mColumns = Int32.Parse(result[1]);

            // Console.WriteLine(nRows);
            // Console.WriteLine(mColumns);

            // int mult = nRows*mColumns;
            // /***** 1DimArray ******/
            // Person[] array1Dim = new Person[mult];
            // for (int i = 0; i < mult; i++){
            //     array1Dim[i] = new Person();
            // }

            // /***** 2DimArray ******/
            // Person[,] array2Dim = new Person[nRows, mColumns];
            // for (int i = 0; i < nRows; i++) {
            //     for (int j = 0; j < mColumns; j++) {
            //         array2Dim[i,j] = new Person();
            //     }
            // }
            // /***** arraySimpleJugged ******/
            // Person[][] arraySimpleJagged = new Person[nRows][];
            // for(int i = 0; i < nRows; i++){
            //     arraySimpleJagged[i] = new Person[mColumns];
            // }
            // for(int i = 0; i < nRows; i++){
            //     for(int j = 0; j < mColumns; j++){
            //         arraySimpleJagged[i][j] = new Person();
            //     }
            // }
            // /***** arrayJugged ******/
            // int jaggedRows = сountRows(mult);
            // int endRow = mult - ((jaggedRows - 1) * jaggedRows) / 2;  
            
            // int counter = 1;
            // Person[][] arrayJagged = new Person[jaggedRows][];
            // for (int i = 0; i < jaggedRows - 1; i++) {
            //     arrayJagged[i] = new Person[counter];
            //     counter++;
            // }
            // arrayJagged[jaggedRows - 1] = new Person[endRow];
            
            // counter = 1;
            //     for (int i = 0; i < jaggedRows; i++){
            //         for (int j = 0; j < counter; j++){
            //             if (i == (jaggedRows - 1)) {
            //                 for (int k = 0; k < endRow; k++) {
            //                     arrayJagged[i][k] = new Person();
            //                 }
            //                 break;
            //             }
            //             else {
            //                 arrayJagged[i][j] = new Person();
            //             }
            //         }
            //         counter++;
            //     }

            // long start1 = Environment.TickCount;
            // for (int i = 0; i < mult; i++)
            // {
            //     array1Dim[i].Name = "Alla";
            //     // Console.WriteLine(array1Dim[i].Name);
            // }
            // long end1 = Environment.TickCount;
            // Console.WriteLine("Time for 1Dim array:" + (end1 - start1));

            // long start2 = Environment.TickCount;
            // for (int i = 0; i < nRows; i++) {
            //     for (int j = 0; j < mColumns; j++) {
            //         array2Dim[i,j].Name = "Alla";
            //         //  Console.WriteLine(array2Dim[i,j].Name);
                    
            //     }
            // }
            // long end2 = Environment.TickCount;            
            // Console.WriteLine("Time for 2Dim array:" + (end2 - start2));
            
            // long start3 = Environment.TickCount;
            // for (int i = 0; i < nRows; i++) {
            //     for (int j = 0; j < mColumns; j++) {
            //         arraySimpleJagged[i][j].Name = "Alla";
            //         // Console.WriteLine(arraySimpleJugged[i][j].Name);
                    
            //     }
            // }
            // long end3 = Environment.TickCount;            
            // Console.WriteLine("Time for JuggedSimple array:" + (end3 - start3));

            // long start4 = Environment.TickCount;
            // for (int i = 0; i < jaggedRows - 1; i++){
            //     for (int j = 0; j < arrayJagged[i].Length; j++){
            //         arrayJagged[i][j].Name = "Alla";
            //     }

            // }
            // for (int i = 0; i < endRow; i++){
            //     arrayJagged[jaggedRows - 1][i].Name = "Alla";
            // }
            // long end4 = Environment.TickCount;            
            // Console.WriteLine("Time for JuggedSimple array:" + (end4 - start4));
            
        }
    }
}
