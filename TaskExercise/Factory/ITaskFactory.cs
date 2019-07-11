namespace TaskExercise.Factory
{
    public interface ITaskFactory
    {
        T Create<T>();
    }
}
