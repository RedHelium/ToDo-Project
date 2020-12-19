
using System;
using System.Collections.Generic;

namespace ToDo_Project.Core
{
    public sealed class TaskEventArgs : EventArgs
    {
        public Task task { get; private set; }

        public TaskEventArgs(Task task)
        {
            this.task = task;
        }
    }

    public sealed class TaskList
    {
        private readonly Task emptyTask = new Task("Empty Task");

        private List<Task> tasks = new List<Task>();
        
        public Task SelectedTask { get; private set; }

        public EventHandler<TaskEventArgs> AddTaskEvent;
        public EventHandler<TaskEventArgs> RemoveTaskEvent;
        public EventHandler<TaskEventArgs> SelectTaskEvent;


        public TaskList()
        {
            SelectedTask = emptyTask;
        }

        public bool ExistsSelectedTask() => !SelectedTask.Equals(emptyTask);

        public void Add(Task task)
        {
            tasks.Add(task);

            AddTaskEvent?.Invoke(this, new TaskEventArgs(task));
        }

        public void Remove(Task task)
        {
            SelectedTask = emptyTask;
            tasks.Remove(task);

            RemoveTaskEvent?.Invoke(this, new TaskEventArgs(task));
        }

        public void Select(Task task)
        {
            SelectedTask = task;

            SelectTaskEvent?.Invoke(this, new TaskEventArgs(task));
        }
   
    }
}
