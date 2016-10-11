using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServidorNP.Controllers;

namespace ServidorNP.Algorithms
{
    public class VCFuerzaBruta
    {
        int nro_nodos;
        List<List<int>> grafo;
        List<List<int>> asignaciones;
        public VCFuerzaBruta(Grafo g)
        {
            grafo = g.grafo;
            nro_nodos = grafo.Count();
            asignaciones = new List<List<int>>();
        }                        
        public int VC()
        {
            int factor = 1;
            double a = Math.Pow(2, nro_nodos);
            for(int i = 0; i < nro_nodos; ++i)
            {
                List<int> asignacion = new List<int>();
                int var = 0, cont = 0;
                for(int j = 0; j < a; ++j)
                {
                    asignacion.Add(var);
                    cont++;
                    if (cont == factor)
                    {
                        if (var == 1)
                            var = 0;
                        else
                            var = 1;
                        cont = 0;
                    }
                }
                factor = factor * 2;
                asignaciones.Add(asignacion);
            }
            int NmaxNodos = nro_nodos, vertex = 0;
            for (int i = 0; i < a; ++i)
            {
                int nodos = 0, band = 1;
                for (int f = 0; f < nro_nodos; ++f)
                {
                    if (asignaciones[f][i] == 1)
                    {
                        nodos++;
                        continue;
                    }
                    for (int c = f + 1; c < nro_nodos; ++c)
                    {
                        if (grafo[f][c] == 1)
                        {
                            if (asignaciones[c][i] == 0)
                            {
                                c = nro_nodos;
                                f = nro_nodos;
                                band = 0;
                            }
                        }
                    }
                }
                if (nodos < NmaxNodos && band == 1)
                {
                    NmaxNodos = nodos;
                    vertex = i;
                }
            }
            return NmaxNodos;
        }        
    }
}