using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace lab1
{
    [DataContract]
    public class Student : Person, IDateAndCopy
    {
        [DataMember] private Education _educationForm;
        [DataMember] private int _group;
        [DataMember] private List<Exam> _exams;
        [DataMember] private List<Test> _tests;

        public Student (String name, String surname, DateTime birthday, Education educationForm, 
            int group, List<Exam> exams, List<Test> tests) : base(name, surname, birthday)
        {
            EducationForm = educationForm;
            Group = group;
            Exams = exams;
            Tests = tests;
        }

        public Student () : base ()
        {
            EducationForm = new Education ();
            Group = 1;
            Exams = new List<Exam>(); 
            Tests = new List<Test>();        
        }

        public Education EducationForm
        {
            get => _educationForm;
            set => _educationForm = value; 
        }
        public int Group
        {
            get => _group;
            set =>  _group = value; 
        }

        public int GroupValue
        {
            get => _group;
            set {
                if (value <= 100 || value > 699)
                {
                    throw new SystemException("Value should be less more 100 and less than 699");
                }
                _group = value;
            }
        }
        public List<Exam> Exams
        {
            get => _exams;
            set => _exams = value; 
        }

        public List<Test> Tests
        {
            get => _tests;
            set => _tests = value; 
        }
        
        public Person PersonValue
        {
            get => new Person(Name, Surname, Birthday);

            set
            {
                Name = value.Name;
                Surname = value.Surname;
                Birthday = value.Birthday;
            }
        }

        public double Avarage 
        {
            get 
            {
                double avg = 0;
                if (Exams == null || Exams.Count == 0) return 0;
                foreach (Exam item in Exams) {
                    avg += item.Mark;                
                }
                return avg / Exams.Count;
            }            
        }

        public bool this[Education e]
        {
            get => EducationForm == e;
        }

        public void AddExams(params Exam[] newExams)
        {
            if (newExams == null || newExams.Length == 0) return;

            foreach(Exam item in newExams)
            {
                Exams.Add(item);
            }

        }

        public void AddTests(params Test[] newTests)
        {
            if (newTests == null || newTests.Length == 0) return;

            foreach(Test item in newTests)
            {
                Tests.Add(item);
            }

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Surname: " + Surname + ", " +
                            "Name: " + Name + ", " +
                            "Birth date: " + Birthday.ToShortDateString() + ", " +
                            "Education form: " + EducationForm + ", " +
                            "Group: " + Group + ", " +
                            "Exams: ");
            foreach (Exam item in Exams)
            {
                sb.Append(item.ToString() + "; ");        
            }

            sb.Append("Tests: ");
            
            foreach (Test item in Tests)
            {
                sb.Append(item.ToString() + " ");
            }

            return sb.ToString();
        }

        public override string ToShortString()
        {
            return "Surname: " + Surname + ", " +
                    "Name: " + Name + ", " +
                    "Birth date: " + Birthday + ", " +
                    "Education form: " + EducationForm + ", " +
                    "Group: " + Group + ", " +
                    "Avarage mark: " + Avarage;
        }

        public bool ExamsEquals(ArrayList arr1, ArrayList arr2)
        {
            if (arr1.Count != arr2.Count) return false;
            for(int i = 0; i < arr1.Count; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        {

            if (obj == null)
            {
                return false;
            }

            Student studObj = obj as Student;
                
            if((object)studObj == null)
            {
                return false;
            }

            else return( (Name == studObj.Name)
                    && (Surname == studObj.Surname)
                    && (Birthday == studObj.Birthday)
                    && (EducationForm == studObj.EducationForm) 
                    && (Group == studObj.Group) 
                    && (Exams == studObj.Exams)
                    && (Tests == studObj.Tests));
        }

        public static bool operator ==(Student ob1, Student ob2)
        {
            if ((object)ob1 == null || (object)ob2 == null)
                {
                    return false;
                }
            return ob1.Equals(ob2);
        }

        public static bool operator !=(Student ob1, Student ob2)
        {
            return !(ob1 == ob2);
        }

        public override int GetHashCode()
        {
            int hash = 0;
                hash = hash + 7 * (Object.ReferenceEquals(null, Name)? 
                        0 : Name.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Surname)? 
                        0 : Surname.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Birthday)? 
                        0 : Birthday.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, EducationForm)?
                        0 : EducationForm.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Group)?
                        0 : Group.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Exams)?
                        0 : Exams.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Tests)?
                        0 : Tests.GetHashCode());
                return hash;
        }

        public override object DeepCopy()
        {
            Student newStudent = (Student) this.MemberwiseClone();

            List<Exam> examList = new List<Exam>();
            List<Test> testList = new List<Test>();

            foreach (Exam item in Exams)
            {
                examList.Add((Exam)item.DeepCopy());
            }
            foreach (Test item in Tests)
            {
                testList.Add((Test)item.DeepCopy());
            }
            newStudent.Exams = examList;
            newStudent.Tests = testList;

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Student));
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                jsonSerializer.WriteObject(memoryStream, newStudent);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (Student)jsonSerializer.ReadObject(memoryStream);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return null;
            }            
            finally
            {
                memoryStream.Close();
            }
        }

        public IEnumerable ExamsAndTests()
        {
            foreach(Exam item in Exams)
            {
                yield return item;
            }
            foreach(Test item in Tests)
            {
                yield return item;
            }
        }

        public IEnumerable ExamsMoreThan(int mark){
            foreach (Exam item in Exams)
            {
                if(item.Mark > mark) yield return item.Mark;
            }
        }

        public bool Save(string filename)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Student));
            
            if (File.Exists(@filename))
            {
                File.Delete(@filename);
            }

            FileStream buffer = File.Create(@filename); 

            try
            {
                jsonSerializer.WriteObject(buffer, this);
                Console.WriteLine("File saved");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return false;
            }
            finally
            {
                buffer.Close(); 
            }
            return true;
        }

        public bool Load(string filename)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Student));
            FileStream buffer = File.OpenRead(@filename);
            try
            {
                Student student = jsonSerializer.ReadObject(buffer) as Student;
                if(student != null)
                {
                    this.Name = student.Name;
                    this.Surname = student.Surname;
                    this.Birthday = student.Birthday;
                    this.EducationForm = student.EducationForm;
                    this.Group = student.Group;
                    this.Exams = student.Exams;
                    this.Tests = student.Tests;
                    Console.WriteLine("Object saved"); 
                }         
                return true;                        
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return false;
            }
            finally
            {
                buffer.Close(); 
            }
        }

        public static bool Save(string fileName, Student student)
        {
            return student.Save(fileName);
        }

        public static bool Load(string fileName, Student student)
        {
            return student.Load(fileName);
        }
        public bool AddExamFromConsole()
        {
            Console.WriteLine("Input information about exam");
            Console.WriteLine("Separate it with ',' \n");
            Console.WriteLine("Information for exam: name, mark and date\n");
            
            string[] result = new string[]{};

            string userLine = Console.ReadLine();
            try
            {
                result = userLine.Split(',');
                
                if(result.Length != 3)
                    throw new Exception("You should input name and mark using delimiters");
                
                string name = result[0];
                int mark = Convert.ToInt32(result[1]);
                DateTime date = DateTime.Parse(result[2]);
                
                Exam exam = new Exam(name, mark, date);
                Exams.Add(exam);
                Console.WriteLine("Test succesfuly added!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Something going wrong");                
                Console.WriteLine($"Errors: {e}");
                return false;
            }
            
            return true;
        }
    }
}

