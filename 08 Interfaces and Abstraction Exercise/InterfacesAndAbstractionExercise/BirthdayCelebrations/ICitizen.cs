using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface ICitizen
    {
        public string Name { get; set; }

        public string Birthdates { get; set; }
    }
}
