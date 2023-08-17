using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Core
{

    public abstract class MultipleBase : iCalcExample
    {
        public abstract int Divisore { get; }

        /// <summary>
        /// True/False per indicare la divisibilità del value rispetto al divisore 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Divisibile(int value)
        {
            return value % Divisore == 0 ? true : false;
        }

        /// <summary>
        /// Calculate sum of Divisore's multiple up to maxValue 
        /// </summary>
        /// <param name="valueRef"></param>
        /// <returns>sum result</returns>
        public int[] Calculate(int valueRef)
        {
            int res = 0;
            for (int i = Divisore+1; i <= valueRef; i++)
            {
                if (Divisibile(i))
                    res += i;
            }
            return new int[] { res };
        }

    }
}
