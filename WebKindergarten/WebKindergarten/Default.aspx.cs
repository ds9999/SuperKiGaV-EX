using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebKindergarten.Code;
using WebKindergarten.Code.Entities;

namespace WebKindergarten
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            IList<Kind> list = db.getChildList();
            foreach (Kind k in list)
            {
                ListBox1.Items.Add(new ListItem(k.ToString(), k.Id.ToString()));
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["Name"] = ListBox1.SelectedItem.Text;
        }
    }
}
