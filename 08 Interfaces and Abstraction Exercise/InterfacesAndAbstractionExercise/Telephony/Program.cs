using System;
using System.Linq;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            for (int i = 0; i < phoneNumbers.Length; i++)
            {
                string currentNumber = phoneNumbers[i];

                if (int.TryParse(currentNumber, out int result))
                {
                    if (currentNumber.Length == 10)
                    {
                        smartphone.CanCallPhones(currentNumber);
                    }
                    else if (currentNumber.Length == 7)
                    {
                        stationaryPhone.CanCallPhones(currentNumber);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }

            for (int i = 0; i < websites.Length; i++)
            {
                string currentSite = websites[i];

                if (currentSite.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartphone.CanBrowseTheInternet(currentSite);
                }
            }
        }
    }
}
