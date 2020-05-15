using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace TodoListCLI.Storage
{
    class TodoXMLStorageSystem : ITodoStorageSystem
    {
        public TodoList LoadTodoList(string path)
        {
            var todos = new List<Todo>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            foreach (XmlNode todoElem in xDoc.DocumentElement)
            {
                var data = new Dictionary<string, string>();
                foreach (XmlNode dataNode in todoElem.ChildNodes)
                {
                    if (dataNode.Name == "Tags")
                    {
                        StringBuilder stringBuilder = new StringBuilder();

                        foreach (XmlNode tagNode in dataNode.ChildNodes)
                        {
                            stringBuilder.Append(tagNode.InnerText).Append(" ");
                        }

                        data.Add("Tags", stringBuilder.ToString().Trim());
                    } else data.Add(dataNode.Name, dataNode.InnerText);
                }
                todos.Add(Todo.CreateTodoFromInfo(data));
            }

            return new TodoList(todos);
        }

        public bool SaveTodoList(string path, TodoList list)
        {
            XmlDocument xDoc = new XmlDocument();

            var root = xDoc.CreateElement("TodoList");
            xDoc.AppendChild(root);

            list.Todos.ForEach(todo =>
            {
                XmlElement todoElem = xDoc.CreateElement("Todo");

                var elements = todo.GetInfo().ToList();
                elements.RemoveAt(3); // Special output for tags

                var elemNames = new[] { "Title", "Description", "Deadline", "Status" };

                // Output for common fields
                elements.Select((str, i) => new[] { elemNames[i], str }).ToList().ForEach(data =>
                {
                    var elem = xDoc.CreateElement(data[0]);
                    elem.AppendChild(xDoc.CreateTextNode(data[1]));
                    todoElem.AppendChild(elem);
                });

                // Special output for tags
                var tagsElem = xDoc.CreateElement("Tags");
                todo.Tags.ForEach(tag =>
                {
                    var elem = xDoc.CreateElement("Tag");
                    elem.AppendChild(xDoc.CreateTextNode(tag));
                    tagsElem.AppendChild(elem);
                });
                todoElem.AppendChild(tagsElem);

                root.AppendChild(todoElem);
            });


            xDoc.Save(path);
            return true;
        }
    }
}
