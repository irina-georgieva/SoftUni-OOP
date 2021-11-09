using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : IPhone
    {
        public void CanCallPhones(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }

        public void CanBrowseTheInternet(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
