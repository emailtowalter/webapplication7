using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication6.Controllers
{
    public class SamlController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        StringValues m_samlResponse;
        string m_samlDecodedResponse;

        public IActionResult Result()
        {
            // Check if saml token is provide..., if so, security check , referrer, and signiture. 

            if (!Request.Form.TryGetValue("SAMLResponse", out m_samlResponse) && 
                !String.IsNullOrEmpty(m_samlResponse))
            {
                ViewBag.HasSaml = false;
            }else
            {
                //decode base64
                ViewBag.HasSaml = true;
                byte[] data = Convert.FromBase64String(m_samlResponse);
                string decodedString = Encoding.UTF8.GetString(data);
                ViewBag.SamlToken = decodedString;
                SamlToken token = new SamlToken(decodedString);
                ViewBag.TokenStatus = token.Status;
            }

            //If the check failed, or not presented, redirect to login module; 
            // else get user info, and create principle and policy for authorization step;





            return View();
        }
    }
}
