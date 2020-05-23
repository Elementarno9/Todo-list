using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TodoListCLI
{
    public enum TodoStatus
    {
        Active,
        Success,
        Failure
    }

    [DataContract(Name="Todo")]
    public class Todo
    {
        [DataMember]
        public string Title { get; private set; }
        [DataMember]
        public string Description { get; private set; }
        [DataMember]
        public DateTime Deadline { get; private set; }
        [DataMember]
        public List<string> Tags { get; private set; }
        [DataMember]
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

        public string[] GetInfo() => new[] { Title, Description, Deadline.ToString("dd.MM.yyyy"), string.Join(", ", Tags), Status.ToString() };

        public static Todo CreateTodoFromInfo(Dictionary<string, string> info) =>
            new Todo(info["Title"], info["Description"], DateTime.ParseExact(info["Deadline"], "dd.MM.yyyy", CultureInfo.InvariantCulture), info["Tags"].Split().ToList(),
                (TodoStatus)Enum.Parse(typeof(TodoStatus), info["Status"]));
    }
}
