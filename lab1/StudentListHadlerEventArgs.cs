using System;

namespace lab1
{
    class StudentListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string ChangedType { get; set; }
        public Student ChangedStudent { get; set; }
        public StudentListHandlerEventArgs(string collectionName, string changesType, Student changedObject)
        {
            CollectionName = collectionName;
            ChangedType = changesType;
            ChangedStudent = changedObject;
        }

        public override string ToString()
        {
            return ($"Collection name: {CollectionName}\nChanged type: {ChangedType}\nChanged object: {ChangedStudent}");
        }
    }
}