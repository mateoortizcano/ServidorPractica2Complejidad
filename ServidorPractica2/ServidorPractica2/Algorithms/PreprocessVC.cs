using ControllerGrafo;
using ALGORITHMSVCT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNP.Algorithms
{
    public class PreprocessVC
    {
        List<List<int>> grafo;
        List<List<int>> grafo2;
        List<int> asignacion;
        int nro_nodos;
        public PreprocessVC(Grafo g)
        {
            grafo = g.grafo;
            grafo2 = g.grafo;
            asignacion = new List<int>();
            for (int i = 0; i < g.grafo.Count(); ++i)
            {
                asignacion.Add(-1);
            }
            nro_nodos = g.grafo.Count();
        }
        public int preprocesar()
        {
            int posj = 0;
            for (int i = 0; i < nro_nodos; ++i)
            {
                int nro_vecinos = 0;
                for (int j = 0; j < nro_nodos; ++j)
                {
                    if (grafo[i][j] == 1)
                    {
                        nro_vecinos++;
                        posj = j;
                        if (nro_vecinos > 1) break;
                    }
                }
                if (nro_vecinos == 1)
                {
                    asignacion[posj] = 1;
                    grafo2[i][posj] = 0;
                    grafo2[posj][i] = 0;
                }
            }
            Grafo g = new Grafo(grafo2);
            BacktrakingTriple VC = new BacktrakingTriple(g);
            VC.setAsignacion(asignacion);
            int ans = VC.vertexC();
            return ans;
        }
    }
}