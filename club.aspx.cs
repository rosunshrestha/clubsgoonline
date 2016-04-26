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
    public partial class club : System.Web.UI.Page
    {
        
        private string[] idnews = new string[5];
        private string[] newspost = new string[5];
        int id_club;
        
        //string Role1 = "Administrators";
        protected void Page_Load(object sender, EventArgs e)
        {
            id_club=Convert.ToInt32(Request.QueryString["recordID"]);
            newspostAllnull();
            GetallClubInfo(id_club);
            string role1 = id_club + "Member";
            string role2 = id_club + "Moderator";
            visibleButtons(role1, role2);
            Recents(id_club);
            //Briefnews.DataBind();
            
        }

        void visibleButtons(string role1, string role2)
        {
            if (User.IsInRole(role1) || User.IsInRole(role2))
            {
                HyperLink1.NavigateUrl = "UploadPhoto.aspx?recordid=" + Convert.ToString(id_club);
                HyperLink1.Text = "UploadPhoto";

                HyperLink1.Enabled = true;
                HyperLink1.Visible = true;
            }

            if (User.IsInRole(role2))
            {
                HyperLink2.NavigateUrl = "AuthorizeMembers.aspx?recordid=" + Convert.ToString(id_club);
                HyperLink2.Text = "Authorize Members";
                HyperLink2.Enabled = true;
                HyperLink2.Visible = true;
                UpdateNews.Visible = true;
                UpdateNews.Enabled = true;

            }


        }
        void newspostAllnull()
        {
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                idnews[i] = null;
                newspost[i] = null;
            }
        }


        //void PhotoUploadVisible() 
        //{
        //    HyperLink1.NavigateUrl = "UploadPhoto.aspx";
        //    HyperLink1.Visible = true;
        //}

        void GetallClubInfo(int idclub)
        {
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand SQLCommand = new SqlCommand("select * from clubinformation where clubid='"+Convert.ToString(idclub)+"'", myConnection); 
            SqlDataReader myreader = SQLCommand.ExecuteReader();
            while (myreader.Read())
            {
                ClubName.Text=myreader.GetString(1);
                Abbrev.Text=myreader.GetString(2);
                ClubMoto.Text=myreader.GetString(3);
                Estd.Text=Convert.ToString(myreader.GetInt32(4));
                clublogo.ImageUrl="~\\Logo\\"+myreader.GetString(6);
                Description.Text = myreader.GetString(7);
            }
            myreader.Close();
            myConnection.Close();
         }
       
        void Recents(int idclub)
        { 
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            int i = 0;
            query.Text = Convert.ToString(idclub);
            SqlCommand SQLCommand = new SqlCommand("select * from news_update where club_id='" + Convert.ToString(idclub) + "' order by date desc", myConnection);
            SqlDataReader myreader = SQLCommand.ExecuteReader();
            while (myreader.Read() && i<5)
            {
                idnews[i] = Convert.ToString(myreader.GetInt32(0));
                newspost[i] = "<b>" + myreader.GetString(3) + "</b>";
                newspost[i] += "<br/>" + myreader.GetString(1);
                i++;
            }
            myreader.Close();
            myConnection.Close();
            RecentNews.SelectCommand = "select top 5 * from news_update where club_id='" + Convert.ToString(idclub) + "' order by newsid desc";
            Briefnews.DataBind();
            NewsPanel.Text = newspost[0];
        }

        
        
        protected void GetFullNews(object source, DataListCommandEventArgs e)
        {
            string selectednews = e.CommandArgument.ToString();
            if (e.CommandName == "more")
            {
                if (selectednews == idnews[0]) NewsPanel.Text = newspost[0];
                else if (selectednews == idnews[1]) NewsPanel.Text = newspost[1];
                else if (selectednews == idnews[2]) NewsPanel.Text = newspost[2];
                else if (selectednews == idnews[3]) NewsPanel.Text = newspost[3];
                else if (selectednews == idnews[4]) NewsPanel.Text = newspost[4];
            }
        }
        protected void AllNews(object sender, EventArgs e)
        {
            string url = "allnews.aspx?recordid=";
            url += Convert.ToString(id_club);
            Response.Redirect(url);
        }
        /*protected void AddComment(object sender, EventArgs e)
        {
            if (CommentRequire.IsValid)
            {
                DateTime date = DateTime.Now;
                string commentdate = date.ToString();
                string MySQLConnectionArgs = "DRIVER={MySQL Sql 3.51 Driver};–SERVER=localhost;DATABASE=student;UID=root;–PASSWORD=;OPTION=0";
                OdbcConnection MySQLConnection = new OdbcConnection(MySQLConnectionArgs);
                MySQLConnection.Open();
                OdbcCommand MySQLCommand = new OdbcCommand("INSERT INTO `student`.`news_comment` (`comment,`date`,`newsid`)VALUES ('" + user_comment.Text + "','" + commentdate + "','" + newsid_new + "')", MySQLConnection);
                MySQLCommand.ExecuteNonQuery();
            }
        }*/

        protected void NewsUpdate(object sender, EventArgs e)
        {
            NewsPanel.Text = "";
            Headline.Visible = true;
            Headline.Enabled = true;
            NewNews.Visible = true;
            NewNews.Enabled = true;
            GetNewsUpdate.Enabled = true;
            GetNewsUpdate.Visible = true;
        }
        protected void NewsUpdated(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            string newsdate = date.ToString();
            string brief = NewNews.Text.Substring(0, NewNews.Text.Length / 3);
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand MySQLCommand = new SqlCommand("INSERT INTO news_update(post,Date,Headline,BriefNews,club_id)VALUES ('" + NewNews.Text + "','" + newsdate + "','" + Headline.Text + "','" + brief + "'," + id_club + ")", myConnection);
            MySQLCommand.ExecuteNonQuery();
            Headline.Visible = false;
            Headline.Enabled = false;
            NewNews.Visible = false;
            NewNews.Enabled = false;
            GetNewsUpdate.Enabled = false;
            GetNewsUpdate.Visible = false;
            Recents(id_club);
        }

        protected void Briefnews_DeleteCommand(object sender, DataListCommandEventArgs e)
        {
            
            RecentNews.DeleteParameters["newsid"].DefaultValue = e.CommandArgument.ToString();
            RecentNews.Delete();
            Briefnews.DataBind();
        }

    }
}