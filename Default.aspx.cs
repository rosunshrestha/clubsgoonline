
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


namespace clubsgoonline
{
    public partial class _Default : System.Web.UI.Page
    {
        private string[] idnews = new string[5];
        private string[] newspost = new string[5];
        protected void Page_Load(object sender, EventArgs e)
        {
            newspostAllnull();
            Recents();
            
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
        void Recents()
        {
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            int i = 0;
            SqlCommand SQLCommand = new SqlCommand("select * from news_update order by date desc", myConnection); //where clubid=queryrequest , becomes RecentNews.SelectCommand
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
            //RecentNews.SelectCommand = "SELECT * FROM news_update where newsid=";
            //RecentNews.SelectCommand += idnews[0] + " OR newsid=";
            //RecentNews.SelectCommand += idnews[1] + " OR newsid=";
            //RecentNews.SelectCommand += idnews[2] + " OR newsid=";
            //RecentNews.SelectCommand += idnews[3] + " OR newsid=";
            //RecentNews.SelectCommand += idnews[4];//use abovesqlcommand as this selectcommand 
            RecentNews.SelectCommand = "select top 5 * from news_update order by date desc";
            Briefnews.DataBind();
            NewsPanel.Text = newspost[0];

        }
        protected void GetFullNews(object source, DataListCommandEventArgs e)
        {
            string selectednews = e.CommandArgument.ToString(); ;
            if (e.CommandName == "more")
            {
                if (selectednews == idnews[0]) NewsPanel.Text = newspost[0];
                else if (selectednews == idnews[1]) NewsPanel.Text = newspost[1];
                else if (selectednews == idnews[2]) NewsPanel.Text = newspost[2];
                else if (selectednews == idnews[3]) NewsPanel.Text = newspost[3];
                else if (selectednews == idnews[4]) NewsPanel.Text = newspost[4];
            }
           // NewsPanel.Text = newspost[4];
        }
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
            SqlCommand MySQLCommand = new SqlCommand("INSERT INTO news_update(post,Date,Headline,BriefNews)VALUES ('" + NewNews.Text + "','" + newsdate + "','" + Headline.Text + "','" + brief + "')", myConnection);
            MySQLCommand.ExecuteNonQuery();
            Headline.Visible = false;
            Headline.Enabled = false;
            NewNews.Visible = false;
            NewNews.Enabled = false;
            GetNewsUpdate.Enabled = false;
            GetNewsUpdate.Visible = false;
            Recents();
        }
        protected void GoToClubwhich(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "cluburl")
            {
                string url = "club.aspx?recordid=";
                url += Convert.ToString(e.CommandArgument);
                Response.Redirect(url);
            }
        }
    }
}
