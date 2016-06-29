using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6
{
    public class SamlToken
    {
        string m_samlStrToken;
        System.Xml.XmlDocument m_samlXmlDoc;

        public string Status { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public SamlToken(string token)
        {
            m_samlStrToken = token;

            m_samlXmlDoc = new System.Xml.XmlDocument();

            m_samlXmlDoc.LoadXml(token);
            setStatus();
            setProperties();
        }

        public static class SamlTokenStatus
        {
            public static string Success = "urn:oasis:names:tc:SAML:2.0:status:Success";
            public static string Requester = "urn:oasis:names:tc:SAML:2.0:status:Requester";
            public static string Responder = "urn:oasis:names:tc:SAML:2.0:status:Responder";
            public static string VersionMismatch = "urn:oasis:names:tc:SAML:2.0:status:VersionMismatch";
        }
        private void setStatus()
        {
            string str = m_samlXmlDoc.DocumentElement["samlp:Status"]["samlp:StatusCode"].GetAttribute("Value");

            Status = str;            
        }

        private void setProperties()
        {
            Properties = new Dictionary<string, string>();
            string str = m_samlXmlDoc.DocumentElement["saml:Assertion"]["saml:Subject"]["saml:NameID"].InnerText;
            Properties.Add("NameID", str);
        }

        private void checkSigniture()
        {
           // var signedXml = new SignedXml();

        }



    }
}
