using System.Linq;
using System.Xml.Linq;

namespace TodoListCLI.Storage
{
    class TodoLINQtoXMLStorageSystem : ITodoStorageSystem
    {
        public TodoList LoadTodoList(string path)
        {
            return new TodoList(XDocument.Load(path).Descendants("Todo").Select(elem =>
                Todo.CreateTodoFromInfo(
                    elem.Elements().Select(e => {
                        string value = e.Value.ToString();
                        if (e.Name == "Tags") value = string.Join(' ', e.Elements().Select(tag => tag.Value));

                        return new[] { e.Name.ToString(), value };
                        }).ToDictionary(field => field[0], field => field[1]))
                ).ToList());
        }

        public void SaveTodoList(string path, TodoList list)
        {
            var elemNames = new[] { "Title", "Description", "Deadline", "Tags", "Status" };

            var doc = new XDocument(new XElement("TodoList",
                list.Todos.Select(todo => new XElement("Todo",
                    todo.GetInfo().Select((field, i) =>
                    {
                        object data = field;
                        if (elemNames[i] == "Tags") data = todo.Tags.Select(tag => new XElement("Tag", tag)).ToArray();
                        return new XElement(elemNames[i], data);
                    }).ToArray())
                )));

            doc.Save(path);
        }
    }
}
