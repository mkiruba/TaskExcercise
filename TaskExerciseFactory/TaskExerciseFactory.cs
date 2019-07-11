using System;

namespace TaskExerciseFactory
{
    public class TaskExerciseFactory
    {
        public abstract IAirConditioner Create(double temperature);
    }
}
