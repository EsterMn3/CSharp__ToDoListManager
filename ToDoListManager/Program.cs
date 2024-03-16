using System;

namespace ToDoListManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Array to store tasks
            string?[] tasks = new string[10];
            // Array to track completion status of tasks
            bool[] completed = new bool[10];
            // Variable to keep track of the number of tasks
            int taskCount = 0;

            Console.WriteLine("Welcome to the To-Do List Manager!");

            // Main program loop
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Mark Task as Complete");
                Console.WriteLine("3. Remove Task");
                Console.WriteLine("4. View Tasks");
                Console.WriteLine("5. Exit");

                // Prompting user for choice
                Console.Write("Enter your choice: ");
                int choice;

                // Try block to catch format exception if user enters non-integer input
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());

                    // Switch statement for handling user choices
                    switch (choice)
                    {
                        case 1: // Add Task
                            if (taskCount < tasks.Length)
                            {
                                Console.Write("Enter task: ");
                                string? newTask = Console.ReadLine();
                                tasks[taskCount++] = newTask;
                                Console.WriteLine("Task added successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Task list is full!");
                            }
                            break;

                        case 2: // Mark Task as Complete
                            Console.Write("Enter index of task to mark as complete: ");
                            int completeIndex = Convert.ToInt32(Console.ReadLine());

                            if (completeIndex > 0 && completeIndex <= taskCount)
                            {
                                completed[completeIndex - 1] = true; // Mark task as completed
                                Console.WriteLine($"Task '{tasks[completeIndex - 1]}' marked as completed.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index!");
                            }
                            break;

                        case 3: // Remove Task
                            Console.Write("Enter index of task to remove: ");
                            int removeIndex = Convert.ToInt32(Console.ReadLine());

                            if (removeIndex > 0 && removeIndex <= taskCount)
                            {
                                for (int i = removeIndex - 1; i < taskCount - 1; i++)
                                {
                                    tasks[i] = tasks[i + 1];
                                    completed[i] = completed[i + 1];
                                }
                                //last index is remained null, empty
                                tasks[taskCount - 1] = null;
                                completed[taskCount - 1] = false;
                                taskCount--;
                                Console.WriteLine("Task removed successfully!");
                            }
                            else
                            {
                                Console.WriteLine("Invalid index!");
                            }
                            break;

                        case 4: // View Tasks
                            if (taskCount == 0)
                            {
                                Console.WriteLine("No tasks in the list.");
                            }
                            else
                            {
                                Console.WriteLine("\nTasks:");
                                for (int i = 0; i < taskCount; i++)
                                {
                                    if (completed[i])
                                    // If the task is marked as completed the program prints the task's index, name, and "(Completed)" indication. 
                                    {
                                        Console.WriteLine($"{i + 1}. {tasks[i]} (Completed)");
                                    }
                                    else                                     
                                    //If the task is not completed (completed[i] is false), it only prints the task's index and name without the "(Completed)" indication.
                                    {
                                        Console.WriteLine($"{i + 1}. {tasks[i]}");
                                    }
                                }
                            }
                            break;

                        case 5: // Exit
                            Console.WriteLine("Exiting...");
                            return;

                        default: // Invalid choice
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                // Catch block for any exception
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred: {e.Message}");                
                }
            }
        }
    }
}
