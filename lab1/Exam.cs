using System;

namespace lab1{
    public class Exam{
        public string Subject {get; set;}
        public int Mark {get; set;}
        public DateTime Time {get; set;}
        public Exam (string subject, int mark, DateTime time)
        {
            Subject = subject;
            Mark = mark;
            Time = time;
        }
        public Exam()
        {
            Subject = "Math";
            Mark = 5;
            Time = DateTime.Now;
        }
        public override string ToString()
        {
                return "Subject: " + Subject + ", " + "Mark: " + Mark 
                + ", " + "Time: " + Time.ToShortDateString();
        }
    }
}