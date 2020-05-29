using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using TodoListCLI;

namespace TodoListCLI.Storage
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("TodoList", Namespace = "", IsNullable = false)]
    public partial class TodoListType
    {

        private TodoType[] todoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Todo")]
        public TodoType[] Todo
        {
            get
            {
                return this.todoField;
            }
            set
            {
                this.todoField = value;
            }
        }

        public TodoList ToTodoList() => new TodoList(
            todoField.Select(fields =>
                new Todo(fields.Title, fields.Description, fields.Deadline, fields.Tags.ToList(), (TodoStatus)Enum.Parse(typeof(TodoStatus), fields.Status))
            ).ToList());

        public TodoListType() { }
        public TodoListType(TodoType[] fields) {
            Todo = fields;
        }

        public static TodoListType Parse(TodoList list) => new TodoListType(
                list.Todos.Select(todo => new TodoType(todo.Title, todo.Description, todo.Deadline, todo.Tags, todo.Status)).ToArray()
            );
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TodoType
    {

        private string titleField;

        private string descriptionField;

        private System.DateTime deadlineField;

        private string statusField;

        private string[] tagsField;

        /// <remarks/>
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public System.DateTime Deadline
        {
            get
            {
                return this.deadlineField;
            }
            set
            {
                this.deadlineField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Tag", IsNullable = false)]
        public string[] Tags
        {
            get
            {
                return this.tagsField;
            }
            set
            {
                this.tagsField = value;
            }
        }

        public TodoType() { }
        public TodoType(string title, string description, DateTime deadline, List<string> tags, TodoStatus status) {
            Title = title;
            Description = description;
            Deadline = deadline;
            Tags = tags.ToArray();
            Status = status.ToString();
        }
    }
}