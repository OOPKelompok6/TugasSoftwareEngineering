using Leren1.Models;
using Leren1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leren1.Pages
{
    public partial class ArticleCreation : System.Web.UI.Page
    {
        private static int[] Sections = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static List<SubjectHeader> subjectHeaders;
        private static List<CategoryHeader> categoryHeaders;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DatabaseEntities1 db = DatabaseSingleton.GetInstance();
                subjectHeaders = (from s in db.SubjectHeaders select s).ToList();
                categoryHeaders = (from c in db.CategoryHeaders select c).ToList();
                DropDownCategory.DataSource = categoryHeaders.Select(c => c.CategoryTitle).ToList();
                DropDownSubjects.DataSource = subjectHeaders.Select(s => s.SubjectTitle).ToList();
                DropDownListSections.DataSource = Sections;
                DropDownCategory.DataBind();
                DropDownSubjects.DataBind();
                DropDownListSections.DataBind();
            }
        }
    }
}