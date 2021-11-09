using BirthdayCelebrations;
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
            List<ICitizen> citizens = new List<ICitizen>();

            while (input != "End")
            {
                IIdentifiable identifiable = null;
                ICitizen citizen = null;
                string[] inputInfo = input.Split();

                if (inputInfo[0] == "Robot")
                {
                    string model = inputInfo[1];
                    string id = inputInfo[2];

                    identifiable = new Robot(id, model);

                    input = Console.ReadLine();
                    continue;
                }
                else if (inputInfo[0] == "Citizen")
                {
                    string name = inputInfo[1];
                    int age = int.Parse(inputInfo[2]);
                    string id = inputInfo[3];
                    string birthdates = inputInfo[4];

                    citizen = new Citizen(id, name, age, birthdates);
                }
                else if (inputInfo[0] == "Pet")
                {
                    string name = inputInfo[1];
                    string birthdate = inputInfo[2];

                    citizen = new Pet(name, birthdate);
                }

                citizens.Add(citizen);

                input = Console.ReadLine();
            }

            string endBirthdate = Console.ReadLine();

            foreach (var item in citizens)
            {
                if (item.Birthdates.EndsWith(endBirthdate))
                {
                    Console.WriteLine(item.Birthdates);
                }
            }
        }
    }
}
