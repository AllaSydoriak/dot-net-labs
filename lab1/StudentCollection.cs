using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace lab1
{

    class StudentCollection : StudentComparer
    {
        private List<Student> _studentList;

        public StudentCollection(){
            StudentList = new List<Student>();
        }

        public List<Student> StudentList
        {
            get => _studentList;
            set => _studentList = value; 
        }

        public void AddDefaults(int n)
        {
            Student newStudent = new Student();
            newStudent.AddExams(new Exam());
            newStudent.AddTests(new Test());

            for (int i = 0; i < n; i++)
            {
                AddStudents(newStudent);
            }
        }

        public void AddDefaults()
        {
            Student student1 = new Student("Olena", "Oliynyk", new DateTime(1997, 6, 23), 
                            Education.Bachelor, 401, new List<Exam>(), new List<Test>());
            student1.AddExams(new Exam("Math", 5, new DateTime(2017, 12, 2)), new Exam("Excel", 4, new DateTime(2017, 12, 15)), new Exam("History", 4, new DateTime(2017, 12, 28)));
            student1.AddTests(new Test("English", true), new Test("Operating Systems", true));
            AddStudents(student1);


            Student student2 = new Student("Andrew", "Melnyk", new DateTime(1997, 9, 13), 
                            Education.Bachelor, 401, new List<Exam>(), new List<Test>());

            student2.AddExams(new Exam("Physics", 5, new DateTime(2017, 12, 13)), new Exam("History", 4, new DateTime(2017, 12, 20)), new Exam("Math", 4, new DateTime(2017, 12, 27)));
            student2.AddTests(new Test("English", true), new Test("Excel", true));
            AddStudents(student2);


            Student student3 = new Student("Oleg", "Tkachenko", new DateTime(1996, 8, 10), 
                    Education.Bachelor, 401, new List<Exam>(), new List<Test>());

            student3.AddExams(new Exam("Math", 3, new DateTime(2017, 12, 2)), new Exam("History", 5, new DateTime(2017, 12, 18)), new Exam("Excel", 3, new DateTime(2017, 12, 13)));
            student3.AddTests(new Test("Physics", true), new Test("Chemistry", true));
            AddStudents(student3);

        }

        public void AddStudents(params Student[] students)
        {
            if(students == null || students.Length == 0)
            {
                return;
            }

            for (int i = 0; i < students.Length; i++)
            {
                 StudentList.Add(students[i]);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < StudentList.Count; i++)
            {
                sb.Append(StudentList[i].ToString() + "\n------------------------------\n");
            }

            return sb.ToString();
        }

        public string ToShortString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < StudentList.Count; i++)
            {
                sb.Append(StudentList[i].ToShortString());
                sb.Append($"\n Exams: {StudentList[i].Exams.Count}, ");
                sb.Append($"\n Tests: {StudentList[i].Tests.Count}, ");
                sb.Append("\n------------------------------\n");
            }

            return sb.ToString();
        }

        public void SortBySurname() => StudentList.Sort();

        public void SortByBirthday() => StudentList.Sort((Student ob1, Student ob2) 
                                        => ob1.PersonValue.Compare(ob1.PersonValue, ob2.PersonValue));

        public void SortByAvgMark() => StudentList.Sort(new StudentComparer());

        public double GetMaxAvgMark
        {
            get
            {
                if (StudentList == null || StudentList.Count == 0)
                    return 0;

                return StudentList.Max(student => student.Avarage);
            }

        }

        public IEnumerable<Student> GetMaster
        {
            get{
                if (StudentList == null || StudentList.Count == 0)
                    return new List<Student>();

                return StudentList.Where(student => student.EducationForm == Education.Master);
            }
        }

        public List<Student> StudentsAvgMark(double mark)
        {
            if (StudentList == null || StudentList.Count == 0)
                return new List<Student>();

            var studentGroups = StudentList.GroupBy(student => student.Avarage);

            foreach (IGrouping<double, Student> student in studentGroups)
            {
                if (student.Key == mark)
                    return student.ToList();
            }

            return new List<Student>();
        }

    }

}