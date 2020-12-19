using System;
using System.Windows;
using ToDo_Project.Core;
using ToDo_Project.Viewers;

namespace ToDo_Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TaskList taskList;

        private TaskListView taskListView;
        private TaskInfoView taskInfoView;

        public MainWindow()
        {
            InitializeComponent();

            Init();
            SubscribeEvents();
            Task a = new Task("Test task");
            taskList.Add(a);
            Console.WriteLine(a.id);
        }

        private void Init()
        {
            InitModels();
            InitViewers();
        }

        private void InitModels()
        {
            taskList = new TaskList();
        }

        private void InitViewers()
        {
            taskListView = new TaskListView(TaskListGrid, taskList);
            taskInfoView = new TaskInfoView(this);
        }

        private void SubscribeEvents()
        {
            taskList.AddTaskEvent += taskListView.Add;
            taskList.RemoveTaskEvent += taskListView.Remove;
            taskList.SelectTaskEvent += taskInfoView.Output;
            DeleteTask.Click += Delete;
        }

        private void Delete(object sender, RoutedEventArgs args)
        {
            if (taskList.ExistsSelectedTask())
                taskList.Remove(taskList.SelectedTask);
        }
    }
}
