using System;
using System.Collections.Generic;
using System.Text;

namespace TaskExerciseFactory
{
    public interface ITaskStructure
    {
        void AddChild(Task parentTask, Task task);
        List<string> Execute(Task task);
    }
}
