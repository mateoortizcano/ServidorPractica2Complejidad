using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNP.Controllers
{
    public class Grafo
    {
        public List<List<int>> grafo = new List<List<int>>();
        public Grafo()
        {            
        }

        public Grafo(List<List<int>> g)
        {
            grafo = g;
        }
        public void llenar()
        {
            for (int i = 0; i < 15; ++i)
            {
                List<int> internallist = new List<int>();
                for (int j = 0; j < 15; ++j)
                {
                    internallist.Add(j + 1);
                }
                grafo.Add(internallist);
            }
        }
    }
}