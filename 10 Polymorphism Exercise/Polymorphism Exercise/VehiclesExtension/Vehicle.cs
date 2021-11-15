using System;

namespace Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;            
        }

        public double FuelQuantity
        {
            get => fuelQuantity;
            set
            {
                if (value > TankCapacity)
                {
                    value = 0;    
                }

                fuelQuantity = value;
            }
        }
        public virtual double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public double TankCapacity 
        { 
            get => tankCapacity; 
            set => tankCapacity = value; 
        }
        public bool IsEmpty { get ; set ; }

        public bool CanDrive(double km)
        {
            if (this.FuelQuantity - (km * this.FuelConsumption) >= 0)
            {
                return true;
            }

            return false;
        }

        public void Drive(double km)
        {
            if (!CanDrive(km))
            {
                return;
            }
            this.FuelQuantity -= km * this.FuelConsumption;
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (TankCapacity < fuelQuantity + liters)
            {
                throw new InvalidOperationException($"Cannot fit {liters} fuel in the tank");
            }

            this.FuelQuantity += liters;
        }
    }
}
