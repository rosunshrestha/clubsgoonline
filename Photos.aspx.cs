using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;


namespace clubsgoonline
{
    public partial class Photos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string albumid = Request.QueryString["AlbumID"];
                hfAlbumID.Value = albumid;
                string query = "SELECT DefaultPhotID, AlbumName,photo FROM [Album1] INNER JOIN PhotAlbum ON [Album1].[DefaultPhotID] = PhotAlbum.PhotoID WHERE Album1.[AlbumID] =" + hfAlbumID.Value;
                GetAlbumDetails(query);
            }
        }
        public void GetAlbumDetails(string query)
        {
            SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString);
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                lblAlbumName.Text = dr["AlbumName"].ToString();
                imAlbumPhoto.ImageUrl = "ThumbNail.ashx?ImURL=" + dr["photo"].ToString();
            }
        }
        protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            lblNoofPicz.Text = e.AffectedRows.ToString();
        }
        protected void lbUploadPhotos_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Items.Add("AlbumID", hfAlbumID.Value);
            Server.Transfer("ImageUpload.aspx");
        }
    }
}