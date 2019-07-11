using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TaskExercise.Factory;

namespace TaskExercise.Test
{
    [TestClass]
    public class TaskExecutionTest
    {
        private ITaskFactory taskFactory;
        private ITask taskStructure;
        [TestInitialize]
        public void Initialise()
        {
            taskFactory = new TaskFactory();
            //Factory creates instance
            taskStructure = taskFactory.Create<ITask>();
        }

        [TestMethod]
        public void Should_add_tasks_2level()
        {
            //              ROOT
            //              /  \
            //          TASK1   TASK2
            //Arrange
            var root = new TaskItem("Root");
            var task1 = new TaskItem("Task1");
            var task2 = new TaskItem("Task2");
            var taskStructure = taskFactory.Create<ITask>();
            taskStructure.AddRoot(root);
            taskStructure.AddChild(root, task1);
            taskStructure.AddChild(root, task2);

            //Act
            var actual = taskStructure.Execute(root);

            //Assert
            Assert.AreEqual(actual.Count, 3);
            Assert.AreEqual(actual.Last(), "Root");
            Assert.AreEqual(actual.First(), "Task2");
        }

        [TestMethod]
        public void Should_add_tasks_3level()
        {
            //             ROOT
            //            /    \
            //       TASK1      TASK2
            //        /  \       /  \
            //   TASK11 TASK12 TASK21 TASK22
            
            //Arrange
            var root = new TaskItem("Root");
            var task1 = new TaskItem("Task1");
            var task2 = new TaskItem("Task2");
            var task11 = new TaskItem("Task11");
            var task12 = new TaskItem("Task12");
            var task21 = new TaskItem("Task21");
            var task22 = new TaskItem("Task22");
            var taskStructure = taskFactory.Create<ITask>();
            taskStructure.AddRoot(root);
            taskStructure.AddChild(root, task1);
            taskStructure.AddChild(root, task2);
            taskStructure.AddChild(task1, task11);
            taskStructure.AddChild(task1, task12);
            taskStructure.AddChild(task2, task21);
            taskStructure.AddChild(task2, task22);

            //Act
            var actual = taskStructure.Execute(root);

            //Assert
            Assert.AreEqual(actual.Count, 7);
            Assert.AreEqual(actual.Last(), "Root");
            Assert.AreEqual(actual.First(), "Task22");
        }

        [TestMethod]
        public void Should_add_tasks_with_two_parents()
        {
            //             ROOT
            //            /    \
            //       TASK1    TASK2
            //        /  \    /   \
            //   TASK11 TASK12  TASK21           
            //Arrange
            var root = new TaskItem("Root");
            var task1 = new TaskItem("Task1");
            var task2 = new TaskItem("Task2");
            var task11 = new TaskItem("Task11");
            var task12 = new TaskItem("Task12");
            var task21 = new TaskItem("Task21");
            var taskStructure = taskFactory.Create<ITask>();
            taskStructure.AddRoot(root);
            taskStructure.AddChild(root, task1);
            taskStructure.AddChild(root, task2);
            taskStructure.AddChild(task1, task11);
            taskStructure.AddChild(task1, task12);
            taskStructure.AddChild(task2, task21);
            taskStructure.AddChild(task2, task12);

            //Act
            var actual = taskStructure.Execute(root);
            var actualTask1 = taskStructure.Execute(task1);

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
            //          ROOT
            //          /   \ 
            //       TASK1  /   
            //        /    /
            //      TASK11 
            //Arrange
            var root = new TaskItem("Root");
            var task1 = new TaskItem("Task1");
            var task11 = new TaskItem("Task11");
            var taskStructure = taskFactory.Create<ITask>();
            taskStructure.AddRoot(root);
            taskStructure.AddChild(root, task1);
            taskStructure.AddChild(task1, task11);
            taskStructure.AddChild(task11, root);

            //Act
            var actual = taskStructure.Execute(root);
            var actualTask1 = taskStructure.Execute(task1);

            //Assert
            Assert.AreEqual(actual.Count, 7);
            Assert.AreEqual(actual.Last(), "Root");

            Assert.AreEqual(actualTask1.Count, 3);
            Assert.AreEqual(actualTask1.Last(), "Task1");
            Assert.AreEqual(actualTask1.First(), "Task12");
        }
    }
}
