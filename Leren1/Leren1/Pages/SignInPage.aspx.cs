using Leren1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Leren1.Pages
{
    public partial class SignInPage : System.Web.UI.Page
    {
        private DatabaseEntities1 db = new DatabaseEntities1 ();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SignBtn_Click(object sender, EventArgs e)
        {
            String Email = EmailTxt.Text;
            String Password = PasswordTxt.Text;
            bool Check = RememberCb.Checked;

            var user = (from x in db.Users where x.Email.Equals(Email) && x.Password.Equals(Password) select x).FirstOrDefault();

            if (user != null)
            {
                if(user.Role == "Teacher")
                {
                    Response.Redirect("/Pages/ArticleCreation.aspx");
                }

                if(user.Role == "Student")
                {
                    Response.Redirect("/Pages/CoursePage.aspx");
                }

                if (Check)
                {
                    HttpCookie cookie = new HttpCookie("user-cookie");
                    cookie.Value = user.Id.ToString();
                    cookie.Expires = DateTime.Now.AddMinutes(2);
                    Response.Cookies.Add(cookie);
                }
            }
        }
    }
}