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
    public partial class ImageUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Items["AlbumID"] != null)
            {
                Page.DataBind();
                ddlAlbum.Items.FindByValue(HttpContext.Current.Items["AlbumID"].ToString()).Selected = true;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string imgName = txtImageName.Text;
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("select Max(PhotoId)+1 as PhotoID from PhotAlbum", connection);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            string photoid = dr["PhotoID"].ToString();
            string filename = photoid + System.IO.Path.GetExtension(fuImage.FileName);
            string location = "/Images/" + filename;
            fuImage.SaveAs(Server.MapPath(".") + location);
            dr.Close();

            command = new SqlCommand("INSERT INTO PhotAlbum (photoname,photo,albumid) VALUES ( @img_name, @img_data,@albumid)", connection);
            SqlParameter param0 = new SqlParameter("@img_name", SqlDbType.VarChar, 50);
            param0.Value = imgName;
            command.Parameters.Add(param0);

            SqlParameter param1 = new SqlParameter("@img_data", SqlDbType.VarChar);
            param1.Value = location;
            command.Parameters.Add(param1);


            SqlParameter param2 = new SqlParameter("@albumid", SqlDbType.Int);
            param2.Value = ddlAlbum.SelectedValue;
            command.Parameters.Add(param2);

            int numRowsAffected = command.ExecuteNonQuery();

            if (ckbAlbumCover.Checked)
            {
                command = new SqlCommand("update album1 set DefaultPhotID =" + photoid + " where albumid=" + ddlAlbum.SelectedValue, connection);
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
        protected void lbGoTo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Photos.aspx?AlbumID=" + ddlAlbum.SelectedValue);
        }
    }
}