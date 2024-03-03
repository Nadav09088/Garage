using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelMotorcycle:Motorcycle
    {
        readonly protected float r_MaxFuelCapacity = 5.8f;
        readonly protected eFuelType r_FuelType = eFuelType.Octan98;
        protected FuelVehicleSystem m_System;

        public eFuelType FuelType
        {
            get { return r_FuelType; }
        }

        public FuelMotorcycle()
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