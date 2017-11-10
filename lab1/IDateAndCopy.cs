using System;

namespace lab1{
    interface IDateAndCopy{
        DateTime Date {get; set;}

        object DeepCopy();
    }
}