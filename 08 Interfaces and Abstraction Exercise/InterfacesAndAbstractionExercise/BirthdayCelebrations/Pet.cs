using BorderControl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Pet : ICitizen
    {
        public Pet(string name, string birthdates)
        {
            Name = name;
            Birthdates = birthdates;
        }

        public string Name { get ; set ; }
        public string Birthdates { get ; set ; }
    }
}
