using System.Collections.Generic;

namespace TaskExercise
{
    public class Task
    {
        #region Public properties
        public string Name { get; set; }
        public List<Task> ChildTasks { get; set; } = new List<Task>();
        #endregion

        #region Constructor
        public Task(string name)
        {
            this.Name = name;
        } 
        #endregion
    }
}
