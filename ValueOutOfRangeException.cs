using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException:Exception
    {
        protected float m_MinValue;
        protected float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue) : base(message: string.Format("Out of range of ({0}, {1})", i_MinValue, i_MaxValue))
        {
            this.m_MinValue = i_MinValue;
            this.m_MaxValue = i_MaxValue;
        }

        public ValueOutOfRangeException(float i_MinValue) : base(message: string.Format("Out of range of ({0}, infinity)", i_MinValue))
        {
            this.m_MinValue = i_MinValue;
        }
    }
}