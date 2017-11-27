using System;
using System.Collections.Generic;

namespace lab1
{

    class TestCollections
    {
        private List<Person> _personList = new List<Person>();
        private List<string> _stringList = new List<string>();
        private Dictionary<Person, Student> _personStudDictionary = new Dictionary<Person, Student>();
        private Dictionary<string, Student> _stringStudDictionary = new Dictionary<string, Student>();
                        
        public static Student GenerateCollection(int n)
        {
            Student student = new Student("Ivan" + n.ToString(), "Ivanov" + n.ToString(), new DateTime(2000 + n, 01 , 01), (Education)(n < 3 ? n : n % 3), 400 + n, new List<Exam>(), new List<Test>());

            student.AddExams(new Exam());   
            student.AddTests(new Test());

            return student;
        }

        public List<Person> PersonList
        {
            get => _personList;
            set =>_personList = value;
        }

        public List<string> StringList
        {
            get => _stringList;
            set => _stringList = value;
        }

        public Dictionary<Person, Student> PersonStudDictionary
        {
            get => _personStudDictionary;
            set => _personStudDictionary = value;
        }

        public Dictionary<string, Student> StringStudDictionary
        {
            get => _stringStudDictionary;
            set => _stringStudDictionary = value;
        }

        public TestCollections(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Student student = GenerateCollection(i);

                PersonList.Add(student.PersonValue);
                StringList.Add(student.PersonValue.ToString());

                PersonStudDictionary.Add(student.PersonValue, student);
                StringStudDictionary.Add(student.PersonValue.ToString(), student);
            }
        }

        public void GetTime()
        {
            Console.WriteLine("\nFirst element:\n");

            Student studentToFind = GenerateCollection(0);
            string stringToFind = studentToFind.ToString();
            
            long startTime = Environment.TickCount;
            PersonList.Contains(studentToFind);
            Console.WriteLine("List<Person>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            StringList.Contains(stringToFind);
            Console.WriteLine("List<string>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsKey(studentToFind);
            Console.WriteLine("Dict<Person,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            StringStudDictionary.ContainsKey(stringToFind);
            Console.WriteLine("Dict<string,Student>: " + (Environment.TickCount - startTime));


            Console.WriteLine("\n\nMiddle element:\n");

            studentToFind = GenerateCollection(PersonList.Count / 2);

            startTime = Environment.TickCount;
            PersonList.Contains(studentToFind);
            Console.WriteLine("List<Person>: " + (Environment.TickCount - startTime));

            stringToFind = studentToFind.ToString();
            startTime = Environment.TickCount;
            StringList.Contains(stringToFind);
            Console.WriteLine("List<string>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsKey(studentToFind);
            Console.WriteLine("Dict<Person,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            StringStudDictionary.ContainsKey(stringToFind);
            Console.WriteLine("Dict<string,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsValue(studentToFind);
            Console.WriteLine("value at Dict<Person,Student>: " + (Environment.TickCount - startTime));


            Console.WriteLine("\n\nLast element:\n");
            studentToFind = GenerateCollection(PersonList.Count - 1);

            startTime = Environment.TickCount;
            PersonList.Contains(studentToFind);
            Console.WriteLine("List<Person>: " + (Environment.TickCount - startTime));

            stringToFind = studentToFind.ToString();
            startTime = Environment.TickCount;
            StringList.Contains(stringToFind);
            Console.WriteLine("List<string>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsKey(studentToFind);
            Console.WriteLine("Dict<Person,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            StringStudDictionary.ContainsKey(stringToFind);
            Console.WriteLine("Dict<string,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsValue(studentToFind);
            Console.WriteLine("value at Dict<Person,Student>: " + (Environment.TickCount - startTime));


            Console.WriteLine("\n\nNot existing element:\n");
            studentToFind = GenerateCollection(PersonList.Count);

            startTime = Environment.TickCount;
            PersonList.Contains(studentToFind);
            Console.WriteLine("List<Person>: " + (Environment.TickCount - startTime));

            stringToFind = studentToFind.ToString();
            startTime = Environment.TickCount;
            StringList.Contains(stringToFind);
            Console.WriteLine("List<string>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsKey(studentToFind);
            Console.WriteLine("Dict<Person,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            StringStudDictionary.ContainsKey(stringToFind);
            Console.WriteLine("Dict<string,Student>: " + (Environment.TickCount - startTime));

            startTime = Environment.TickCount;
            PersonStudDictionary.ContainsValue(studentToFind);
            Console.WriteLine("value at Dict<Person,Student>: " + (Environment.TickCount - startTime));

            Console.ReadKey();            
        }
    }
    

}