using System.Transactions;

namespace BlazorTaskListApp.Service
{
    public class GlobalStateTasks
    {
        public int IdTracker { get; private set; } = 0;
        public List<Assignment> TaskList { get; set; }

        public event Action? OnChange;

        public void AddTask(string title, string? description)
        {
            int nextId = IdTracker++;
            Assignment newAssignment = new Assignment(title, description, nextId);

            TaskList.Add(newAssignment);

            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnChange?.Invoke();
        public class Assignment 
        {
            public int Id { get; set; }
            public string Title  { get; set; }
            public string? Description { get; set; }
            public bool Completed { get; set; } = false;

            public Assignment(string title, string? description, int id)
            {
                Title = title;
                Description = description;
                Id = id;
            }
        }
    }
}
