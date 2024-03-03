using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        readonly protected int r_NumberOfWheels = 2;
        readonly protected int r_MaxAirPressure = 29;
        protected int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        public enum eLicenseType
        {
            A1 = 1,
            A2,
            AB,
            B2
        }

        public Motorcycle()
        {
            Console.WriteLine("Constructor Motorcycle");
            InitializeWheelsArray(r_NumberOfWheels, r_MaxAirPressure);
            base.m_Parameters = new string[] { "License type: 1(A1), 2(A2), 3(AB), 4(B2)", "Engine capacity:" };
            base.m_ArgumentsToParameters = new string[2];
        }

        public void SetLicenseType(string i_LicenseType)
        {
            int licenseType;
            bool isValid = int.TryParse(i_LicenseType, out licenseType);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_LicenseType + " :  Not a number");
            }

            if ((licenseType < 1) || licenseType > 4)
            {
                throw new ValueOutOfRangeException(1, 4);
            }

            this.m_LicenseType = (eLicenseType)licenseType;
            base.m_ArgumentsToParameters[0] = this.m_LicenseType.ToString();
        }

        public void SetEngineCapacity(string i_EngineCapacity)
        {
            int engineCapacity;
            bool isValid = int.TryParse(i_EngineCapacity, out engineCapacity);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_EngineCapacity + " :  Not a number");
            }

            if (engineCapacity <= 0)
            {
                throw new ValueOutOfRangeException(1);
            }

            this.m_EngineCapacity = engineCapacity;
            base.m_ArgumentsToParameters[1] = this.m_EngineCapacity.ToString();
        }
        public override void SetParameters(string[] i_Arguments)
        {
            this.SetLicenseType(i_Arguments[0]);
            this.SetEngineCapacity(i_Arguments[1]);
        }
    }
}