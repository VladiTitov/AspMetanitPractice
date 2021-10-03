using System.Collections.Generic;

namespace Task_13.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public Company Company { get; set; }
    }
}