namespace TaskExercise.Factory
{
    public abstract class TaskFactory
    {
        public abstract ITaskStructure Create(Task task);
    }
}
