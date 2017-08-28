using System;

namespace ToDoListApp.Models
{
    public class TodoModel
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public bool Complete { get; set; } = false; 
        public DateTime Time {get; set;} = DateTime.Now;
    }
}