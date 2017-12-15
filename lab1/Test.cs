using System;
using System.Runtime.Serialization;

namespace lab1
{
    [DataContract]
    public class Test
    {
        [DataMember] public string Subject {get; set;}
        [DataMember] public bool Result {get; set;}

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