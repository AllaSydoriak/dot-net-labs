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
            Exam[] exams = { new Exam(), };
            // Exam[] exams = new Exam[4];
            // for (int i=0; i<4; i++)
            // {
            //     exams[i] = new Exam();
            // }
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

        public override string ToString(){
            StringBuilder sb = new StringBuilder();
            sb.Append("Surname: " + Information.Surname + ", " +
                            "Name: " + _information.Name + ", " +
                            "Birth date: " + _information.Birthday.ToShortDateString() + ", " +
                            "Education form: " + EducationForm + ", " +
                            "Group: " + Group + ", " +
                            "Exams: ");
                foreach (Exam item in Exams)
                {
                    sb.Append(item.ToString() + " ");        
                }
            return sb.ToString();
        }

        public virtual string ToShortString(){
            return "Surname: " + Information.Surname + ", " +
                    "Name: " + _information.Name + ", " +
                    "Birth date: " + _information.Birthday + ", " +
                    "Education form: " + EducationForm + ", " +
                    "Group: " + Group + ", " +
                    "Avarage mark: " + Avarage;
        }

    }
}