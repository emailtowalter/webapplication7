using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyServiceReference1;
using System.ServiceModel;
using System.IO;

namespace WebApplication6.Controllers
{
    [Route("[controller]")]
    public class WCFTestController : Controller
    {
        [HttpGet("{id}")]
        public string  Index(int id)
        {
            Service1Client proxy = new Service1Client();
            //oauth 
            
            //var factory = new ChannelFactory<>();
            //factory.Credentials.ClientCertificate.Certificate = new X509Certificate2();

            //proxy.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2();

            string result = proxy.GetDataAsync(id).Result;

            return result;
        }
    }
}