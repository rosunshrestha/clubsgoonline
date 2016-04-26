using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

namespace clubsgoonline
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                clublist.Items.Add("Choose Club");
                SqlConnection myConnection = new SqlConnection();
                string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
                myConnection.ConnectionString = connStr;
                myConnection.Open();
                SqlCommand com = new SqlCommand("select * from clubinformation order by clubid ASC", myConnection);
                SqlDataReader myreader = com.ExecuteReader();
                while (myreader.Read())
                {
                    clublist.Items.Add(myreader.GetString(1));
 
                }
                myreader.Close();
                myConnection.Close();

            }
        }

        protected void gotoClub(object sender, EventArgs e)
        {
            string cluburl = "~\\club.aspx?recordid=";
            int idclub;

            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand com = new SqlCommand("select * from clubinformation", myConnection);
            SqlDataReader myreader = com.ExecuteReader();
            while (myreader.Read())
            {
                idclub = myreader.GetInt32(0);
                if (clublist.SelectedIndex == idclub)
                {
                    cluburl += Convert.ToString(idclub); 
                }

            }
            myreader.Close();
            myConnection.Close();
            Response.Redirect(cluburl);

        }
    }
}
