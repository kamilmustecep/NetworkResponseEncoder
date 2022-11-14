using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace NetworkRequestEncryptor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult _MyReturnPage()
        {
            return PartialView();
        }


        public string _MyReturnPageEncrypte()
        {
            string password = "var=str=18scS91=int";
            string StringHTML = RenderRazorViewToString("~/Views/Home/_MyReturnPage.cshtml");
            APIServicesEncryptDecrypt.Encryptor.ClsCrypto crypter = new APIServicesEncryptDecrypt.Encryptor.ClsCrypto(password);
            string sifreliHTML = crypter.Encrypt(StringHTML);

            return sifreliHTML;
        }

        public string RenderRazorViewToString(string viewName, object model = null)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

    }
}