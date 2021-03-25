using System;
using Xunit;
using DataBindingExercise;
using System.Collections.Specialized;

namespace ToDoTests
{
    public class ToDoListUnitTest
    {
        [Fact]
        public void ShouldCountIncompleteTasks()
        {
            var tdl = new ToDoList();
            tdl.Add(new ToDoItem("Test1") { Complete = false });
            tdl.Add(new ToDoItem("Test2") { Complete = false });
            tdl.Add(new ToDoItem("Test3") { Complete = false });
            Assert.Equal(3, tdl.IncompleteCount);
        }

        [Fact]
        public void ShouldCountCompleteTasks()
        {
            var tdl = new ToDoList();
            tdl.Add(new ToDoItem("Test1") { Complete = false });
            tdl.Add(new ToDoItem("Test2") { Complete = true });
            tdl.Add(new ToDoItem("Test3") { Complete = true });
            Assert.Equal(2, tdl.CompleteCount);
        }

        [Fact]
        public void ShouldNotifyOfIncompleteCountChangingOnAdd()
        {
            var tdl = new ToDoList();
            Assert.PropertyChanged(tdl, "IncompleteCount", () =>
            {
                tdl.Add(new ToDoItem("Test 1") { Complete = false });
            });
        }

        [Fact]
        public void ShouldNotifyOfIncompleteCountChangingOnTaskComplete()
        {
            var tdl = new ToDoList();
            var tdi = new ToDoItem("Test") { Complete = false };
            tdl.Add(tdi);
            Assert.PropertyChanged(tdl, "IncompleteCount", () =>
            {
                tdi.Complete = true;
            });
        }

        [Fact]
        public void ShouldNotifyOfCollectionChangeOnAdd()
        {
            var tdl = new ToDoList();
            NotifyCollectionChangedEventArgs args = null;
            tdl.CollectionChanged += (sender, e) =>
            {
                args = e;
            };
            var tdi = new ToDoItem("Test");
            tdl.Add(tdi);
            Assert.NotNull(args);
            Assert.Equal(NotifyCollectionChangedAction.Add, args.Action);
            Assert.Equal(tdi, args.NewItems[0]);
            Assert.Equal(1, args.NewItems.Count);
            Assert.Null(args.OldItems);

        }
    }
}
