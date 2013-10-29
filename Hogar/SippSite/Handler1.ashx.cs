using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;

namespace SippSite
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var doc = new XmlDocument();
            var node = doc.CreateElement("available-cards");
            foreach (var fullPath in Directory.GetFiles(context.Server.MapPath("."),"sipp_*.xml"))
            {
                string filename = Path.GetFileName(fullPath);
                var card = doc.CreateElement("card");
                card.SetAttribute("filename", filename);
                node.AppendChild(card);
            }
            doc.AppendChild(node);
           
            context.Response.Write(@"<?xml version='1.0' encoding='UTF-8' ?>");
            context.Response.Write(doc.OuterXml);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}