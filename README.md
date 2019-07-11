# TaskExcercise



* TaskItem class is the data structure class.

* Task is the class to construct the tree.

* ITask is the Interface contract.
* ITaskFactory, TaskFactory are the factory classes that generate relevant objects. This factory can be amended to have further implemetation of various Task.

## Unit Tests

* Should_add_tasks_2level

            //              ROOT
            //              /  \
            //          TASK1   TASK2
  Adds the two level tree.
  
  ---
* Should_add_tasks_3level

            //             ROOT
            //            /    \
            //       TASK1      TASK2
            //        /  \       /  \
            //   TASK11 TASK12 TASK21 TASK22
Adds the three level tree.

---

* Should_add_tasks_with_two_parents

            //             ROOT
            //            /    \
            //       TASK1    TASK2
            //        /  \    /   \
            //   TASK11 TASK12  TASK21           
Adds the three level tree with two parents.

---

* Should_fail_tasks_when_cirular_reference

            //          ROOT
            //          /   \ 
            //       TASK1  /   
            //        /    /
            //      TASK11 
Adds the three level tree with circular reference.
