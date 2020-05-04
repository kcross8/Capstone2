using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone2
{
    class Task
    {
        //fields
        private string memberName;
        private DateTime dueDate;
        private bool completed;
        private string description;

        //properties
        public string MemberName
        {
            get
            {
                return memberName;
            }
            set
            {
                memberName = value;
            }
        }
        public DateTime DueDate
        {
            get
            {
                return dueDate;
            }
            set
            {
                dueDate = value;
            }
        }
        public bool Completed
        {
            get
            {
                return completed;
            }
            set
            {
                completed = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        //constructors
        public Task(string _memberName, DateTime _dueDate, bool _completed, string _description)
        {
            memberName = _memberName;
            dueDate = _dueDate;
            completed = _completed;
            description = _description;
        }
        public Task() //default
        {
        }        
            
    }
}
