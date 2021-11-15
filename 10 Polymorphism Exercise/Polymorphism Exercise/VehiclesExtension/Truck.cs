

using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption
            => base.FuelConsumption + 1.6;

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (TankCapacity < FuelQuantity + liters)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            liters *= 0.95;

            base.Refuel(liters);
        }
    }
}
