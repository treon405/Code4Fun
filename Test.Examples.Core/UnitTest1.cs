using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examples.Core;
using System.Linq; 
using System.Collections.Generic; 

namespace Test.Examples.Core
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_SumOfMultipleOf3_Threshold10()
        {
            // somma dei multipli di 3 fino a 10. Il numero primo non lo prendo in esame in quanto si richiede la somma dei soli multipli 
            // 1 2 (3) 4 5 [6] 7 8 [9] 10       = 15 
            int threshold = 10; 
            int correctValue = 15;

            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf3).First();

            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result); 
        }
        [TestMethod]
        public void Test_SumOfMultipleOf3_Threshold25()
        {
            // somma dei multipli di 3 fino a 25. Il numero primo non lo prendo in esame in quanto si richiede la somma dei soli multipli 
            // 1 2 (3) 4 5 [6] 7 8 [9] 10 11 [12] 13 14 [15] 16 17 [18] 19 20 [21] 22 23 [24] 25       = 105 
            int threshold = 25;
            int correctValue = 105;
            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf3).First(); 

            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result);
        }

        [TestMethod]
        public void Test_SumOfMultipleOf5_Threshold10()
        {
            // somma dei multipli di 5 fino a 10. Il numero primo non lo prendo in esame in quanto si richiede la somma dei soli multipli 
            // 1 2 3 4 (5) 6 7 8 9 [10]       = 10 
            int threshold = 10;
            int correctValue = 10;
            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf5).First();
            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result);
        }
        [TestMethod]
        public void Test_SumOfMultipleOf5_Threshold25()
        {
            // somma dei multipli di 5 fino a 125. Il numero primo non lo prendo in esame in quanto si richiede la somma dei soli multipli 
            // 1 2 3 4 (5) 6 7 8 9 [10] 11 12 13 14 [15] 16 17 18 19 [20] 21 22 23 24 [25]       = 70
            int threshold = 25;
            int correctValue = 70;
            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf5).First();
            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result);
        }

        [TestMethod]
        public void Test_SumOfMultipleOf3And5_Threshold10()
        {
            int threshold = 10;
            int correctValue = 25;
            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf3And5).First();
            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result);
        }
        [TestMethod]
        public void Test_SumOfMultipleOf3And5_Threshold25()
        {
            int threshold = 25;
            int correctValue = 175;
            int result = CalcManager.Calculate(threshold, MethodType.MultipleOf3And5).First();
            Assert.AreEqual(correctValue, result, "Valore calcolato non valido R:" + result);
        }

        [TestMethod]
        public void Test_ArrayItemsCount_10()
        {
            int items = 10;
            int[] arr = CalcManager.Calculate(items, MethodType.Random);
            int result = arr.Length; 
            Assert.AreEqual(items, result, "Numero di elementi calcolati :" + result);
        }
        [TestMethod]
        public void Test_ArrayItemsCount_50()
        {
            int items = 50;
            int[] arr = CalcManager.Calculate(items, MethodType.Random);
            int result = arr.Length;
            Assert.AreEqual(items, result, "Numero di elementi calcolati :" + result);
        }
        [TestMethod]
        public void Test_ArrayItemsCount_100()
        {
            int items = 100;
            int[] arr = CalcManager.Calculate(items, MethodType.Random);
            int result = arr.Length;
            Assert.AreEqual(items, result, "Numero di elementi calcolati :" + result);
        }
        [TestMethod]
        public void Test_ArrayItemsVerifyValues_500()
        {
            // generando un array di elementi random con 500 items verifico la presenza di doppioni 
            int items = 500;
            int[] arr = CalcManager.Calculate(items, MethodType.Random);

            var res = (from i in arr
                       group i by i into g
                       select new { Num = g.Key, Cnt = g.Count() }).ToList();
            int doppi = res.Where(x => x.Cnt > 1).Count(); 
            Assert.AreEqual(0, doppi, "Trovati numeri doppioni:" + doppi);
        }

    }
}
