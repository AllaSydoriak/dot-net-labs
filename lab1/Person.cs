using System;

namespace lab1{
    public class Person{
            private string _name;
            private string _surname;
            private DateTime _birthday;
            public Person(string firstName, string lastName, DateTime birth)
            {
                Name = firstName;
                Surname = lastName;
                Birthday = birth;
            }
            public Person()
            {
                Name = "Ivan";
                Surname = "Ivanov";
                Birthday = default(DateTime);
            }
            public string Name
            {
                get => _name;
                set{
                    _name = value;
                }
            }

            public string Surname
            {
                get => _surname;
                set{ _surname = value; }
            }
            public DateTime Birthday
            {
                get => _birthday;
                set{ _birthday = value; }
            }
            public int birthYear
            {
                get => _birthday.Year;

                 set{ _birthday = new DateTime(value, _birthday.Month,_birthday.Day); }
                
            }

            public override string ToString()
            {
                return Surname + " " + Name + " " + Birthday;
            }

            public virtual string ToShortString()
            {
                return Surname + " " + Name;
            }

        }
}
