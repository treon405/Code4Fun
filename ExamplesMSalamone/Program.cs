using Examples.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamplesMSalamone
{
    class Program
    {
        static void Main(string[] args)
        {
            _ValueRequested = -1;
            while (_ValueRequested != 0)
            {
                SelectOption();
                if (_ValueRequested == -1)
                    continue;
                else if (_ValueRequested == 0)
                    return;

                // Execute calculate 
                int[] result = CalcManager.Calculate(_ValueRequested, _MethodRequested); 

                // Output response 
                if (_MethodRequested == MethodType.Random)
                {
                    string textToOut = "";
                    foreach (var i in result)
                        textToOut += string.Format("{0};", i); 

                    Console.Write(string.Format("\r\n\r\n Array with n={0} integer with random values", _ValueRequested));
                    Console.Write("\r\n arr[n] = " + textToOut);
                    Console.ReadKey();
                }
                else
                {
                    Console.Write(string.Format("\r\n\r\n Sum of {0} up to {1} = {2}", _MethodRequested, _ValueRequested, result.First()));
                    Console.ReadKey();
                }
            }

            Console.ReadKey();
        }


        private static int _ValueRequested = 0;
        private static MethodType _MethodRequested = MethodType.None;

        private static void SelectOption()
        {
            Console.Clear();
            Console.Write(" ---------------------------------------------\r\n");
            Console.Write(" Example by M.Salamone\r\n");
            Console.Write(" ---------------------------------------------\r\n");
            Console.Write(" Choose an option: \r\n [A] = Sum of multiple of 3 up to 1000\r\n [B] = Sum of multiple of 5 up to 1000\r\n [C] = Sum of multiple of 3 and 5 up to 1000\r\n [D] = Calculate an array[n] with (n) integer with random values\r\n [0] = Exit\r\n\r\n");
            Console.Write(" Digitare opzione di calcolo :");
            string key = Console.ReadLine().ToUpper();
            int inpValue = 0;
            if (key == "A" || key == "B" || key == "C")
            {
                Console.Write("\r\n Insert threshold value (default=1000) :");
                string v = Console.ReadLine();
                if (string.IsNullOrEmpty(v))
                    v = "1000"; 

                bool resOk = int.TryParse(v, out inpValue);
                if (resOk)
                    _ValueRequested = inpValue;
                else
                {
                    Console.Write("\r\n Invalid value! Insert an integer value\r\n\r\n Press any key!");
                    Console.ReadKey(); 
                    _ValueRequested = -1;
                }
                switch (key)
                {
                    case "A":
                        _MethodRequested = MethodType.MultipleOf3;
                        break;
                    case "B":
                        _MethodRequested = MethodType.MultipleOf5;
                        break;
                    case "C":
                        _MethodRequested = MethodType.MultipleOf3And5;
                        break;
                }
            }
            else if (key == "D")
            {
                _MethodRequested = MethodType.Random;
                Console.Write("\r\n Insert items number of array (default=10) :");
                string v = Console.ReadLine();
                if (string.IsNullOrEmpty(v))
                    v = "10"; 

                bool resOk = int.TryParse(v, out inpValue);
                if (resOk)
                    _ValueRequested = inpValue;
                else 
                {
                    Console.Write("\r\n Invalid value! Insert an integer value\r\n\r\n Press any key!");
                    Console.ReadKey(); 
                    _ValueRequested = -1;
                }
            }
            else if (key == "0")
            {
                _MethodRequested = MethodType.None;
                _ValueRequested = 0;
            }
            else
            {
                _MethodRequested = MethodType.None;
                _ValueRequested = -1;
                Console.Write("\r\n Invalid option! Use only available option: A, B, C, D, 0 \r\n\r\n Press any key");
                Console.ReadKey(); 
            }
        }
    }
}
