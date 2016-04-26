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

namespace clubsgoonline
{
    public partial class allnews : System.Web.UI.Page
    {
        int id_club;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_club = Convert.ToInt32(Request.QueryString["recordID"]);
            GetallClubInfo(id_club);
            RecentNews.SelectCommand = "select top 50 * from news_update where club_id='" + Convert.ToString(id_club) + "' order by newsid desc";
        }
        protected void Briefnews_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            RecentNews.DeleteParameters["newsid"].DefaultValue = e.CommandArgument.ToString();
            RecentNews.Delete();
            Briefnews.DataBind();
        }
        protected void GetFullNews(object source, DataListCommandEventArgs e)
        {
            string selectednews;
            if (e.CommandName == "more")
            {
                selectednews = e.CommandArgument.ToString();
                string[] text= new string[2];
                text=e.CommandArgument.ToString().Split(';');
                Session["Headline"]=text[0];
                Session["post"]=text[1];
                NewsPanel.Text="<b>"+text[0]+"<b><br/>"+text[1];
            }
            
        }
        void GetallClubInfo(int idclub)
        {
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand SQLCommand = new SqlCommand("select * from clubinformation where clubid='" + Convert.ToString(idclub) + "'", myConnection);
            SqlDataReader myreader = SQLCommand.ExecuteReader();
            while (myreader.Read())
            {
                ClubName.Text = myreader.GetString(1);
                Abbrev.Text = myreader.GetString(2);
                ClubMoto.Text = myreader.GetString(3);
                Estd.Text = Convert.ToString(myreader.GetInt32(4));
                clublogo.ImageUrl = "~\\Logo\\" + myreader.GetString(6);
            }
            myreader.Close();
            myConnection.Close();
        }
    }
}