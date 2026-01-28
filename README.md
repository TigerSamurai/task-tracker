# Task Tracker (CLI)

A simple command-line task tracker written in C#.  
It supports adding, updating, deleting, and listing tasks, and persists them to a local JSON file (`tasks.json`) in the current working directory.
------------------------------------------
## Features
- Add tasks
- Update task descriptions
- Delete tasks
- Mark tasks as `todo`, `in_progress`, or `done`
- List all tasks
- List tasks by status
- Tasks are stored in a JSON file (`tasks.json`) created automatically if it doesn’t exist
------------------------------------------
## Task Properties
Each task includes:
- `taskId` (unique identifier)
- `description`
- `status` (`TODO`, `IN_PROGRESS`, `DONE`)
- `createdAt`
- `updatedAt`
------------------------------------------
## Requirements
- .NET SDK installed (compatible with the target framework in the project)
------------------------------------------
# Commands Examples
## Adding a new task
TaskTracker add "Buy groceries"

## Updating and deleting tasks
TaskTracker update 1 "Buy groceries and cook dinner"
TaskTracker delete 1

## Marking a task as in progress or done
TaskTracker mark in_progress 1
TaskTracker mark-done 1

## Listing all tasks
TaskTracker list

## Listing tasks by status
TaskTracker list done
TaskTracker list todo
TaskTracker list in-progress
------------------------------------------
## How to Run

- Open your command line
- set path to the TaskTracker.exe (e.g cd C:\Users\username\location\foldername\TaskTracker\TaskTracker\bin\Debug\net10.0)
- type the command you want (look for the example above)

IMPORTANT: All the tasks should be written inside "" quotation marks ("do homework", "prepare for work" and etc.)

