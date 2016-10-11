using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorNP.Controllers
{
    public class DatosSAT
    {
        public List<List<int>> formula;
        public List<int> variables;
        public int nro_clausulas;

        public DatosSAT()
        {
        }
        public DatosSAT(List<List<int>> formu, List<int> variab, int clausu)
        {
            formula = formu;
            variables = variab;
            nro_clausulas = clausu;
        }
    }
}