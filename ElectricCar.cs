using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar:Car
    {
        protected ElectricVehicleSystem m_System;
        readonly protected float r_MaxBatteryTime = 4.8f;

        public ElectricCar()
        {
            this.m_System = new ElectricVehicleSystem(this.r_MaxBatteryTime);
            this.isElectricVehicle = true;
        }

        public override void FuelTheVehicle(string i_HoursToCharge)
        {
            this.m_System.ChargeBatteryInHours(i_HoursToCharge);
            base.EnergyPercentages = (this.m_System.CurrentBatteryTime / this.r_MaxBatteryTime) * 100;
        }
    }
}