using System;
using System.Collections.Generic;

namespace lab1
{
    public class Person : IDateAndCopy, IEquatable<Person>, IComparable, IComparer<Person>
    {
            protected string _name;
            protected string _surname;
            protected DateTime _birthday;
            public DateTime Date {get; set;}
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
                Birthday = new DateTime(1997, 06, 23, 0, 0, 0);
            }
            public string Name
            {
                get => _name;
                set => _name = value;
            }

            public string Surname
            {
                get => _surname;
                set => _surname = value; 
            }
            public DateTime Birthday
            {
                get => _birthday;
                set => _birthday = value; 
            }
            public int birthYear
            {
                get => _birthday.Year;

                set => _birthday = new DateTime(value, _birthday.Month,_birthday.Day);               
            }

            public override string ToString()
            {
                return Surname + " " + Name + " " + Birthday;
            }

            public virtual string ToShortString()
            {
                return Surname + " " + Name;
            }

            public override bool Equals(object obj){

                if (obj == null)
                {
                    return false;
                }

                Person personObj = obj as Person;
                
                if((object)personObj == null){
                    return false;
                }
                
                return (Name == personObj.Name) 
                    && (Surname == personObj.Surname) 
                    && (Birthday == personObj.Birthday);
            }

            public bool Equals(Person person)
            {
                if (person == null)
                {
                    return false;
                }
                
                return (Name == person.Name) 
                    && (Surname == person.Surname) 
                    && (Birthday == person.Birthday);
                
            }

            public static bool operator ==(Person ob1, Person ob2)
            {
                if ((object)ob1 == null || (object)ob2 == null)
                {
                    return false;
                }

                return ob1.Equals(ob2);
            }

            public static bool operator !=(Person ob1, Person ob2)
            {
                return !(ob1 == ob2);
            }

            public override int GetHashCode()
            {
                int hash = 0;
                hash = hash + 7 * (Object.ReferenceEquals(null, Name)? 0 : Name.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Surname)? 0 : Surname.GetHashCode());
                hash = hash + 7 * (Object.ReferenceEquals(null, Birthday)? 0 : Birthday.GetHashCode());
                return hash;
            }

            public virtual object DeepCopy() => (Person) this.MemberwiseClone();

            public int CompareTo(object obj)
            {
                if (obj == null)
                    return 1;

                Person person = obj as Person;

                if (person != null)
                {
                    return this.Surname.CompareTo(person.Surname);
                }
                else
                {
                    throw new ArgumentException("Object is not a Person");
                }
            }

            public int Compare(Person obj1, Person obj2)
            {
                return obj1.Birthday.CompareTo(obj2.Birthday);
            }

        }
}
