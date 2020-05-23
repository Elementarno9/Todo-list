using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace TodoListCLI.Storage
{
    class TodoXMLSerializationStorageSystem : ITodoStorageSystem
    {
        public TodoList LoadTodoList(string path)
        {
            using(var stream = new FileStream(path, FileMode.Open))
            using (var reader = XmlReader.Create(stream))
            {
                var serializer = new DataContractSerializer(typeof(TodoList));
                return serializer.ReadObject(reader) as TodoList;
            }
        }

        public void SaveTodoList(string path, TodoList list)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                var serializer = new DataContractSerializer(typeof(Todo));
                serializer.WriteObject(stream, list);
            }
        }
    }
}
