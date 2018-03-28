using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FetchWebsite : IFetchWebSource
    {
        private readonly IWebSiteAddress _webUrl;
        private WebResponse _response;




        public FetchWebsite(IWebSiteAddress webUrl)
        {
            _webUrl = webUrl;
           
        }

        public HttpStatusCode StatusCode()
        {
           
            var request = WebRequest.Create(_webUrl.Url());
            _response = request.GetResponse();
            var statusCode = ((HttpWebResponse)_response).StatusCode;

            return statusCode;
        }

       
    }
}
