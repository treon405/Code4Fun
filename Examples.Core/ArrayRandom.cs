using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Core
{
    public class ArrayRandom : iCalcExample
    {
        /// <summary>
        /// Calculate array with 
        /// </summary>
        /// <returns></returns>
        public int[] Calculate(int valueRef)
        {
            Random random = new Random();
            int[] arr = new int[valueRef];
            int min = 1;
            int max = valueRef;
            for (int i = 0; i <= valueRef; i++)
            {
                int v = 0;
                if (arr.Any(x => x == 0))
                {
                    do v = random.Next(min, max + 1);
                    while (arr.Contains(v));

                    arr[i] = v;
                    
                    // mettiamo il turbo a questo algoritmo
                    if (arr.Contains(min) && v == min + 1)
                        min = v;
                    if (arr.Contains(max) && v == max - 1)
                        max = v;
                }
            }
            return arr;
        }

    }
}
