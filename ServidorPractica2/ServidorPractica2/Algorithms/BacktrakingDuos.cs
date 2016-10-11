using ServidorNP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ControllerGrafo;

namespace ServidorPractica2.Algorithms
{
    public class BacktrakingDuos
    {
        List<List<int>> Grafo;
        int nro_nodos;
        List<int> asignacion;

        public BacktrakingDuos(Grafo grafo)
        {
            Grafo = grafo.grafo;
            nro_nodos = Grafo.Count();
            asignacion = new List<int>();
            for (int i = 0; i < grafo.grafo.Count(); ++i)
            {
                asignacion.Add(-1);
            }
        }

        public int sumatoria()
        {
            int suma = 0;
            for (int i = 0; i < asignacion.Count(); ++i)
            {
                if (asignacion[i] == 1)
                {
                    suma += asignacion[i];
                }
            }
            return suma;
        }

        bool validar()
        {

            for (int i = 0; i < nro_nodos; ++i)
            {
                if (asignacion[i] == 1)
                {
                    continue;
                }
                for (int j = i + 1; j < nro_nodos; ++j)
                {
                    if (asignacion[j] != 1 && Grafo[i][ j] == 1)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int vc()
        {
            int u = -1, v = -1;
            for (int i = 0; i < nro_nodos; ++i)
            {
                for (int j = i + 1; j < nro_nodos; ++j)
                {
                    if (asignacion[i] == -1 && asignacion[j] == -1 && Grafo[i][j] == 1)
                    {
                        u = i;
                        v = j;
                        break;
                    }
                }
                if (u != -1)
                    break;
            }
            if (u == -1)
            {
                if (validar())
                    return sumatoria();
                else
                    return nro_nodos;
            }
            asignacion[u] = 1;
            asignacion[v] = 0;
            int r1 = vc();

            asignacion[u] = 0;
            asignacion[v] = 1;
            int r2 = vc();

            asignacion[u] = 1;
            asignacion[v] = 1;
            int r3 = vc();
            return Math.Min(r1, Math.Min(r2, r3));
        }
        
    }
}