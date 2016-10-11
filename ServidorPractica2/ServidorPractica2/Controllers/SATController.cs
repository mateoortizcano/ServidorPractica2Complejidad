using ALGORIHTMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ServidorNP.Controllers
{
    public class SATController : Controller
    {
        // GET: SAT
        public ActionResult SATFuerzabruta(string json)
        {
            DatosSAT SAT = new JavaScriptSerializer().Deserialize<DatosSAT>(json);
            SATFuerzabruta Sat = new SATFuerzabruta(SAT);
            List<int> estados = Sat.validar();
            return Json(estados, JsonRequestBehavior.AllowGet);            
        }
    }
}