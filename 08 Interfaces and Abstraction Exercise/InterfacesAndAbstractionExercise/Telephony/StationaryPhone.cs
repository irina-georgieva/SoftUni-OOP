using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : IPhone
    {
        public void CanCallPhones(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
