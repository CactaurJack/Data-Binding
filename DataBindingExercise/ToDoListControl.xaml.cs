using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBindingExercise
{
    /// <summary>
    /// Interaction logic for ToDoListControl.xaml
    /// </summary>
    public partial class ToDoListControl : UserControl
    {
        /// <summary>
        /// Creates a new ToDoListControl
        /// </summary>
        public ToDoListControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds a task to the ToDoList
        /// </summary>
        /// <param name="sender">The button that sent the event</param>
        /// <param name="e">The event args</param>
        void OnAddTaskClick(object sender, RoutedEventArgs e)
        {
            var task = new ToDoItem(newTaskTextBox.Text);
            taskListView.Items.Add(task);
            newTaskTextBox.Clear();
        }
    }
}
