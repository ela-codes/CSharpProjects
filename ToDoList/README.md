# To-Do List CLI Application

A simple command-line to-do list application built with C# and .NET 9.0.

## Features

- Add new tasks
- View individual tasks by ID
- Update task status (incomplete, pending, done)
- List all tasks
- Simple text-based interface

## How to Run

1. Make sure you have .NET 9.0 SDK installed on your system
2. Navigate to the project directory in your terminal/command prompt
3. Run the application using one of these commands:

   ```bash
   dotnet run
   ```

   Or build and run:

   ```bash
   dotnet build
   dotnet run
   ```

## How to Use

Once the program starts, you'll see a menu with available commands:

- **add** - Add a new task
- **task** - View and update a specific task by ID
- **list** - Display all tasks
- **q** - Quit the program

### Example Usage

1. **Adding a task:**

   ```text
   What do you want to do? (add, task, list, q): add
   Enter task description: Buy groceries
   ```

2. **Viewing all tasks:**

   ```text
   What do you want to do? (add, task, list, q): list
   ```

3. **Viewing and updating a specific task:**

   ```text
   What do you want to do? (add, task, list, q): task
   Enter a task ID: 1
   Change status? (y/n): y
   Enter new status (incomplete, pending, done): done
   ```

## Task Status Options

- **incomplete** - Task not started (default)
- **pending** - Task in progress
- **done** - Task completed

## Requirements

- .NET 9.0 SDK
- Windows, macOS, or Linux

## Notes

- Tasks are stored in memory only and will be lost when the program exits
- Task IDs start from 1 and increment automatically
- Enter "q" at any prompt to exit the program
