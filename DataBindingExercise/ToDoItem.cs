using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBindingExercise
{
    /// <summary>
    /// Represents a single item in a collection of ToDos
    /// </summary>
    public class ToDoItem
    {
        /// <summary>
        /// The task this ToDoItem embodies
        /// </summary>
        public string Task { get; set; }

        /// <summary>
        /// Indicates if this task has been completed
        /// </summary>
        public bool Complete { get; set; }

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
