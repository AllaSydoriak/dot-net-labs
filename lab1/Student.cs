using System;

namespace lab1{
    public class Student{
        private Person _information;
        private Education _educationForm;
        private int _group;
        private Exam[] _exams;

        public Student (Person Information, Education EducationForm, int Group, Exam[] Exams){
            _information = Information;
            _educationForm = EducationForm;
            _group = Group;
            _exams = Exams;
        }

        public Student (){
            _information = new Person ();
            _educationForm = new Education ();
            _group = 1;
            Exam[] exams = new Exam[4];
            for (int i=0; i<4; i++)
            {
                exams[i] = new Exam();
            }
            _exams = exams;            
        }
        public Person Information{
            get => _information;
            set{
                _information = value;
            }
        }
        public Education EducationForm{
            get => _educationForm;
            set{
                _educationForm = value;
            }
        }
        public int Group{
            get => _group;
            set{
                _group = value;
            }
        }
        public Exam[] Exams{
            get => _exams;
            set{
                _exams = value;
            }
        }
        
        public double Avarage {
            get {
                double avg = 0;
                foreach (Exam item in Exams) {
                    avg += (1.0 / Exams.Length) * item.Mark;                
                }
                return avg;
            }            
        }

        public bool this[Education e]{
            get{
                return EducationForm == e;
            }
        }

        public void AddExams(params Exam[] NewExams){
            Exam[] NewList = new Exam[NewExams.Length + Exams.Length];

            int i = 0;
            foreach(Exam item in Exams)
            {
                NewList[i] = item;
                i++;
            }
           foreach(Exam item in NewExams)
            {
                NewList[i] = item;
                i++;
            }
            Exams = NewList;
        }

        public override string ToString(){
            string result = "Surname: " + _information.Surname + ", " +
                            "Name: " + _information.Name + ", " +
                            "Birth date: " + _information.Birthday.ToShortDateString() + ", " +
                            "Education form: " + EducationForm + ", " +
                            "Group: " + Group + ", " +
                            "Exams: ";
                foreach (Exam item in Exams)
                {
                    result = result + item.ToString() + ", ";        
                }
            return result;
        }

        public virtual string ToShortString(){
            return "Surname: " + _information.Surname + ", " +
                    "Name: " + _information.Name + ", " +
                    "Birth date: " + _information.Birthday + ", " +
                    "Education form: " + EducationForm + ", " +
                    "Group: " + Group + ", " +
                    "Avarage mark: " + Avarage;
        }

    }
}