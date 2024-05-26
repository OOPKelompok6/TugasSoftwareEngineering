using Leren1.Models;
using Leren1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Leren1.Pages
{
    public partial class SearchTemplate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            String searchTerm = Request["searchTerm"];
            List<ArticleHeader> articles = (from aS in db.ArticleHeaders where aS.ArticleTitle.Contains(searchTerm) select aS).ToList();


            HtmlGenericControl mainContainer = new HtmlGenericControl("div");
            mainContainer.Attributes["class"] = "col-sm-8 d-flex flex-column";
            foreach (ArticleHeader article in articles)
            {
                createResultItems(article, mainContainer, db);
            }
            Results.Controls.Add(mainContainer);
        }

        private void createResultItems(ArticleHeader article, HtmlGenericControl mainContainer, DatabaseEntities1 db)
        {

            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            dynamicDiv.Attributes["class"] = "d-flex flex-column my-4 bg-info rounded";
            HtmlGenericControl link = new HtmlGenericControl("a");
            link.InnerHtml = article.ArticleTitle;
            link.Attributes["href"] = "ArticleTemplate.aspx?ID=" + article.ArticleID + "&Sections=" + article.Sections;
            link.Attributes["class"] = "my-3 mx-2 me-auto alatsi-regular";
            dynamicDiv.Controls.Add(link);

            String curDesc = (from d in db.ArticleObjectPools where (d.ArticleID == article.ArticleID) && (d.ObjectType == 1) select d.ContentString).FirstOrDefault().ToString();
            curDesc = curDesc.Trim();
            curDesc = removeFormatting(curDesc);

            if(curDesc.Length > 200)
            {
                curDesc = curDesc.Remove(199, curDesc.Length - 200);
            }
            curDesc = curDesc + "...";

            HtmlGenericControl descPar = new HtmlGenericControl("p");
            descPar.InnerHtml = curDesc;
            descPar.Attributes["class"] = "text-wrap mx-2 alatsi-regular";
            dynamicDiv.Controls.Add(descPar);

            mainContainer.Controls.Add(dynamicDiv);
        }

        private String removeFormatting(String curDesc)
        {
            String[] formatStrings = {"**p**", "^^p^^", "**t**", "^^t^^", "**b**", "^^b^^", "**math-dsp**", "^^math-dsp^^", "**math-inl**", "^^math-inl^^"};
            foreach (String str in formatStrings)
            {
                if(str.Equals("**math-dsp**"))
                {
                    curDesc = curDesc.Replace(str, "\\(");
                }
                else if(str.Equals("^^math-dsp^^"))
                {
                    curDesc = curDesc.Replace(str, "\\)");
                }
                else if (str.Equals("**math-inl**"))
                {
                    curDesc = curDesc.Replace(str, "\\(");
                }
                else if (str.Equals("^^math-inl^^"))
                {
                    curDesc = curDesc.Replace(str, "\\)");
                }
                else
                {
                    curDesc = curDesc.Replace(str, "");
                }
            }

            return curDesc;
        }

    }
}