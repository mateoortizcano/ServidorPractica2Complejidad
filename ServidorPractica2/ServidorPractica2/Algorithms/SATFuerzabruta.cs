﻿using ServidorNP.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNP.Algorithms
{
    public class SATFuerzabruta
    {
        List<List<int>> formula;
        List<int> variables;
        int nro_clausulas;
        int[,] estados = new int[100, 100];
        int fila = 0;

        public SATFuerzabruta(DatosSAT sat)
        {
            formula = sat.formula;
            variables = sat.variables;
            nro_clausulas = sat.nro_clausulas;
        }
        public  void generar()
        {
            for (int i = 1; i <= variables.Count(); ++i)
            {
                for (int j = 1; j <= Math.Pow(2, variables.Count()); ++j)
                {
                    if (i == 1)
                    {
                        estados[j, i] = (j % 2);
                        continue;
                    }
                    if ((j / (int)(Math.Pow(2, i) / 2)) % 2 == 0)
                        estados[j, i] = 1;
                    else
                        estados[j, i] = 0;
                }
            }

        }

        public List<int> validar()
        {
            generar();
            for (int i = 1; i <= Math.Pow(2, variables.Count()); ++i)
            {
                int cont = 0;
                for (int a = 0; a < nro_clausulas; ++a)
                {
                    for (int s = 0; s < formula[a].Count; ++s)
                    {
                        if (formula[a][s] > 0 && estados[i, Math.Abs(formula[a][s])] == 1)
                        {
                            ++cont;
                            break;
                        }
                        if (formula[a][s] < 0 && estados[i, Math.Abs(formula[a][s])] == 0)
                        {
                            ++cont;
                            break;
                        }
                    }
                }
                if (cont == nro_clausulas)
                {
                    fila = i;
                }
            }
            List<int> retornoEstado = new List<int>();
            for (int i = 1; i <= variables.Count; ++i)
            {
                retornoEstado.Add(estados[fila, i]);                
            }
            return retornoEstado;
        }
    }
}