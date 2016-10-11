using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGORIHTMS;

namespace TestSATFB
{
    [TestClass]
    public class TestSatFB
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
            List<List<int>> formula = new List<List<int>>();
            formula.Add(new List<int> { 1, 2 });
            formula.Add(new List<int> { 2 });
            int clausulas = 2;
            List<int> tienQueDar = new List<int> { 0, 1 };

            SATFuerzabruta sat = new SATFuerzabruta(formula, variables, clausulas);
            var ans = sat.validar();

            Assert.AreEqual(areEqual(ans, tienQueDar), true);
        }
    }
}
