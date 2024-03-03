using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        protected List<VehicleInGarage> m_VehicalesInGarage = new List<VehicleInGarage>();
        protected int m_NumberOfVehicles = 0;

        public void InflateWheelsToMax(string i_LicensePlate)
        {
            VehicleInGarage vehicleInGarage = FindVehicleInGarage(i_LicensePlate);

            if (vehicleInGarage == null)
            {
                throw new ArgumentException("There is no such a vehicle with this license plate: " + i_LicensePlate);
            }

            Wheel[] wheels = vehicleInGarage.InnerVehicle.Wheels;

            foreach(Wheel wheel in wheels)
            {
                wheel.InflateWheelToMax();
            }
        }

        public List<VehicleInGarage> VehiclesFilteredByStatus(string i_VehicleStatus)
        {
            int vehicleStatus;
            bool isValid = int.TryParse(i_VehicleStatus, out vehicleStatus);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_VehicleStatus + " :  Not a number");
            }

            if ((vehicleStatus < 1) || vehicleStatus > 3) 
            {
                throw new ValueOutOfRangeException(1, 3);
            }

            List<VehicleInGarage> vehicleInGarages = new List<VehicleInGarage>();

            foreach (VehicleInGarage vehicleInGarage in this.m_VehicalesInGarage)
            {
                if (vehicleInGarage.VehicleStatus == (eVehicleStatus)vehicleStatus)
                {
                    vehicleInGarages.Add(vehicleInGarage);
                }
            }

            return vehicleInGarages;
        }

        public bool IsVehicleInGarage(string i_LicensePlate, out VehicleInGarage o_VehicleInGarage)
        {
            bool isInGarage = false;

            o_VehicleInGarage = FindVehicleInGarage(i_LicensePlate);
            if(o_VehicleInGarage != null)
            {
                isInGarage = true;
            }

            return isInGarage;
        }

        public void AddANewVehicle(VehicleInGarage i_VehicleToAddToGarage)
        {
            this.m_NumberOfVehicles += 1;
            this.m_VehicalesInGarage.Add(i_VehicleToAddToGarage);
        }

        public bool ChangeVehicleStatus(string i_LicensePlate, eVehicleStatus i_DesiredVehicleStatus)
        {
            VehicleInGarage vehicleToChangeStatus = FindVehicleInGarage(i_LicensePlate);
            bool hasChanged = false;

            if (vehicleToChangeStatus != null)
            {
                vehicleToChangeStatus.VehicleStatus = i_DesiredVehicleStatus;
                hasChanged = true;
            }

            return hasChanged;
        }

        public VehicleInGarage FindVehicleInGarage(string i_LicensePlate)
        {
            VehicleInGarage vehicleToSearch = null;

            foreach (VehicleInGarage vehicle in this.m_VehicalesInGarage)
            {
                if (vehicle.Vehicle.LicensePlate == i_LicensePlate)
                {
                    vehicleToSearch = vehicle;
                    break;
                }
            }

            return vehicleToSearch;
        }
    }
}