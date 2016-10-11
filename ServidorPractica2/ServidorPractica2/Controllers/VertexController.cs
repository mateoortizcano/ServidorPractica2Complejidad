using ServidorNP.Algorithms;
using ALGORITHMSVCT;
using ControllerGrafo;
using ServidorPractica2.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ServidorNP.Controllers
{
    public class VertexController : Controller
    {
        // GET: BacktrackingTrios
        public ActionResult Index()
        {
            Grafo grafo = new Grafo();
            grafo.llenar();
            return Json(grafo, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VCBacktrTrios(string json)
        {
            Grafo grafo = new JavaScriptSerializer().Deserialize<Grafo>(json);
            BacktrakingTriple Vc = new BacktrakingTriple(grafo);            
            int answ=Vc.vertexC();       
            return Json(answ, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VCFuerzaBruta(string json)
        {
            Grafo grafo = new JavaScriptSerializer().Deserialize<Grafo>(json);
            VCFuerzaBruta Vc = new VCFuerzaBruta(grafo);
            int answ = Vc.VC();
            return Json(answ, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VCPreprocesado(string json)
        {
            Grafo grafo = new JavaScriptSerializer().Deserialize<Grafo>(json);
            PreprocessVC Vc = new PreprocessVC(grafo);
            int answ = Vc.preprocesar();
            return Json(answ, JsonRequestBehavior.AllowGet);
        }
        public ActionResult VCBacktrDuos(string json)
        {
            Grafo grafo = new JavaScriptSerializer().Deserialize<Grafo>(json);
            BacktrakingDuos Vc = new BacktrakingDuos(grafo);
            int answ = Vc.vc();
            return Json(answ, JsonRequestBehavior.AllowGet);
        }
    }
}