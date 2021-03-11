using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace DataBindingExercise
{
    /// <summary>
    /// Class representing a ToDoList
    /// </summary>
    public class ToDoList : ObservableCollection<ToDoItem>
    {
        /// <summary>
        /// The number of complete tasks in this ToDoList
        /// </summary>
        public int CompleteCount
        {
            get
            {
                int numComplete = 0;
                foreach(ToDoItem item in this)
                {
                    if (item.Complete) numComplete++;
                }
                return numComplete;
            }
        }

        /// <summary>
        /// The number of incomplete tasks
        /// </summary>
        public int IncompleteCount
        {
            get
            {
                int numIncomplete = 0;
                foreach(ToDoItem item in this)
                {
                    if (!item.Complete) numIncomplete++;
                }
                return numIncomplete;
            }
        }


        public ToDoList()
        {
            CollectionChanged += CollectionChangedListner;
        }

        void CollectionChangedListner(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(new PropertyChangedEventArgs("CompleteCount"));
            OnPropertyChanged(new PropertyChangedEventArgs("IncompleteCount"));
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach(ToDoItem item in e.NewItems)
                    {
                        item.PropertyChanged += CollectionItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach(ToDoItem item in e.OldItems)
                    {
                        item.PropertyChanged -= CollectionItemChangedListener;
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    {
                        throw new NotImplementedException("NotifyCollectionChangedAction.Reset not supported");
                    }
            }
        }

        void CollectionItemChangedListener(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Complete")
            {
                OnPropertyChanged(new PropertyChangedEventArgs("CompleteCount"));
                OnPropertyChanged(new PropertyChangedEventArgs("IncompleteCount"));
            }
        }
    }
}
