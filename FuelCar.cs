using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelCar:Car
    {
        readonly protected float r_MaxFuelCapacity = 58f;
        readonly protected eFuelType r_FuelType = eFuelType.Octan95;
        protected FuelVehicleSystem m_System;

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public FuelCar()
        {
            this.m_System = new FuelVehicleSystem(this.r_MaxFuelCapacity, this.r_FuelType);
            base.energySource = this.FuelType.ToString();
        }

        public override void FuelTheVehicle(string i_LitersToFill)
        {
            this.m_System.FillFuelTank(i_LitersToFill, this.r_FuelType);
            base.EnergyPercentages = (this.m_System.CurrentFuel / this.r_MaxFuelCapacity) * 100;
        }
    }
}