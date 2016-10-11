using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ALGORITHMSVCT;
using System.Collections.Generic;

namespace TestVCTrios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<List<int>> Vertex = new List<List<int>>();
            Vertex.Add(new List<int> {0,1,1,1,0 });
            Vertex.Add(new List<int> { 1,0,1,0,0});
            Vertex.Add(new List<int> { 1,1,0,1,0 });
            Vertex.Add(new List<int> { 1,0,1,0,1});
            Vertex.Add(new List<int> { 0,0,0,1,0});
            BacktrakingTriple VC = new BacktrakingTriple(Vertex);
            int ans = 3;

            var DebeDar = VC.vertexC();

            Assert.AreEqual(ans,DebeDar);
        }
    }
}
