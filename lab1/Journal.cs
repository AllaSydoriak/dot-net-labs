using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    class Journal
    {
        private List<JournalEntry> _journalList;

        public Journal()
        {
            JournalList = new List<JournalEntry>();
        }

        public List<JournalEntry> JournalList
        {
            get => _journalList;
            set => _journalList = value; 
        }

        public void OnStudentCountChanged(object source, StudentListHandlerEventArgs args)
        {
            JournalList.Add(new JournalEntry(args));
        }

        public void OnStudentReferenceChanged(object source, StudentListHandlerEventArgs args)
        {
            JournalList.Add(new JournalEntry(args));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("================================\n");
            sb.Append("Journal list:\n");

            if(JournalList == null || JournalList.Count == 0)
            {
                sb.Append("No changes yet\n");
            }
            else
            {
                foreach (JournalEntry item in JournalList)
                {
                    sb.Append("***************\n");
                    sb.Append(item.ToString() + " \n");
                }
            }

            return sb.ToString();
        }
    }
}