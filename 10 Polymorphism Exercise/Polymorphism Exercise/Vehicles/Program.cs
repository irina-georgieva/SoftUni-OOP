using System;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split();
            string[] truckInfo = Console.ReadLine().Split();

            double carFuelQuan = double.Parse(carInfo[1]);
            double carFuelConsum = double.Parse(carInfo[2]);
            double truckFuelQuan = double.Parse(truckInfo[1]);
            double truckFuelConsum = double.Parse(truckInfo[2]);

            IVehicle car = new Car(carFuelQuan, carFuelConsum);
            IVehicle truck = new Truck(truckFuelQuan, truckFuelConsum);

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = Console.ReadLine().Split();

                string action = inputInfo[0];
                string vehicle = inputInfo[1];
                double value = double.Parse(inputInfo[2]);

                if (action == "Drive")
                {
                    if (vehicle == "Car")
                    {
                        if (car.CanDrive(value))
                        {
                            car.Drive(value);
                            Console.WriteLine($"Car travelled {value} km");
                        }     
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    if (vehicle == "Truck")
                    {
                        if (truck.CanDrive(value))
                        {
                            truck.Drive(value);
                            Console.WriteLine($"Truck travelled {value} km");
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else if (action == "Refuel")
                {
                    if (vehicle == "Truck")
                    {
                        truck.Refuel(value);
                    }
                    else
                    {
                        car.Refuel(value);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }
    }
}
