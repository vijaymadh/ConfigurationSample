using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Portable_Area_Test
{
    public class AllowedIPAttribute: ActionFilterAttribute
    {
        //overrinding OnActionExecuting method to check Ip, before any code from Action is executed.
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Retrieve user's IP
            string usersIpAddress = HttpContext.Current.Request.UserHostAddress;
            string remoteIP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            if (!checkIp(usersIpAddress))
            {
                if (!checkIp(remoteIP))
                {
                    //return 403 Forbidden HTTP code
                    filterContext.Result = new HttpStatusCodeResult(403);
                }
            }

            base.OnActionExecuting(filterContext);
        }

        public static bool checkIp(string usersIpAddress)
        {
            //get allowedIps Setting from Web.Config file and remove whitespaces from int
            string allowedIps = "127.0.0.1";// ConfigurationManager.AppSettings["allowedIPs"].Replace(" ", "").Trim();


            //convert allowedIPs string to table by exploding string with ';' delimiter
            string[] ips = allowedIps.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            //iterate ips table
            foreach (var ip in ips)
            {
                if (ip.Equals(usersIpAddress))
                    return true; //return true confirming that user's address is allowed
            }

            //if we get to this point, that means that user's address is not allowed, therefore returning false
            return false;

        }
    }
}
