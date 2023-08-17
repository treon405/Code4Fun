using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Core
{
    public static class CalcManager
    {

        static public int[] Calculate(int value, MethodType methodType)
        {
            switch (methodType)
            {
                case MethodType.MultipleOf3:
                    return new Multiple3().Calculate(value);

                case MethodType.MultipleOf5:
                    return new Multiple5().Calculate(value);

                case MethodType.MultipleOf3And5:
                    int s3 = new Multiple3().Calculate(value).First();
                    int s5 = new Multiple5().Calculate(value).First();
                    return new int[] { s3 + s5 }; 

                case MethodType.Random:
                    return new ArrayRandom().Calculate(value); 

                default:
                    return new int[] { 0 };
            }
        }
    }

}
