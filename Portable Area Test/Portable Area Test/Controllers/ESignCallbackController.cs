using System.Web.Mvc;

namespace Portable_Area_Test.Controllers
{
    public class ESignCallBackController:System.Web.Mvc.Controller
    {
        [HttpGet]
        [AllowedIP]
        public ActionResult EchoSignCallBack(string documentKey, string status, string eventType)
        {
            return View("Index");
        }
    }
}
