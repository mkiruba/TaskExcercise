using System.Collections.Generic;

namespace TaskExercise
{
    public class TaskItem
    {
        #region Public properties
        public string Name { get; set; }
        public List<TaskItem> ChildTasks { get; set; } = new List<TaskItem>();
        #endregion

        #region Constructor
        public TaskItem(string name)
        {
            this.Name = name;
        } 
        #endregion
    }
}
