using System;

namespace TaskExercise.Factory
{
    public class TaskFactory : ITaskFactory
    {
        public T Create<T>()
        {
            //Add more instance creation for other implementations
            if (typeof(T) == typeof(ITask))
            {
                return (T)(ITask)new Task();
            }
            else
            {
                throw new NotImplementedException($"Creation of {typeof(T)} interface is not supported yet.");
            }
        }
    }
}
