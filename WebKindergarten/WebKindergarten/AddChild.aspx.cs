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
    public partial class AddChild : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // TextBox1.Text = Session["Name"] == null ? "NULL" : Session["Name"].ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            Kind k = new Kind { Vorname = TextBox1.Text, Nachname = TextBox2.Text, Geburtstag = DateTime.Parse(TextBox3.Text) };
            db.addChild(k);
        }

        protected void CustomDateValidator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime tempDateTime;
            String textDateTime = args.Value;
            if (DateTime.TryParse(textDateTime, out tempDateTime))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

    }
}