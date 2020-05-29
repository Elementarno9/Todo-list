using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace TodoListCLI.Storage
{
    class TodoXMLSerializationStorageSystem : ITodoStorageSystem
    {
        public TodoList LoadTodoList(string path)
        {
            using(var stream = new FileStream(path, FileMode.Open))
            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new XmlSerializer(typeof(TodoListType));
                var data = serializer.Deserialize(reader) as TodoListType;
                return data.ToTodoList();
            }
        }

        public void SaveTodoList(string path, TodoList list)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(TodoListType));
                serializer.Serialize(stream, TodoListType.Parse(list));
            }
        }
    }
}
