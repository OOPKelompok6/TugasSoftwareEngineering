using Leren1.Models;
using Leren1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Leren1.Pages
{
    public partial class ArticleTemplate : System.Web.UI.Page
    {
        List<ArticleObjectPool> pageObjects;
        protected void Page_Load(object sender, EventArgs e)
        {
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            String ArticleID = Request["ID"];
            String title = (from d in db.ArticleHeaders where d.ArticleID == ArticleID select d.ArticleTitle).FirstOrDefault().ToString();
            pageObjects = (from o in db.ArticleObjectPools orderby o.BuildOrder where o.ArticleID == ArticleID select o).ToList();
            int Sections = Convert.ToInt32(Request["Sections"]);

            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.Attributes["class"] = "d-flex flex-column align-items-center top-0";
            mainDiv.ID = "mainContainer";
            DynamicContentPanel.Controls.Add(mainDiv);

            HtmlGenericControl titleContainer = new HtmlGenericControl("div");
            titleContainer.ID = "titleContainer";
            HtmlGenericControl mainTitle = new HtmlGenericControl("h1");
            mainTitle.Attributes["class"] = "alatsi-regular my-5";
            mainTitle.InnerHtml = title;
            titleContainer.Controls.Add(mainTitle);
            this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(titleContainer);

            for (int i = 0; i < Sections; i++)
            {
                populateSidebar(i);
                if (pageObjects[i].ObjectType == 1)
                {
                    this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(DynObjectText(i));
                }
                else if (pageObjects[i].ObjectType == 2)
                {
                    this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(DynObjectImage(i));
                }
                else if (pageObjects[i].ObjectType == 3)
                {
                    this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(DynObjectVideo(i));
                }

                if (pageObjects[i].IsPageBreak == 1)
                {
                    this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(createSectionBreak());
                }
            }
            
        }

        private HtmlGenericControl DynObjectVideo(int i)
        {
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            HtmlGenericControl dynamicVid = new HtmlGenericControl("iframe");

            dynamicDiv.Attributes["class"] = "ratio ratio-16x9 col-sm-7 my-4";
            dynamicVid.Attributes["height"] = "100%";
            dynamicVid.Attributes["width"] = "100%";
            dynamicVid.Attributes["src"] = pageObjects[i].ContentString;
            dynamicVid.Attributes["allowfullscreen"] = "allowfullscreen";
            dynamicDiv.Controls.Add(dynamicVid);

            return dynamicDiv;
        }

        private HtmlGenericControl DynObjectImage(int i)
        {
            HtmlGenericControl dynamicCon = new HtmlGenericControl("div");
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            HtmlGenericControl dynamicImg = new HtmlGenericControl("img");

            dynamicCon.Attributes["class"] = "col-sm-7 d-flex my-4";
            dynamicDiv.Attributes["class"] = "mx-auto";
            dynamicImg.Attributes["class"] = "img-fluid object-fit-contain";
            dynamicImg.Attributes["src"] = pageObjects[i].ContentString;
            dynamicDiv.Controls.Add(dynamicImg);
            dynamicCon.Controls.Add(dynamicDiv);

            return dynamicCon;
        }

        private HtmlGenericControl DynObjectText(int i)
        {
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");

            dynamicDiv.Attributes["class"] = "col-sm-7 text-wrap text-break text-start alatsi-regular fs-6 my-4 alatsi-regular";
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("**t**", "<h3>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("^^t^^", "</h3>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("**p**", "<p>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("^^p^^", "</p>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("**b**", "<b>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("^^b^^", "</b>");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("**math-dsp**", "\\[");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("^^math-dsp^^", "\\]");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("**math-inl**", "\\(");
            pageObjects[i].ContentString = pageObjects[i].ContentString.Replace("^^math-inl^^", "\\)");
            dynamicDiv.InnerHtml = pageObjects[i].ContentString;

            return dynamicDiv;
        }

        private void populateSidebar(int i)
        {
            HtmlGenericControl sidebarItems = new HtmlGenericControl("a");
            sidebarItems.Attributes["class"] = "nav-link alatsi-regular align-self-center";
            sidebarItems.Attributes["href"] = "#item-" + Convert.ToString(i + 1);
            sidebarItems.InnerHtml = "Section " + Convert.ToString(i + 1);
            this.Master.FindControl("ContentPlaceHolder1").FindControl("secDiv").Controls.Add(sidebarItems);

            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            dynamicDiv.Attributes["id"] = "item-" + Convert.ToString(i + 1);
            dynamicDiv.Attributes["style"] = "display: hidden;";
            this.Master.FindControl("ContentPlaceHolder1").FindControl("DynamicContentPanel").FindControl("mainContainer").Controls.Add(dynamicDiv);
        }

        private HtmlGenericControl createSectionBreak()
        {
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            dynamicDiv.Attributes["class"] = "col-sm-7 mx-auto my-3";
            HtmlGenericControl dynamicLine = new HtmlGenericControl("hr");
            dynamicLine.Attributes["class"] = "border-2 border-dark";
            dynamicDiv.Controls.Add(dynamicLine);
            
            return dynamicDiv;
        }
    }
}