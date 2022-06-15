using System;

namespace ItemsControls
{
    public class Person
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public string DisplayAll => $"{Name}, {BirthDate:dd. MMMM yyyy}";
    }
}