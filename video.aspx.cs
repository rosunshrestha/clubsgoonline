using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.Security;
using System.Security.Permissions;
using ASPNetMediaGUI;
namespace clubsgoonline
{
    public partial class video : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_club = Convert.ToInt32(Request.QueryString["recordID"]);
            PlayListTrack Tracks = new PlayListTrack();
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand SQLCommand = new SqlCommand("select * from video where clubid='" + Convert.ToString(id_club) + "'", myConnection);
            SqlDataReader myreader = SQLCommand.ExecuteReader();
            while (myreader.Read())
            {
                Tracks.Name = myreader.GetString(3);//caption
                Tracks.URL = "~\\Videos\\"+myreader.GetString(1);//url
                PlayList1.PlayListTracks.Add(Tracks);
            }
            myreader.Close();
            myConnection.Close();
        }

       

        

        
    }
}