using System;
using System.Collections.Generic;
using System.Linq;

namespace Capstone2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> taskList = new List<Task>();
            GetTaskList(taskList);
            bool run = true;
            string userOption = ShowMenu("Welcome to the Task Manager\n");
            while (run)
            {
                if (userOption == "1")
                {
                    ListTasks(taskList);
                    userOption = ShowMenu("\nMain Menu\n");
                }
                else if (userOption == "2")
                {
                    AddTask(taskList);
                    userOption = ShowMenu("\nMain Menu\n");
                }
                else if (userOption == "3")
                {
                    DeleteTask(taskList);
                    userOption = ShowMenu("\nMain Menu\n");
                }
                else if (userOption == "4")
                {
                    CompleteTask(taskList);
                    userOption = ShowMenu("\nMain Menu\n");
                }
                else if (userOption == "5")
                {
                    run = false;
                    Console.WriteLine("Goodbye.");
                }
                else
                {
                    Console.WriteLine("That is not an option. Please enter 1 through 5.");
                    userOption = ShowMenu("\nMain Menu\n");
                }
            }
        }
        public static void CompleteTask(List<Task> taskList)
        {
            Console.WriteLine($"\nWhich task number would you like to mark complete? Enter 1 through {taskList.Count}.");            
            string input = Console.ReadLine().Trim();
            int userComplete = 0;
            if (!int.TryParse(input, out userComplete))
            {
                Console.WriteLine($"That is not a number. Please enter 1 through {taskList.Count}.");
                CompleteTask(taskList);
            }
            else if (userComplete <= 0 || userComplete > taskList.Count)
            {
                Console.WriteLine($"That is not an option. Please enter 1 through {taskList.Count}.");
                CompleteTask(taskList);
            }
            else
            {
                userComplete = int.Parse(input);                
            }
            int index = 0;
            foreach (Task todo in taskList.ToList())
            {
                index++;
                if (userComplete == index)
                {
                    Console.WriteLine($"{index}.)\t {todo.MemberName} \t {todo.DueDate:d} \t {todo.Completed} \t\t {todo.Description}");
                    Console.WriteLine($"\nAre you sure you want to mark task #{index} complete? y/n");
                    string confirmComplete = Console.ReadLine().Trim();
                    if (confirmComplete == "y")
                    {
                        todo.Completed = true;
                        Console.WriteLine($"\nTask {index} marked completed.");
                    }
                }
            }
        }
        public static void DeleteTask(List<Task> taskList)
        {
            Console.WriteLine($"\nWhich task number would you like to delete? Enter 1 through {taskList.Count}. ");
            string input = Console.ReadLine().Trim();
            int userDelete = 0;
            int index = 0;
            if (!int.TryParse(input, out userDelete))
            {
                Console.WriteLine($"That is not a number. Please enter 1 through {taskList.Count}.");
                DeleteTask(taskList);
            }
            else if (userDelete <= 0 || userDelete > taskList.Count)
            {
                Console.WriteLine($"That is not an option. Please enter 1 through {taskList.Count}.");
                DeleteTask(taskList);
            }
            else
            {
                userDelete = int.Parse(input);
            }
            foreach (Task todo in taskList.ToList())
            {
                index++;
                if (userDelete == index)
                {
                    Console.WriteLine($"{index}.)\t {todo.MemberName} \t {todo.DueDate:d} \t {todo.Completed} \t\t {todo.Description}");
                    Console.WriteLine($"\nAre you sure you want to delete task #{index}? y/n");
                    string confirmDelete = Console.ReadLine().Trim();
                    if (confirmDelete == "y")
                    {
                        taskList.RemoveAt(index - 1);
                        Console.WriteLine($"\nTask {index} deleted.");
                    }
                }
            }            
        }
        public static void GetTaskList(List<Task> taskList)
        {
            {
                taskList.Add(new Task("Britta Perry", DateTime.Parse("5/7/2020"), false, "Buy new brand of cat food."));
                taskList.Add(new Task("Jeff Winger", DateTime.Parse("6/6/2020"), false, "Build new table."));
                taskList.Add(new Task("Annie Edison", DateTime.Parse("7/2/2020"), false, "Put up bulletin board."));
            }
        }
        public static string ShowMenu(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine($"\t 1. List Tasks");
            Console.WriteLine($"\t 2. Add Task");
            Console.WriteLine($"\t 3. Delete Task");
            Console.WriteLine($"\t 4. Mark Task Complete");
            Console.WriteLine($"\t 5. Quit");
            Console.WriteLine($"\n What would you like to do?");
            string input = Console.ReadLine().Trim();
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
            {
                Console.WriteLine("That is not an option. Please enter an option 1 through 5.");
                input = Console.ReadLine().Trim();
            }
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("This cannot be empty. Please enter an option 1 through 5.");
                input = Console.ReadLine().Trim();
            }
            return input;
        }
        public static void ListTasks(List<Task> taskList)
        {
            int index = 0;
            Console.WriteLine($"\nList of Tasks:");
            Console.WriteLine($"Number\t MemberName\t Due Date\t Completed \t Description");
            foreach (Task todo in taskList)
            {
                index++;
                Console.WriteLine($"{index}.)\t {todo.MemberName} \t {todo.DueDate:d} \t {todo.Completed} \t\t {todo.Description}");
            }
        }
        public static void AddTask(List<Task> tasklist)
        {
            DateTime userDueDate = DateTime.Parse("1/1/2000");
            bool userCompleted = false;
            Console.WriteLine($"\nADD TASK");
            Console.WriteLine("Team Member Name:");
            string userName = Console.ReadLine();
            Console.WriteLine("Task Due Date:");
            string input = Console.ReadLine();
            while (!DateTime.TryParse(input, out userDueDate))
            {
                Console.WriteLine("Please enter valid date. d/m/y");
                input = Console.ReadLine();
            }
            userDueDate = DateTime.Parse(input);
            Console.WriteLine("Task Description:");
            string userDescription = Console.ReadLine();
            tasklist.Add(new Task(userName, userDueDate, userCompleted, userDescription));
            Console.WriteLine($"\nTask entered.\n");
        }
    }
}
