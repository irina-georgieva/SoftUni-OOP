using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : IIdentifiable, ICitizen
    {
        public Citizen(string id, string name, int age, string birthdates)
        {
            Id = id;
            Name = name;
            Age = age;
            Birthdates = birthdates;
        }

        public string Id { get; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Birthdates { get; set; }
    }
}
