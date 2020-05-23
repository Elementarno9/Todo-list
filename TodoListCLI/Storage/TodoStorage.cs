using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace TodoListCLI.Storage
{
    static class TodoStorage
    {
        private static readonly Dictionary<string, ITodoStorageSystem> StorageSystems = new Dictionary<string, ITodoStorageSystem>()
        {
            ["XMLDocument"] = new TodoXMLStorageSystem(),
            ["LINQtoXML"] = new TodoLINQtoXMLStorageSystem(),
        };

        public static ITodoStorageSystem StorageSystem
        {
            get
            {
                return StorageSystems[ConfigurationManager.AppSettings["StorageSystem"]];
            }
        }

        public static bool SaveTodoList(string path, TodoList list) => StorageSystem.SaveTodoList(path, list);

        public static bool SaveTodoList(string path) => SaveTodoList(path, CLI.CurrentTodoList);

        public static TodoList LoadTodoList(string path) => StorageSystem.LoadTodoList(path);

        public static void ChangeStorageSystem(string storageSystem) {
            if (StorageSystems.ContainsKey(storageSystem))
            {
                ConfigurationManager.AppSettings["StorageSystem"] = storageSystem;
            }
        }
    }
}
