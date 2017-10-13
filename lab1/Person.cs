using System;

namespace lab1{
    public class Person{
            private string _name;
            private string _surname;
            private DateTime _birthday;
            public Person(string firstName, string lastName, DateTime birth){
                _name = firstName;
                _surname = lastName;
                _birthday = birth;
            }
            public Person(){
                _name = "Ivan";
                _surname = "Ivanov";
                _birthday = default(DateTime);
            }
            public string Name{
                get => _name;
                set{
                    _name = value;
                }
            }
            public string Surname{
                get => _surname;
                set{
                    _surname = value;
                }
            }
            public DateTime Birthday{
                get => _birthday;
                set{
                    _birthday = value;
                }
            }
            public int birthYear{
                get => _birthday.Year;

                 set{
                     _birthday = new DateTime(value, _birthday.Month,_birthday.Day);
                 }
                
            }

            public override string ToString(){
                return _surname + " " + _name + " " + _birthday;
            }

            public virtual string ToShortString(){
                return _surname + " " + _name;
            }

        }
}
