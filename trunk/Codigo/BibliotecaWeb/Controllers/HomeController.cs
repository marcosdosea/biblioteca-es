using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaWeb.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ServiceTemperatura.TempConvertSoapClient conversor = new ServiceTemperatura.TempConvertSoapClient();
            string temperaturaResultado = conversor.FahrenheitToCelsius("100");


            ServiceCalculadora.WebServiceCalculadoraSoapClient calculadora = new ServiceCalculadora.WebServiceCalculadoraSoapClient();

            int resultado = calculadora.Soma(2, 4);

            ViewBag.Message = "Welcome to ASP.NET MVC! A temperatura atual é "+ temperaturaResultado;
            return View();
        }

        [Authorize(Roles = "bibliotecario, balconista")]
        public ActionResult About()
        {
            return View();
        }
    }
}
