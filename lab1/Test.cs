using System;

namespace lab1{
    public class Test{
        public string Subject {get; set;}
        public bool Result {get; set;}

        public Test(string subject, bool result )
        {
            Subject = subject;
            Result = result;
        }
        public Test()
        {
            Subject = "Math";
            Result = true;
        }

        public override string ToString(){
            return "Subject: " + Subject + ", Passed: " + Result; 
        }

        public object DeepCopy() => (Test) this.MemberwiseClone();
    }
}