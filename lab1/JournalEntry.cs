using System;

namespace lab1
{
    class JournalEntry
    {
        public string CollectionName { get; set; }
        public string ChangedType { get; set; }
        public Student ChangedStudent { get; set; }
        public JournalEntry(string collectionName, string changesType, Student changedStudent)
        {
            CollectionName = collectionName;
            ChangedType = changesType;
            ChangedStudent = changedStudent;
        }

        public JournalEntry (StudentListHandlerEventArgs eventArgs) 
            : this (eventArgs.CollectionName,eventArgs.ChangedType,eventArgs.ChangedStudent)
        {
        }

        public override string ToString()
        {
            return ($"Collection name: {CollectionName}\nChanged type: {ChangedType}\nChanged object: {ChangedStudent}");
        }
    }
}