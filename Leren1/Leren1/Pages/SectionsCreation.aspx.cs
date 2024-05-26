using Leren1.Models;
using Leren1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Leren1.Pages
{
    public partial class SectionsCreation : System.Web.UI.Page
    {
        private static String Titles;
        private static String ArticleID;
        private static String Category;
        private static String Subject;
        private static int Sections;
        private static int IsUpdate;
        private static List<ArticleObjectPool> curObjPool = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Titles = Request["Title"];
            Category = Request["Category"];
            Subject = Request["Subject"];
            ArticleID = Request["ID"];
            Sections = Convert.ToInt32(Request["Sections"]);
            IsUpdate = Convert.ToInt32(Request["IsUpdate"]);

            if(IsUpdate == 1)
            {
                DatabaseEntities1 db = DatabaseSingleton.GetInstance();
                curObjPool = (from o in db.ArticleObjectPools orderby o.BuildOrder where o.ArticleID == ArticleID select o).ToList();
            }

            CreateTitle();

            for (int i = 1; i <= Sections; i++)
            {
                CreateDynamicForm(i);
            }
        }

        private void CreateTitle()
        {
            HtmlGenericControl mainDiv = new HtmlGenericControl("div");
            mainDiv.ID = "mainDiv";
            mainDiv.Attributes["class"] = "d-flex flex-column flex-grow align-items-center";
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            dynamicDiv.ID = "ArticleContatiner";
            dynamicDiv.Attributes["class"] = "my-3";
            HtmlGenericControl titleHeader = new HtmlGenericControl("h1");
            titleHeader.InnerHtml = Titles;
            dynamicDiv.Controls.Add(titleHeader);
            mainDiv.Controls.Add(dynamicDiv);
            DynamicContentHandler.Controls.Add(mainDiv);
        }

        private void CreateDynamicForm(int Counter)
        {
            HtmlGenericControl dynamicDiv = new HtmlGenericControl("div");
            dynamicDiv.ID = "dynamicDiv" + Counter;
            dynamicDiv.Attributes["class"] = "mx-auto my-5 input-group";

            HtmlGenericControl textDiv = new HtmlGenericControl("div");
            textDiv.Attributes["class"] = "pt-4 b1";

            CheckBox sectBreak = new CheckBox();
            sectBreak.ID = "checkBox" + Convert.ToString(Counter);
            sectBreak.Attributes["class"] = "inpSec2 pt-2 mt-0";
            sectBreak.Attributes["runat"] = "server";
            textDiv.Controls.Add(sectBreak);

            //Update Checking
            if(IsUpdate == 1)
            {
                setUpdateValues(sectBreak, Counter);
            }

            HtmlGenericControl textSpan = new HtmlGenericControl("span");
            textSpan.Attributes["class"] = "align-self-stretch inpSec alatsi-regular";
            textSpan.InnerHtml = "Section Break";
            textDiv.Controls.Add(textSpan);
            dynamicDiv.Controls.Add(textDiv);

            TextBox ContentBox = new TextBox();
            ContentBox.ID = "ContentBox" + Convert.ToString(Counter);
            ContentBox.Attributes["class"] = "form-control inpSec alatsi-regular";
            ContentBox.TextMode = TextBoxMode.MultiLine;
            dynamicDiv.Controls.Add(ContentBox);

            //Update Checking
            if (IsUpdate == 1)
            {
                setUpdateValues(ContentBox, Counter);
            }

            DropDownList ddlType = new DropDownList();
            ddlType.ID = "ddlType" + Convert.ToString(Counter);
            ddlType.Items.Add(new ListItem("Text", "1"));
            ddlType.Items.Add(new ListItem("Image", "2"));
            ddlType.Items.Add(new ListItem("Video", "3"));
            ddlType.Attributes["class"] = "btn dropdown-toggle alatsi-regular inpSec";
            dynamicDiv.Controls.Add(ddlType);

            //Update Checking
            if (IsUpdate == 1)
            {
                setUpdateValues(ddlType, Counter);
            }

            Label errLabel = new Label();
            errLabel.ID = "errLabel" + Convert.ToString(Counter);
            errLabel.Text = "";
            HtmlGenericControl labelDiv = new HtmlGenericControl("div");
            labelDiv.ID = "labelDiv" + Counter;
            labelDiv.Attributes["class"] = "my-2 alatsi-regular";
            labelDiv.Controls.Add(errLabel);


            HtmlGenericControl divWrapper = new HtmlGenericControl("div");
            divWrapper.ID = "inpGroupWrapper" + Counter; ;
            divWrapper.Attributes["class"] = "col-sm-7 flex-column";
            divWrapper.Controls.Add(dynamicDiv);
            divWrapper.Controls.Add(labelDiv);

            this.Master.FindControl("ContentPlaceHolder1").FindControl("mainDiv").Controls.Add(divWrapper);
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            List<ArticleObjectPool> curObjLclPool = new List<ArticleObjectPool>();
            DatabaseEntities1 db = DatabaseSingleton.GetInstance();
            for (int i = 1; i <= Sections; i++)
            {
                String curDdlStr = "ddlType" + Convert.ToString(i);
                String curTextBoxStr = "ContentBox" + Convert.ToString(i);
                String curLblStr = "errLabel" + Convert.ToString(i);
                String curLbxStr = "checkBox" + Convert.ToString(i);
                DropDownList curDdl = this.Master.FindControl("ContentPlaceHolder1").FindControl(curDdlStr) as DropDownList;
                TextBox curTextBox = this.Master.FindControl("ContentPlaceHolder1").FindControl(curTextBoxStr) as TextBox;
                Label curLabel = this.Master.FindControl("ContentPlaceHolder1").FindControl(curLblStr) as Label;
                CheckBox curBox = this.Master.FindControl("ContentPlaceHolder1").FindControl(curLbxStr) as CheckBox;


                String objId = "";
                if(IsUpdate == 1)
                {
                    objId = curObjPool[i - 1].ObjectID;
                }
                else
                {
                    while (true)
                    {
                        String curId = GenerateObjectID();
                        ArticleObjectPool testObj = (from o in db.ArticleObjectPools where o.ObjectID == curId select o).ToList().FirstOrDefault();
                        if (curObjLclPool != null)
                        {
                            testObj = (from c in curObjLclPool where c.ObjectID == curId select c).ToList().FirstOrDefault();
                            if (testObj != null)
                            {
                                continue;
                            }
                        }

                        if (testObj == null)
                        {
                            objId = curId;
                            break;
                        }
                    }
                }
                

                if (TitleCheck(curDdl, curTextBox, curLabel) || VideoCheck(curDdl, curTextBox, curLabel) || ImgCheck(curDdl, curTextBox, curLabel))
                {
                    curObjLclPool = new List<ArticleObjectPool>();
                    return;
                }

                int boxCond = 0;
                if(curBox.Checked)
                {
                    boxCond = 1;
                }

                ArticleObjectPool pool = new ArticleObjectPool()
                {
                    ArticleID = ArticleID,
                    BuildOrder = i,
                    ObjectType = Convert.ToInt32(curDdl.SelectedValue),
                    ContentString = curTextBox.Text,
                    ObjectID = objId,
                    IsPageBreak = boxCond
                };

                curObjLclPool.Add(pool);
            }

            for (int i = 0; i < Sections; i++)
            {
                if(IsUpdate == 1)
                {
                    db.ArticleObjectPools.Remove(curObjPool[i]);
                }
                db.ArticleObjectPools.Add(curObjLclPool[i]);
            }
            db.SaveChanges();

            Response.Redirect("~/Pages/OperationSuccess.aspx");
        }

        private String GenerateObjectID()
        {
            Random rnd = new Random();
            int X = rnd.Next(1, 1000);
            String ArticleID = String.Format("OB{0:000}", X);

            return ArticleID;
        }

        private bool ImgCheck(DropDownList curDdl, TextBox curTextBox, Label curLabel)
        {
            if (Convert.ToInt32(curDdl.SelectedValue) == 2)
            {
                if (curTextBox.Text.Contains("imgur"))
                {
                    return false;
                }
                curLabel.Text = "Image must be uploaded to Imgur";
                return true;
            }
            return false;
        }

        private bool VideoCheck(DropDownList curDdl, TextBox curTextBox, Label curLabel)
        {
            if (Convert.ToInt32(curDdl.SelectedValue) == 3)
            {
                if (curTextBox.Text.Contains("youtube"))
                {
                    return false;
                }
                curLabel.Text = "Video must be uploaded to youtube";
                return true;
            }
            return false;
        }

        private bool TitleCheck(DropDownList curDdl, TextBox curTextBox, Label curLabel)
        {

            if (Convert.ToInt32(curDdl.SelectedValue) == 1)
            {
                if (curTextBox.Text.Length < 5001 && curTextBox.Text.Length > 0)
                {
                    return false;
                }
                curLabel.Text = "Text must be between 1 and 5000 characters (Inclusive)";
                return true;
            }
            return false;
        }

        private void setUpdateValues(Control curCtrl, int buildOrder) 
        { 
            if(curCtrl is TextBox)
            {
                ((TextBox)curCtrl).Text = curObjPool[buildOrder - 1].ContentString;
            }
            else if(curCtrl is DropDownList)
            {
                ((DropDownList)curCtrl).SelectedValue = Convert.ToString(curObjPool[buildOrder - 1].ObjectType);
            }
            else if(curCtrl is CheckBox)
            {
                if(curObjPool[buildOrder - 1].IsPageBreak == 1)
                {
                    ((CheckBox)curCtrl).Checked = true;
                }
            }
        }

    }
}