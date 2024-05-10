using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Leren1.Masters
{
    public partial class LoggedIn : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchBarBox_TextChanged(object sender, EventArgs e)
        {
            HtmlGenericControl dropDownMenu = (HtmlGenericControl)FindControl("DropdownMenu");
        }
    }
}