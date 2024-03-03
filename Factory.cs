using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Factory
    {
        protected string[] m_VehicleTypes = { "FuelCar", "ElectricCar", "FuelMotorcycle", "ElectricMotorcycle", "Truck" };

        public string[] GetVehicleTypesArray()
        {
            return m_VehicleTypes;
        }

        public Vehicle CreateVehicle(string i_VehicleType)
        {
            Vehicle vehicleToCreate;

            switch (i_VehicleType)
            {
                case "1":
                    vehicleToCreate = new FuelCar();
                    break;
                case "2":
                    vehicleToCreate = new ElectricCar();
                    break;
                case "3":
                    vehicleToCreate = new FuelMotorcycle();
                    break;
                case "4":
                    vehicleToCreate = new ElectricMotorcycle();
                    break;
                case "5":
                    vehicleToCreate = new Truck();
                    break;
                default:
                    {
                        int chosenType;

                        if (int.TryParse(i_VehicleType, out chosenType) == true)
                        {
                            //throw new ArgumentOutOfRangeException(nameof(i_VehicleType), i_VehicleType, "No such a vehicle type");
                            throw new ValueOutOfRangeException(1, this.m_VehicleTypes.Length);
                        }
                        else
                        {
                            throw new FormatException("Your choice is " + i_VehicleType + " :  Invalid vehicle type");
                        }
                    }
            }

            return vehicleToCreate;
        }
    }
}