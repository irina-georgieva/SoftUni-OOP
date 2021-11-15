using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string name = string.Empty;
            string typeHero = string.Empty;

            List<IBaseHero> heroes = new List<IBaseHero>();

            while (heroes.Count != n)
            {
                IBaseHero hero = null;
                name = Console.ReadLine();
                typeHero = Console.ReadLine();

                if (typeHero == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (typeHero == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (typeHero == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (typeHero == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    continue;
                }

                heroes.Add(hero);
            }

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int powerBoss = int.Parse(Console.ReadLine());

            if (heroes.Sum(x => x.Power) >= powerBoss)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
