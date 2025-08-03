// CLI-Based To Do List.
/*
 * Functionality
 * - Add a new task
 * - Update task status
 * - List all tasks
 * 
 * Classes
 * - Task: Represents a single task with properties like ID, description, and completion status
 * - TaskManager: Manages a list of tasks and provides methods to add, complete, and list tasks
 * - TaskList: A simple in-memory list to store tasks
 */
using System.Data;
using System.Text;

string input = "";
string divider = "====================";

Console.WriteLine($"{divider}");
Console.WriteLine("""Enter "q" at anytime to exit the program.""");
Console.WriteLine($"Functions:\nadd - add new task\ntask - view a task by id\nlist - view all tasks\n{divider}");

while (input != "q") {
    // Ask user what they want to do - add task, view task by id, view task list
    
    Console.Write("What do you want to do? (add, task, list, q): ");
    input = (Console.ReadLine() ?? "").Trim();

    switch (input)
    {
        case "add":
            Console.Write("Enter task description: ");
            input = (Console.ReadLine() ?? "").Trim();
            if (input.Length > 0 && input != "q")
            {
                Task newTask = TaskList.AddTask(input);
                Console.WriteLine($"{newTask.ToString()}");

            }
            break;
        case "task":
            Console.Write("Enter a task ID: ");
            input = (Console.ReadLine() ?? "").Trim();
            bool isValidInt = int.TryParse(input, out int result);
            if (isValidInt && result <= TaskList.TotalLength())
            {
                Task foundTask = TaskList.GetTask(result - 1);
                Console.WriteLine(foundTask.ToString());
                Console.Write("Change status? (y/n): ");
                input = (Console.ReadLine() ?? "").Trim();
                if (input == "y")
                {
                    Console.Write("Enter new status (incomplete, pending, done): ");
                    input = (Console.ReadLine() ?? "").Trim();
                    Task updatedTask = TaskList.UpdateStatus(foundTask, input);
                    Console.WriteLine($"{updatedTask.ToString()}");
                }
            }
            break;
        case "list":
            Console.WriteLine(TaskList.ShowAll());
            break;
    }
}



class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    private string _status;

    public string Status
    {
        get => _status;
        set
        {
            string[] possibleStatus = { "incomplete", "pending", "done" };
            if (possibleStatus.Contains(value))
            {
                _status = value;
            }
        }
    }

    public Task(int id, string description)
    {
        this.Id = id;
        this.Description = description;
        this._status = "incomplete";
    }

    public override string ToString()
    {
        return $"{this.Id}, {this.Status}, {this.Description}";
    }
}

class TaskList
{
    private static List<Task> myList = new List<Task>();

    public static Task AddTask(string description)
    {
        Task newTask = new Task(myList.Count + 1, description);
        myList.Add(newTask);
        return newTask;
    }
    public static int TotalLength()
    {
        return myList.Count;
    }

    public static Task GetTask(int Id)
    {
        return myList[Id];
    }

    public static Task UpdateStatus(Task task, string newStatus)
    {
        task.Status = newStatus;
        return task;
    }

    public static string ShowAll()
    {
        StringBuilder outputText = new StringBuilder();

        void appendToStringBuilder(Task task)
        {
            outputText.Append(task.ToString());
            outputText.Append("\n");
        }
        myList.ForEach(appendToStringBuilder);
        return outputText.ToString();
    }

}

