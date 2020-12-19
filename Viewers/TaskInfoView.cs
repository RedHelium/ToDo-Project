
using System.Windows;
using System.Windows.Controls;
using ToDo_Project.Core;

namespace ToDo_Project.Viewers
{
    public sealed class TaskInfoView
    {
        private TextBox title;
        private TextBox description;

        public TaskInfoView(MainWindow window)
        {
            title = window.Task_Title;
            description = window.Task_Description;
        }

        public void Output(object sender, TaskEventArgs args)
        {
            title.Text = args.task.title;
            description.Text = args.task.description;

        }
    }
}
