using System.Collections.Generic;

namespace TaskExercise
{
    public interface ITask
    {
        void AddRoot(TaskItem parentTask);
        void AddChild(TaskItem parentTask, TaskItem task);
        List<string> Execute(TaskItem task);
    }
}