
using System;
using ToDo_Project.Resources;

namespace ToDo_Project.Core
{
    [Serializable]
    public struct Task
    {
        public string title { get; set; }
        public string description { get; set; }
        public string tags { get; set; }
        public bool isCompleted { get; set; }
        public string id { get; private set; }

        public Task(string title)
        {
            if (string.IsNullOrEmpty(title)) this.title = Strings.Default_Task_Title;
            else this.title = title;

            description = string.Empty;
            tags = string.Empty;
            isCompleted = false;
            id = Guid.NewGuid().ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Task task &&
                   id == task.id;
        }
    }
}
