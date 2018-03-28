using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace DataAccessLayer
{
    public class WebLinks
    {
        private readonly IWebSiteAddress _url;
        private readonly IFetchWebSource _statusCode;

        private HtmlWeb _web         = new HtmlWeb();
        private HttpStatusCode _code = HttpStatusCode.OK;


        public WebLinks(IWebSiteAddress url)
        {
            _url = url;
            _statusCode = new FetchWebsite(_url);


        }


        public List<string> ReturnStartUrls()
        {
            var urlNodes = new List<string>();

            if(_statusCode.StatusCode().Equals(_code))
            {
               var htmlDocument =  _web.Load(_url.Url());
                var nodes = htmlDocument.DocumentNode.SelectNodes("//a[@href]");

                foreach (var node in nodes)
                {
                    if (node.Attributes["href"].Value.StartsWith("/") && !node.Attributes["href"].Value.Contains("#"))
                    {

                       urlNodes.Add(_url.Url() + node.Attributes["href"].Value);
                    }
                }
                
            }
            return urlNodes;
        }


    }
}
