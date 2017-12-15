using System;
using System.Runtime.Serialization;

namespace lab1
{
    [DataContract]
    public class Exam : IDateAndCopy
    {
        [DataMember] public string Subject {get; set;}
        [DataMember] public int Mark {get; set;}
        [DataMember] public DateTime Time {get; set;}
        public DateTime Date {get; set;}
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
            Time = new DateTime(2017, 10, 30, 0, 0, 0);
        }
        public override string ToString()
        {
                return "Subject: " + Subject + ", " + "Mark: " + Mark 
                + ", " + "Time: " + Time.ToShortDateString();
        }

        public override bool Equals(object obj){

                if (obj == null)
                {
                    return false;
                }

                Exam examObj = obj as Exam;
                
                if((object)examObj == null)
                {
                    return false;
                }
                else return( (Subject == examObj.Subject) 
                    && (Mark == examObj.Mark) 
                    && (Time == examObj.Time) );
        }

        public static bool operator ==(Exam ob1, Exam ob2)
        {
             if ((object)ob1 == null || (object)ob2 == null)
                {
                    return false;
                }

                return ob1.Equals(ob2);
        }

        public static bool operator !=(Exam ob1, Exam ob2){

            return !(ob1 == ob2);
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash = hash + 7 * (Object.ReferenceEquals(null, Subject)? 0 : Subject.GetHashCode());
            hash = hash + 7 * (Object.ReferenceEquals(null, Mark)? 0 : Mark.GetHashCode());
            hash = hash + 7 * (Object.ReferenceEquals(null, Time)? 0 : Time.GetHashCode());
            return hash;
        }

        public object DeepCopy() => (Exam) this.MemberwiseClone();
    }
}