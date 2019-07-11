using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskExercise
{
    public class Task : ITask
    {
        #region Private declarations
        private TaskItem rootTask;
        #endregion

        #region Public methods ITaskStructure implementaions

        public void AddRoot(TaskItem parentTask)
        {
            rootTask = parentTask;
        }

        public void AddChild(TaskItem parentTask, TaskItem task)
        {
            parentTask.ChildTasks.Add(task);
        }

        public List<string> Execute(TaskItem task)
        {
            Stack<string> taskResults = new Stack<string>();
            taskResults.Push(task.Name);
            GetChildTaskName(task, taskResults);
            var result = taskResults.ToList();
            return result;
        }

        #endregion
       
        #region Private methods

        private void GetChildTaskName(TaskItem parentTask, Stack<string> taskResults)
        {
            foreach (var task in parentTask.ChildTasks)
            {
                ValidateAndAddTask(taskResults, task);
                if (task.ChildTasks.Count > 0)
                {
                    GetChildTaskName(task, taskResults);
                }
            }
        }

        private void ValidateAndAddTask(Stack<string> taskResults, TaskItem task)
        {
            var name = task.Name;
            //do not add if exists
            if (!taskResults.Contains(name))
            {
                taskResults.Push(task.Name);
            }
            else
            {
                //if exists the child also exists which means it is circular reference
                foreach (var childTask in task.ChildTasks)
                {
                    if (taskResults.Contains(childTask.Name))
                    {
                        throw new ArgumentException("Circular reference found.");
                    }
                }
            }
        } 
        #endregion
    }
}