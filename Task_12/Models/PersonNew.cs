using System.Collections.Generic;

namespace Task_12.Models
{
    public class PersonNew
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<string> Languages { get; set; }
        public Company Company { get; set; }
    }
}