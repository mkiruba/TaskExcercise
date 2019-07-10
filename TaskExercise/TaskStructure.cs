using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskExercise
{
    public class TaskStructure : ITaskStructure
    {
        private readonly Task taskList;

        public TaskStructure(Task task)
        {
            taskList = task;
        }

        public void AddChild(Task parentTask, Task task)
        {          
            parentTask.ChildTasks.Add(task);
        }

        public List<string> Execute(Task task)
        {
            List<string> taskResults = new List<string>
            {
                task.Name
            };
            GetChildTaskName(task, taskResults);
            var result = taskResults.ToList();
            result.Reverse();
            return result;
        }

        private void GetChildTaskName(Task parentTask, List<string> taskResults)
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

        private void ValidateAndAddTask(List<string> taskResults, Task task)
        {
            var name = task.Name;
            //do not add if exists
            if (!taskResults.Contains(name))
            {
                taskResults.Add(task.Name);
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
    }
}