
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace clubsgoonline
{

    public partial class AuthorizeMembers : System.Web.UI.Page
    {
        SqlConnection myConnection = DatabaseConnection.getConnection();
        string id_club;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_club = (Request.QueryString["recordID"]);
            Label1.Text = id_club;
            MemberSource.DataBind();

        }

        protected void AddMemberButton_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem ri in ProspectMembers.Items)
            {
                CheckBox CheckBox = ri.FindControl("ClubCheckBox") as CheckBox;
                string userName = CheckBox.Text;
                try
                {
                    if (CheckBox.Checked)
                    {
                        Roles.AddUserToRole(userName, id_club + "Member");

                    }
                }
                catch (Exception)
                {
                    Label2.Visible = true;
                    Label2.Text = "User " + CheckBox.Text + " Is already a Member";
                }

            }
        }
    }
}