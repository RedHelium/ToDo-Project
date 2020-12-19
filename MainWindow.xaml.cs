using System;
using System.Windows;
using System.Windows.Controls;
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
            taskList.RemoveTaskEvent += taskInfoView.Clear;
            taskList.SelectTaskEvent += taskInfoView.Output;
            DeleteTask.Click += Delete;
            CreateTask.Click += Create;
            Task_Title.TextChanged += TaskTitleChanged;
            Task_Description.TextChanged += TaskDescriptionChanged;
        }

        private void Delete(object sender, RoutedEventArgs args)
        {
            if (taskList.ExistsSelectedTask())
                taskList.Remove(taskList.SelectedTask);
        }

        private void Create(object sender, RoutedEventArgs args)
        {
            taskList.Add(new Task());
        }

        private void TaskTitleChanged(object sender, RoutedEventArgs args)
        {
            string value = (sender as TextBox).Text;

            if (taskList.ExistsSelectedTask() && !string.IsNullOrEmpty(value))
            {
                taskList.SelectedTask.title = value;
                
                if(taskListView.SelectedButton != null)
                    taskListView.SelectedButton.Content = value;
            }
        }

        private void TaskDescriptionChanged(object sender, RoutedEventArgs args)
        {
            string value = (sender as TextBox).Text;

            if (taskList.ExistsSelectedTask())
                taskList.SelectedTask.description = value;
        }
    }
}
