using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicensePlate;
        protected float m_EnergyPercentagesLeft;
        protected Wheel[] m_Wheels;
        protected bool isElectricVehicle = false;
        protected string[] m_Parameters;
        protected string[] m_ArgumentsToParameters;
        protected string energySource;

        public float EnergyPercentages
        {
            get { return m_EnergyPercentagesLeft;}
            set { m_EnergyPercentagesLeft = value;}
        }

        public string Model
        { 
            get { return m_Model; } 
            set { m_Model = value; }
        }

        public string EnergySource
        { get { return energySource; } }

        public Wheel[] Wheels
        { get { return m_Wheels; } }

        public bool IsElectricVehicle
        { get { return isElectricVehicle; } }

        public string LicensePlate
        {
            get { return m_LicensePlate;}
            set { m_LicensePlate = value; }
        }

        public Vehicle()
        {
            Console.WriteLine("Constructor Vehicle");
        }

        public abstract void SetParameters(string[] i_Arguments);

        public abstract void FuelTheVehicle(string i_HowMuchToFill);

        public void InitializeWheelsArray(int i_NumberOfWheels, int i_MaxAirPressure)
        {
            m_Wheels = new Wheel[i_NumberOfWheels];
            for (int j = 0; j < i_NumberOfWheels; j++)
            {
                m_Wheels[j] = new Wheel();
                m_Wheels[j].MaxAirPressure = i_MaxAirPressure;
            }
        }

        public string[] GetParameters()
        {
            return this.m_Parameters;
        }

        public string[] GetArguments()
        {
            return this.m_ArgumentsToParameters;
        }
    }
}