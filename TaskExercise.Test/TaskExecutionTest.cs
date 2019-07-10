using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TaskExercise.Test
{
    [TestClass]
    public class TaskExecutionTest
    {
        [TestMethod]
        public void Should_add_tasks_2level()
        {
            //ROOT
            //    TASK1
            //    TASK2
            //Arrange
            var root = new Task("Root");
            var task1 = new Task("Task1");
            var task2 = new Task("Task2");
            var taskExecution = new TaskStructure(root);
            taskExecution.AddChild(root, task1);
            taskExecution.AddChild(root, task2);

            //Act
            var actual = taskExecution.Execute(root);

            //Assert
            Assert.AreEqual(actual.Count, 3);
            Assert.AreEqual(actual.Last(), "Root");
            Assert.AreEqual(actual.First(), "Task2");
        }

        [TestMethod]
        public void Should_add_tasks_3level()
        {
            //ROOT
            //    TASK1
            //      TASK11
            //      TASK12
            //    TASK2
            //      TASK21
            //      TASK22
            //Arrange
            var root = new Task("Root");
            var task1 = new Task("Task1");
            var task2 = new Task("Task2");
            var task11 = new Task("Task11");
            var task12 = new Task("Task12");
            var task21 = new Task("Task21");
            var task22 = new Task("Task22");
            var taskExecution = new TaskStructure(root);
            taskExecution.AddChild(root, task1);
            taskExecution.AddChild(root, task2);
            taskExecution.AddChild(task1, task11);
            taskExecution.AddChild(task1, task12);
            taskExecution.AddChild(task2, task21);
            taskExecution.AddChild(task2, task22);

            //Act
            var actual = taskExecution.Execute(root);

            //Assert
            Assert.AreEqual(actual.Count, 7);
            Assert.AreEqual(actual.Last(), "Root");
            Assert.AreEqual(actual.First(), "Task22");
        }

        [TestMethod]
        public void Should_add_tasks_two_parents()
        {
            //ROOT
            //    TASK1
            //      TASK11
            //      TASK12
            //    TASK2
            //      TASK21
            //      TASK12
            //Arrange
            var root = new Task("Root");
            var task1 = new Task("Task1");
            var task2 = new Task("Task2");
            var task11 = new Task("Task11");
            var task12 = new Task("Task12");
            var task21 = new Task("Task21");
            var taskExecution = new TaskStructure(root);
            taskExecution.AddChild(root, task1);
            taskExecution.AddChild(root, task2);
            taskExecution.AddChild(task1, task11);
            taskExecution.AddChild(task1, task12);
            taskExecution.AddChild(task2, task21);
            taskExecution.AddChild(task2, task12);

            //Act
            var actual = taskExecution.Execute(root);
            var actualTask1 = taskExecution.Execute(task1);

            //Assert
            Assert.AreEqual(actual.Count, 6);
            Assert.AreEqual(actual.Last(), "Root");
            Assert.AreEqual(actual.First(), "Task21");

            Assert.AreEqual(actualTask1.Count, 3);
            Assert.AreEqual(actualTask1.Last(), "Task1");
            Assert.AreEqual(actualTask1.First(), "Task12");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_fail_tasks_when_cirular_reference()
        {
            //ROOT
            //    TASK1
            //      TASK11
            //          ROOT
            //Arrange
            var root = new Task("Root");
            var task1 = new Task("Task1");
            var task11 = new Task("Task11");
            var taskExecution = new TaskStructure(root);
            taskExecution.AddChild(root, task1);
            taskExecution.AddChild(task1, task11);
            taskExecution.AddChild(task11, root);

            //Act
            var actual = taskExecution.Execute(root);
            var actualTask1 = taskExecution.Execute(task1);

            //Assert
            Assert.AreEqual(actual.Count, 7);
            Assert.AreEqual(actual.Last(), "Root");

            Assert.AreEqual(actualTask1.Count, 3);
            Assert.AreEqual(actualTask1.Last(), "Task1");
            Assert.AreEqual(actualTask1.First(), "Task12");
        }
    }
}
