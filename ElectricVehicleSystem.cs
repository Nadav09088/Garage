using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public class ElectricVehicleSystem
    {
        protected float m_CurrentBatteryTime;
        readonly protected float r_MaxBatteryTime;

        public float CurrentBatteryTime
        {
            get { return m_CurrentBatteryTime; }
        }

        public ElectricVehicleSystem(float i_MaxBatteryTime)
        {
            m_CurrentBatteryTime = 0;
            this.r_MaxBatteryTime = i_MaxBatteryTime;
        }

        public void ChargeBatteryInHours(string i_HoursToCharge)
        {
            float batteryHoursToCharge;
            bool isValid = float.TryParse(i_HoursToCharge, out batteryHoursToCharge);

            if (isValid != true)
            {
                throw new FormatException("Your choice is not a number");
            }

            if ((batteryHoursToCharge < 0) || (batteryHoursToCharge + this.m_CurrentBatteryTime > this.r_MaxBatteryTime))
            {
                throw new ValueOutOfRangeException(0, (this.r_MaxBatteryTime - this.m_CurrentBatteryTime) * 60);
            }

            this.m_CurrentBatteryTime += batteryHoursToCharge;
        }
    }
}