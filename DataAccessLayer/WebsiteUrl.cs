using DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class WebsiteUrl : IWebSiteAddress
    {
        public string Url() => "https://hirespace.com";
        
    }
}
