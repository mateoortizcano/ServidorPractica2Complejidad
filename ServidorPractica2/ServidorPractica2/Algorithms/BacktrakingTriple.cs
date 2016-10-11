using ServidorNP.Controllers;
using ControllerGrafo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALGORITHMSVCT
{
    public class BacktrakingTriple
    {
        List<List<int>> Grafo;
        int nro_nodos;
        List<int> asignacion;

        public BacktrakingTriple(Grafo grafo)
        {
            Grafo = grafo.grafo;
            nro_nodos = Grafo.Count();
            asignacion = new List<int>();     
            for (int i = 0; i < grafo.grafo.Count(); ++i)
            {
                asignacion.Add(-1);
            }
        }

        public BacktrakingTriple(List<List<int>> Grafo1)
        {
            Grafo = Grafo1;
            nro_nodos = Grafo.Count();
            asignacion = new List<int>();
            for (int i = 0; i < Grafo1.Count(); ++i)
            {
                asignacion.Add(-1);
            }
        }

        public void setAsignacion(List<int> a)
        {
            this.asignacion = a;
        }

        public bool validar()
        {
            for (int i = 0; i < nro_nodos; ++i)
            {
                if (asignacion[i] == 1)
                {
                    continue;
                }
                for (int j = i+1; j < nro_nodos; ++j)
                {
                    if (asignacion[j] != 1 && Grafo[i][j] == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int vertexC()
        {
            int u = -1, v = -1, w = -1;
            for (int i = 0; i < nro_nodos; ++i)
            {
                for (int j = i+1; j < nro_nodos; ++j)
                {
                    for (int k = j+1; k < nro_nodos; ++k)
                    {
                        if (asignacion[i] == -1 && asignacion[j] == -1 && asignacion[k] == -1)
                        {
                            if ((Grafo[i][j] == 1 && Grafo[j][k] == 1) || (Grafo[i][j] == 1 && Grafo[i][k] == 1) || (Grafo[j][k] == 1 && Grafo[i][k] == 1))
                            {
                                u = i;
                                v = j;
                                w = k;
                                break;
                            }
                        }
                    }
                    if (w != -1)
                    {
                        break;
                    }
                }
                if (w != -1)
                {
                    break;
                }
            }
            if (w == -1)
            {
                if (validar())
                {                    
                    int sum = 0;
                    for (int i = 0; i < nro_nodos; ++i)
                    {
                        if (asignacion[i] == 1)
                        {
                            sum += asignacion[i];
                        }
                    }
                    return sum;                    
                }
                else
                    return nro_nodos;
            }
            asignacion[u] = 1;
            asignacion[v] = 0;
            asignacion[w] = 1;
            int r1 = vertexC();

            asignacion[u] = 0;
            asignacion[v] = 1;
            asignacion[w] = 0;
            int r2 = vertexC();
            int min1 = Math.Min(r1, r2);

            asignacion[u] = 1;
            asignacion[v] = 1;
            asignacion[w] = 0;
            int r3 = vertexC();

            asignacion[u] = 0;
            asignacion[v] = 1;
            asignacion[w] = 1;
            int r4 = vertexC();
            int min2 = Math.Min(r3, r4);
            int min3 = Math.Min(min1, min2);

            asignacion[u] = 1;
            asignacion[v] = 1;
            asignacion[w] = 1;
            int r5 = vertexC();

            return Math.Min(r5, min3);
        }
    }
}