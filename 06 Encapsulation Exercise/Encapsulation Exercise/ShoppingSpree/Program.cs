using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPeople = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
                string[] inputProducts = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, Person> people = new Dictionary<string, Person>();
                Dictionary<string, Product> products = new Dictionary<string, Product>();

                foreach (var currentPerson in inputPeople)
                {
                    string[] values = currentPerson.Split('=');
                    string name = values[0];
                    decimal money = decimal.Parse(values[1]);

                    Person person = new Person(name, money);
                    people.Add(person.Name, person);
                }

                foreach (var currentProduct in inputProducts)
                {
                    string[] values = currentProduct.Split('=');

                    string name = values[0];
                    decimal cost = decimal.Parse(values[1]);

                    Product product = new Product(name, cost);
                    products.Add(product.Name, product);
                }

                string command = Console.ReadLine();

                while (command != "END")
                {
                    string[] purchaseInfo = command.Split();
                    Person person = people[purchaseInfo[0]];
                    Product product = products[purchaseInfo[1]];

                    if (person.Money - product.Cost < 0)
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                        command = Console.ReadLine();
                        continue;
                    }

                    person.AddProduct(product);

                    Console.WriteLine($"{person.Name} bought {product.Name}");

                    command = Console.ReadLine();
                }

                foreach (var person in people)
                {
                    string productMessage = person.Value.Products.Count == 0
                        ? "Nothing bought"
                        : string.Join(", ", person.Value.Products.Select(x => x.Name));

                    Console.WriteLine($"{person.Key} - {productMessage}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
