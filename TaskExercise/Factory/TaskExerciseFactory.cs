namespace TaskExercise.Factory
{
    public class TaskExerciseFactory : TaskFactory
    {
        public override ITaskStructure Create(Task task)
        {
            return new TaskStructure(task);
        }
    }
}
