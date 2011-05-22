using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebKindergarten.Code;

namespace WebKindergarten.UserAccount
{
    public partial class CreateNewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            RightsMgmt.DoQuestion("createuser david 223245576 admin");
        }
    }
}