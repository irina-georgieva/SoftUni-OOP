using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IIdentifiable> indentifiebles = new List<IIdentifiable>();

            while (input != "End")
            {
                IIdentifiable identifiable = null;
                string[] inputInfo = input.Split();
                
                if (inputInfo.Length == 2)
                {
                    string model = inputInfo[0];
                    string id = inputInfo[1];

                    identifiable = new Robot(id, model);

                }
                else if (inputInfo.Length == 3)
                {
                    string name = inputInfo[0];
                    int age = int.Parse(inputInfo[1]);
                    string id = inputInfo[2];

                    identifiable = new Citizen(id, name, age);

                }

                indentifiebles.Add(identifiable);

                input = Console.ReadLine();
            }

            string endDigits = Console.ReadLine();

            foreach (var item in indentifiebles)
            {
                if (item.Id.EndsWith(endDigits))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
