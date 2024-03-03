using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        readonly protected float r_MaxFuelCapacity = 110f;
        readonly protected eFuelType r_FuelType = eFuelType.Soler;
        readonly protected int r_NumberOfWheels = 12;
        readonly protected int r_MaxAirPressure = 28;
        protected bool m_DoesHaveDangerousMaterials;
        protected float m_LoadCapacity;
        protected FuelVehicleSystem m_System;

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public Truck()
        {
            this.m_System = new FuelVehicleSystem(this.r_MaxFuelCapacity, this.r_FuelType);
            base.energySource = this.FuelType.ToString();
            InitializeWheelsArray(r_NumberOfWheels, r_MaxAirPressure);
            base.m_Parameters = new string[] { "Does the truck have dangerous materials: 1(Yes), 0(No)", "Load capacity:" };
            base.m_ArgumentsToParameters = new string[2];
        }

        public override void FuelTheVehicle(string i_LitersToFill)
        {
            this.m_System.FillFuelTank(i_LitersToFill, this.r_FuelType);
            base.EnergyPercentages = (this.m_System.CurrentFuel / this.r_MaxFuelCapacity) * 100;
        }

        public void SetDoesItHaveDangerousMaterials(string i_DoesHaveDangerousMaterials)
        {
            int doesHaveDangerousMaterials;
            bool isValid = int.TryParse(i_DoesHaveDangerousMaterials, out doesHaveDangerousMaterials);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_DoesHaveDangerousMaterials + " :  Not a number");
            }

            if ((doesHaveDangerousMaterials != 1) && (doesHaveDangerousMaterials != 0)) 
            {
                throw new ValueOutOfRangeException(0, 1);
            }

            this.m_DoesHaveDangerousMaterials = (doesHaveDangerousMaterials == 1) ? true : false;
            base.m_ArgumentsToParameters[0] = this.m_DoesHaveDangerousMaterials.ToString();
        }

        public void SetLoadCapacity(string i_LoadCapacity)
        {
            int loadCapacity;
            bool isValid = int.TryParse(i_LoadCapacity, out loadCapacity);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_LoadCapacity + " :  Not a number");
            }

            if (loadCapacity <= 0)
            {
                throw new ValueOutOfRangeException(1);
            }

            this.m_LoadCapacity = loadCapacity;
            base.m_ArgumentsToParameters[1] = this.m_LoadCapacity.ToString();
        }

        public override void SetParameters(string[] i_Arguments)
        {
            this.SetDoesItHaveDangerousMaterials(i_Arguments[0]);
            this.SetLoadCapacity(i_Arguments[1]);
        }
    }
}