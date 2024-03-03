using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        protected string m_Manufacturer;
        protected float m_CurrentAirPressure;
        protected float m_MaxAirPressure;
        
        public string Manufacturer
        {
            get { return m_Manufacturer; }
            set { m_Manufacturer = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return this.m_MaxAirPressure; }
            set { this.m_MaxAirPressure = value; }
        }

        public void InflateWheel(string i_AirToFill)
        {
            float airToFill;
            bool isValid = float.TryParse(i_AirToFill, out airToFill);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_AirToFill + " :  Not a number");
            }

            if ((airToFill < 0) || (airToFill + this.m_CurrentAirPressure > this.m_MaxAirPressure))
            {
                throw new ValueOutOfRangeException(0, this.m_MaxAirPressure);
            }

            this.m_CurrentAirPressure += airToFill;
        }

        public void InflateWheelToMax()
        {
            this.InflateWheel((this.m_MaxAirPressure - this.m_CurrentAirPressure).ToString());
        }
    }
}