using System.Collections.Generic;

namespace TaskExercise
{
    public class Task
    {
        public string Name { get; set; }
        public List<Task> ChildTasks { get; set; } = new List<Task>();

        public Task(string name)
        {
            this.Name = name;
        }
    }
}
