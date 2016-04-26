using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Web.Security;

namespace clubsgoonline
{
    public partial class CreateAlbum : System.Web.UI.Page
    {
        MembershipUser currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentUser = Membership.GetUser();

        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                Guid currentUserID = (Guid)currentUser.ProviderUserKey;

                SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["cgo_DataConnectionString"].ConnectionString);
                con.Open();
                string query = "Insert into Album1 (AlbumName,user_id,Created_by) values (@name,@UserID,@CurrentUser);SELECT ident_Current('Album1') AS 'AlbumID'";
                /*('" + txtAlbumName.Text + "')*/
                SqlCommand com = new SqlCommand(query, con);
                com.Parameters.Add("@name", SqlDbType.VarChar);
                com.Parameters["@name"].Value = txtAlbumName.Text;
                com.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
                com.Parameters["@UserId"].Value = currentUserID;
                com.Parameters.Add("@CurrentUser", SqlDbType.VarChar);
                com.Parameters["@CurrentUser"].Value = User.Identity.Name;
                com.ExecuteNonQuery();


                //cmd = new SqlCommand("insert into Accom (UserID) values(@currentUserID)", con);
                //param.ParameterName = "@currentUserID";
                //param.Value = valueOfUserId;
                //cmd.Parameters.Add(param);
                //cmd.ExecuteNonQuery(); 
                object obj = com.ExecuteScalar();
                int res = int.Parse(obj.ToString());
                Response.Write("<script>alert('Album Created!!')</script>");
                HttpContext.Current.Items.Add("AlbumID", res);
                Server.Transfer("ImageUpload.aspx");
            }

        catch(ArgumentNullException)
            {
                Response.Write("<script>alert('You must be logged in to upload photo')</script>");
            }

        }
    }
}