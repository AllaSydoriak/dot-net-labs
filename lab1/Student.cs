using System;
using System.Text;

namespace lab1{
    public class Student{
        private Person _information;
        private Education _educationForm;
        private int _group;
        private Exam[] _exams;

        public Student (Person information, Education educationForm, int group, Exam[] exams)
        {
            Information = information;
            EducationForm = educationForm;
            Group = group;
            Exams = exams;
        }

        public Student ()
        {
            Information = new Person ();
            EducationForm = new Education ();
            Group = 1;
            // Exam[] exams = { new Exam(), };
            Exam[] exams = new Exam[4];
            for (int i=0; i<4; i++)
            {
                exams[i] = new Exam();
            }
            Exams = exams;            
        }
        public Person Information
        {
            get => _information;
            set{ _information = value; }
        }
        public Education EducationForm
        {
            get => _educationForm;
            set{ _educationForm = value; }
        }
        public int Group{
            get => _group;
            set{  _group = value; }
        }
        public Exam[] Exams{
            get => _exams;
            set{ _exams = value; }
        }
        
        public double Avarage 
        {
            get 
            {
                double avg = 0;
                if (Exams == null || Exams.Length == 0) return 0;
                foreach (Exam item in Exams) {
                    avg += item.Mark;                
                }
                return avg / Exams.Length;
            }            
        }

        public bool this[Education e]
        {
            get
            {
                return EducationForm == e;
            }
        }

        public void AddExams(params Exam[] newExams)
        {
            if (newExams == null || newExams.Length == 0) return;
            Exam[] newList = new Exam[newExams.Length + (Exams == null ? 0: Exams.Length)];

            int i = 0;
            if (Exams != null)
            {
            foreach(Exam item in Exams)
            {
                newList[i] = item;
                i++;
            }
            }
           foreach(Exam item in newExams)
            {
                newList[i] = item;
                i++;
            }
            Exams = newList;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Surname: " + Information.Surname + ", " +
                            "Name: " + Information.Name + ", " +
                            "Birth date: " + Information.Birthday.ToShortDateString() + ", " +
                            "Education form: " + EducationForm + ", " +
                            "Group: " + Group + ", " +
                            "Exams: ");
                foreach (Exam item in Exams)
                {
                    sb.Append(item.ToString() + " ");        
                }
            return sb.ToString();
        }

        public virtual string ToShortString()
        {
            return "Surname: " + Information.Surname + ", " +
                    "Name: " + Information.Name + ", " +
                    "Birth date: " + Information.Birthday + ", " +
                    "Education form: " + EducationForm + ", " +
                    "Group: " + Group + ", " +
                    "Avarage mark: " + Avarage;
        }

        public bool ExamsEquals(Exam[] arr1, Exam[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;
            for(int i = 0; i < arr1.Length; i++)
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

            else return( (Information.Name == studObj.Information.Name)
                    && (Information.Surname == studObj.Information.Surname)
                    && (Information.Birthday == studObj.Information.Birthday)
                    && (EducationForm == studObj.EducationForm) 
                    && (Group == studObj.Group) 
                    && ExamsEquals(Exams, studObj.Exams));
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
                hash = hash + (Object.ReferenceEquals(null, Information.Name)? 
                        0 : Information.Name.GetHashCode());
                hash = hash + (Object.ReferenceEquals(null, Information.Surname)? 
                        0 : Information.Surname.GetHashCode());
                hash = hash + (Object.ReferenceEquals(null, Information.Birthday)? 
                        0 : Information.Birthday.GetHashCode());
                hash = hash + (Object.ReferenceEquals(null, EducationForm)?
                        0 : EducationForm.GetHashCode());
                hash = hash + (Object.ReferenceEquals(null, Group)?
                        0 : Group.GetHashCode());
                hash = hash + (Object.ReferenceEquals(null, Exams)?
                        0 : Exams.GetHashCode());
                return hash;
        }



    }
}