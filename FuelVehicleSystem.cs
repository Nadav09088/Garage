using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelVehicleSystem
    {
        readonly protected eFuelType r_FuelType;
        readonly protected float r_MaxFuelCapacity;
        protected float m_CurrentFuel;

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public float CurrentFuel
        {
            get { return this.m_CurrentFuel; }
            set { this.m_CurrentFuel = value; }
        }

        public FuelVehicleSystem(float i_MaxFuelCapacity, eFuelType i_FuelType)
        {
            this.r_MaxFuelCapacity = i_MaxFuelCapacity;
            this.r_FuelType = i_FuelType;
        }

        public void FillFuelTank(string i_LitersToFill, eFuelType i_FuelType)
        {
            float litersTofill;
            bool isValid = float.TryParse(i_LitersToFill, out litersTofill);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_LitersToFill + " :  Not a number");
            }

            if ((litersTofill < 0) || (litersTofill + this.m_CurrentFuel > this.r_MaxFuelCapacity)) 
            {
                throw new ValueOutOfRangeException(0, this.r_MaxFuelCapacity);
            }

            this.CurrentFuel += litersTofill;
        }
    }
}