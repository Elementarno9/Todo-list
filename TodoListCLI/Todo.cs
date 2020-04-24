using System;
using System.Collections.Generic;

namespace TodoListCLI
{
    struct Todo
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Deadline { get; private set; }
        public List<string> Tags { get; private set; }

        public Todo(string title, string description, DateTime deadline, List<string> tags = null)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
            Tags = tags ?? new List<string>();
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
    }
}
