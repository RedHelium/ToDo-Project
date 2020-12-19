using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ToDo_Project.Core;

namespace ToDo_Project.Viewers
{
    public struct TaskButton
    {
        public Task task;
        public Button button;

        public TaskButton(Task task, Button button)
        {
            this.task = task;
            this.button = button;
        }
    }

    public sealed class TaskListView
    {
        private List<TaskButton> taskButtons = new List<TaskButton>();
        private Grid parent;
        private TaskList taskList;

        public TaskListView(Grid parent, TaskList taskList)
        {
            this.parent = parent;
            this.taskList = taskList;
        }

        public void Add(object sender, TaskEventArgs args)
        {
            Button button = new Button();
            button.Click += Select;
            button.Content = args.task.title;

            parent.Children.Add(button);
            taskButtons.Add(new TaskButton(args.task, button));

        }

        public void Remove(object sender, TaskEventArgs args)
        {
            for (ushort buttonIndex = 0; buttonIndex < taskButtons.Count; buttonIndex++)
            {
                if (args.task.id.Equals(taskButtons[buttonIndex].task.id))
                {
                    parent.Children.RemoveAt(buttonIndex);
                    taskButtons.RemoveAt(buttonIndex);
                }
            }
        }

        private void Select(object sender, RoutedEventArgs args)
        {
            Button selectedTaskButton = sender as Button;
            Task selectedTask = taskButtons.SingleOrDefault(x => x.button.Equals(selectedTaskButton)).task;

            taskList.Select(selectedTask);
        }
    }
}
