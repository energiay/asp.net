using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string City { get; set; }

        public Person (string name, string age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }
    }
}