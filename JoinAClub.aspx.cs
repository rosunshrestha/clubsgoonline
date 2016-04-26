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




namespace clubsgoonline
{
    public partial class JoinAClub : System.Web.UI.Page
    {
        SqlConnection myConnection = DatabaseConnection.getConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = string.Empty;
            //foreach (RepeaterItem ri in ClubList.Items)
            //{
            //    CheckBox CheckBox = ri.FindControl("ClubCheckBox") as CheckBox;
            //    CheckBox.Checked = false;
            //    
            //}
            if (!Page.IsPostBack)
            {
                Guid guid;
                ClubList.DataBind();
                try
                {
                    guid = (Guid)Membership.GetUser().ProviderUserKey;




                    myConnection.Open();

                    foreach (RepeaterItem ri in ClubList.Items)
                    {
                        CheckBox CheckBox = ri.FindControl("ClubCheckBox") as CheckBox;
                        string clubName = CheckBox.Text;
                        SqlCommand myCommand = new SqlCommand("SELECT count(*) FROM clubinformation ci join club_user cu on ci.clubid = cu.club_id " +
                            " where ci.clubname = @clubName " +
                            " and cu.user_id = @UserId",
                            myConnection);
                        myCommand.Parameters.Add("@clubName", SqlDbType.VarChar);
                        myCommand.Parameters["@clubName"].Value = clubName;
                        myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
                        myCommand.Parameters["@UserId"].Value = guid;
                        int alreadySelected = (int)myCommand.ExecuteScalar();

                        // Programmatically reference the CheckBox
                        CheckBox.Checked = (alreadySelected > 0) ? true : false;
                        if (CheckBox.Checked)
                        {
                            //string myStringVariable = clubName;
                            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert(Already Requested to join'" + myStringVariable + "');", true);
                            Label1.Text = "You have  already requested to join" + CheckBox.Text;
                            Label1.Visible = true;

                        }

                    }

                }


            //foreach (Object item in ClubCheckBox)
                //{
                //    item.Text = item.Selected ? "Checked" : "UnChecked";
                //}
                //Guid guid = (Guid)Membership.GetUser().ProviderUserKey;
                //string username = User.Identity.Name;
                // populateClublist();


                catch (Exception)
                {
                    string message = "You're not Logged in. You'll be redirected to Registration Page";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function()(");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    Response.Redirect("~/Account/Register.aspx");
                }
            }
        }
             

        protected void Confirm_Click(object sender, EventArgs e)
        {

            //MembershipUser User = Membership.GetUser(((CreateUserWizard)sender).UserName);
            Guid guid = (Guid)Membership.GetUser().ProviderUserKey;
            foreach (RepeaterItem ri in ClubList.Items)
            {
                // Programmatically reference the CheckBox
                CheckBox CheckBox = ri.FindControl("ClubCheckBox") as CheckBox;
                string clubName = CheckBox.Text;
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT clubid FROM clubinformation where clubname = '" + clubName + "'", myConnection);
                int id = (int)myCommand.ExecuteScalar();
                myCommand = new SqlCommand("SELECT count(*) FROM club_user where club_id = @ClubId and user_id = @UserId", myConnection);
                myCommand.Parameters.Add("@ClubId", SqlDbType.Int);
                myCommand.Parameters["@ClubId"].Value = id;
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
                myCommand.Parameters["@UserId"].Value = guid;
                int alreadyInDb = (int)myCommand.ExecuteScalar();
                if (CheckBox.Checked && alreadyInDb == 0)
                {
                    SqlCommand myCommand2 = new SqlCommand("INSERT INTO club_user(club_id,user_id) VALUES (@id, @UserId);", myConnection);
                    myCommand2.Parameters.Add("@id", SqlDbType.Int);
                    myCommand2.Parameters["@id"].Value = id;
                    myCommand2.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
                    myCommand2.Parameters["@UserId"].Value = guid;
                    myCommand2.ExecuteNonQuery();
                }
                else if (!CheckBox.Checked && alreadyInDb > 0)
                {
                    SqlCommand myCommand2 = new SqlCommand("DELETE club_user where club_id = @id and user_id = @UserId;", myConnection);
                    myCommand2.Parameters.Add("@id", SqlDbType.Int);
                    myCommand2.Parameters["@id"].Value = id;
                    myCommand2.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
                    myCommand2.Parameters["@UserId"].Value = guid;
                    myCommand2.ExecuteNonQuery();
                }
                myConnection.Close();
            }

        }



    }
}


