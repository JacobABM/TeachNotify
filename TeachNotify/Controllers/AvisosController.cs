using System.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace TeachNotify.Controllers
{
    public class AvisosController : Controller
    {

        #region Views
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IniciarSesion()
        {
            return View();
        }
        #endregion

        #region Helper Methods
        public static string GetUrlPart(string[] url, int position)
        {
            return url.Length >= position + 1 ? url[position].ToString() : "";
        }

        #endregion

    }

}
