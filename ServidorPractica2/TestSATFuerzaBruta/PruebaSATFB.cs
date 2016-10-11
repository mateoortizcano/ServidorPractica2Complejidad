using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TestSATFuerzaBruta
{
    [TestClass]
    public class UnitTest1
    {
        public static bool areEqual(List<int> l1, List<int> l2)
        {
            if (l1.Count != l2.Count) return false;

            for (int i = 0; i < l1.Count; ++i)
            {
                if (l1[i] != l2[i]) return false;
            }
            return true;
        }

        [TestMethod]
        public void TestMethod1()
        {
            List<int> variables = new List<int> { 1, 2 };
            List<List<int>> formula = new List<List<int>> { };
            formula[0] = new List<int> { 1, 2 };
            formula[1] = new List<int> { 2 };
            int fila = 0;
            int clausulas = 2;
            List<int> tienQueDar = new List<int> { 0, 1 };


            var ans = SATFuerzabruta.validar(variables, formula, fila, clausulas);

            //Assert.AreEqual(areEqual(ans, tienQueDar), true);
        }
    }
}
