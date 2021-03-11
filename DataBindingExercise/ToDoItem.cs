using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace DataBindingExercise
{
    /// <summary>
    /// Represents a single item in a collection of ToDos
    /// </summary>
    public class ToDoItem : INotifyPropertyChanged
    {
        /// <summary>
        /// An Event fired when a property of this object changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private string task = "";
        /// <summary>
        /// The task this ToDoItem embodies
        /// </summary>
        public string Task {
        
            get { return task; }
            set
            {
                if (task != value)
                {
                    task = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Task"));
                }
            }
        }

        private bool complete = false;
        /// <summary>
        /// Indicates if this task has been completed
        /// </summary>
        public bool Complete {

            get { return complete; }
            set
            {
                if(complete != value)
                {
                    complete = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Complete"));
                }
            }
        }

        /// <summary>
        /// Constructs a new instance of ToDoItem with the supplied <paramref name="task"/>
        /// </summary>
        /// <param name="task"></param>
        public ToDoItem(string task)
        {
            Task = task;
        }

        /// <summary>
        /// Displays the ToDoItem as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string status = Complete ? "Complete" : "Incomplete";
            return $"{Task} - {status}";
        }
    }
}
