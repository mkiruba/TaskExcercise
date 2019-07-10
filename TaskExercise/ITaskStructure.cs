using System.Collections.Generic;

namespace TaskExercise
{
    public interface ITaskStructure
    {
        void AddChild(Task parentTask, Task task);
        List<string> Execute(Task task);
    }
}