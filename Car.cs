using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{

    public abstract class Car : Vehicle
    {
        readonly protected int r_NumberOfWheels = 5;
        readonly protected int r_MaxAirPressure = 30;
        protected int m_NumberOfDoors;
        private eCarColor m_CarColor;

        enum eCarColor
        {
            Blue = 1,
            White,
            Red,
            Yellow
        }

        public void SetNumberOfDoors(string i_NumberOfDoors)
        {
            int numberOfDoors;
            bool isValid = int.TryParse(i_NumberOfDoors, out numberOfDoors);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_NumberOfDoors + " :  Not a number");
            }

            if (numberOfDoors < 2 || numberOfDoors > 5)
            {
                throw new ValueOutOfRangeException(2, 5);
            }

            this.m_NumberOfDoors = numberOfDoors;
            base.m_ArgumentsToParameters[0] = this.m_NumberOfDoors.ToString();
        }

        public void SetCarColor(string i_CarColor)
        {
            int carColor;
            bool isValid = int.TryParse(i_CarColor, out carColor);

            if (isValid != true)
            {
                throw new FormatException("Your choice is " + i_CarColor + " :  Not a number");
            }

            if ((carColor < 1) || carColor > 4) 
            {
                throw new ValueOutOfRangeException(1, 4);
            }

            this.m_CarColor = (eCarColor)carColor;
            base.m_ArgumentsToParameters[1] = this.m_CarColor.ToString();
        }

        public Car()
        {
            Console.WriteLine("Constructor Car");
            InitializeWheelsArray(r_NumberOfWheels, r_MaxAirPressure);
            base.m_Parameters = new string[] { "Number of doors: 2, 3, 4, 5", "Car color: 1(Blue), 2(White), 3(Red), 4(Yellow)" };
            base.m_ArgumentsToParameters = new string[2];
        }

        public override void SetParameters(string[] i_Arguments)
        {
            this.SetNumberOfDoors(i_Arguments[0]);
            this.SetCarColor(i_Arguments[1]);
        }
    }
}