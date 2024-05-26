using Leren1.Models;
using Leren1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Leren1.WebService
{
    /// <summary>
    /// Summary description for simpleWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class simpleWebService : System.Web.Services.WebService
    {

        //[System.Web.Script.Services.ScriptMethod]
        [WebMethod]
        [ScriptMethod(UseHttpGet = false)]
        public List<String> GetSuggestions(String curText)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            return (from gS in db.ArticleHeaders where gS.ArticleTitle.Contains(curText) select gS.ArticleTitle).ToList();
        }
    }
}
