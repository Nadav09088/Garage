using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleInGarage
    {
        protected Vehicle m_Vehicle;
        protected string m_OwnersName;
        protected string m_OwnersPhoneNumber;
        protected eVehicleStatus m_VehicleStatus;

        public Vehicle InnerVehicle
        {
            get { return m_Vehicle; }
        }

        public string OwnersName
        {
            get { return m_OwnersName; }
            set { m_OwnersName = value; }
        }

        public string OwnersPhoneNumber
        {
            get { return m_OwnersPhoneNumber; }
            set { m_OwnersPhoneNumber = value; }
        }

        public eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }
    }
}