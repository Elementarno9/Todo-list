using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoListCLI
{
    public enum TodoStatus
    {
        Active,
        Success,
        Failure
    }

    public class Todo
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Deadline { get; private set; }
        public List<string> Tags { get; private set; }
        public TodoStatus Status { get; private set; }

        public Todo() : this("", "", DateTime.Now) { }

        public Todo(string title, string description, DateTime deadline, List<string> tags = null, TodoStatus status = TodoStatus.Active)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Tags = tags ?? new List<string>();
            Status = status;
        }

        public bool AddTag(string tag)
        {
            if (Tags.Contains(tag)) return false;
            Tags.Add(tag);
            return true;
        }

        public bool HasTag(string tag) => Tags.Contains(tag);

        public bool RemoveTag(string tag)
        {
            if (!Tags.Contains(tag)) return false;
            Tags.Remove(tag);
            return true;
        }

        public bool ChangeStatus(TodoStatus status)
        {
            if (Status == status) return false;
            Status = status;
            return true;
        }

        public string[] GetInfo(string dateFormat = "dd.MM.yyyy") => new[] { Title, Description, Deadline.ToString(dateFormat), string.Join(", ", Tags), Status.ToString() };

        public static Todo CreateTodoFromInfo(Dictionary<string, string> info) =>
            new Todo(info["Title"], info["Description"], DateTime.Parse(info["Deadline"]), info["Tags"].Split().ToList(),
                (TodoStatus)Enum.Parse(typeof(TodoStatus), info["Status"]));
    }
}
