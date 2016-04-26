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



namespace clubsgoonline.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            string name = User.Identity.Name;

        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            MembershipUser User = Membership.GetUser(((CreateUserWizard)sender).UserName);
            TextBox SecurityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("RegistrationCode");
            String SecurityCode = SecurityTextBox.Text;

            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("INSERT INTO extra_user_info(id,registration_code) VALUES (@UserId, @RegCode);", myConnection);
            myCommand.Parameters.Add("@RegCode", SqlDbType.VarChar);
            myCommand.Parameters["@RegCode"].Value = SecurityCode;
            myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier);
            myCommand.Parameters["@UserId"].Value = User.ProviderUserKey;
            myCommand.ExecuteNonQuery();

            myConnection.Close();



            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

        protected void Wizard_CreatingUser(object sender, LoginCancelEventArgs e)
        {

            //TextBox UserNameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UserName");
            //String abc = UserNameTextBox.Text;
            //Response.Write(UserNameTextBox.Text);
            //String enteredName = ((CreateUserWizard)sender).UserName;
            // e.Cancel = abc.CompareTo("Prajwol3333") != 1 ? true : false;
            TextBox NameTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("UniversityName");
            string universityName = NameTextBox.Text;

            TextBox SecurityTextBox = (TextBox)RegisterUserWizardStep.ContentTemplateContainer.FindControl("RegistrationCode");
            String SecurityCode = SecurityTextBox.Text;
            Response.Write(SecurityTextBox.Text.Trim());
            e.Cancel = SecurityCode.Equals("");

            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            //Response.Redirect("CheckUserCredentials.aspx");


            SqlCommand myCommand = new SqlCommand("SELECT name FROM user_credentials where UPPER(security_code) = '" + SecurityCode.Trim().ToUpper() + "'", myConnection);
            // SqlCommand myCommand = new SqlCommand("SELECT name FROM user_credentials where security_code = 'SUCEBC100009' ", myConnection);
            String nameInDb = (String)myCommand.ExecuteScalar();

            myCommand = new SqlCommand("SELECT COUNT(*) FROM extra_user_info where '" + SecurityCode.Trim().ToUpper() + "' like UPPER(registration_code)", myConnection);
            int count = (int)myCommand.ExecuteScalar();

            bool cannotMakeUser1 = (nameInDb == null ? true : (nameInDb.Equals(universityName) ? false : true));
            bool cannotMakeUser2 = count > 0 ? true : false;
            bool cannotMakeUser = (cannotMakeUser1) || (cannotMakeUser2);
            myConnection.Close();
            /*e.Cancel = nameInDb.Equals(enteredName) ? false : true;*/
            // try
            //{ e.Cancel = nameInDb.Equals(enteredName) ? false : true; }

            string errormsg1 = "";
            try
            {
                if (cannotMakeUser == true)
                {

                    if (cannotMakeUser1) { errormsg1 = "Name and Code do not match"; }
                    else if (cannotMakeUser2) { errormsg1 = "User Already Exists. Register as different User"; }

                    System.Text.StringBuilder sbl = new System.Text.StringBuilder();
                    sbl.Append("<script type = 'text/javascript'>");
                    sbl.Append("window.onload=function(){");
                    sbl.Append("alert('");
                    sbl.Append(errormsg1);
                    sbl.Append("')};");
                    sbl.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sbl.ToString());
                    Response.Redirect("Register.aspx");
                    e.Cancel = cannotMakeUser;
                }
                //else
                //{
                //    Response.Redirect("Register.aspx");
                //}
            }

            catch (ArgumentNullException)
            {
                Response.Redirect("Register.aspx");
                /*string errormsg1 = "User Already Exists. Register as different User";
                System.Text.StringBuilder sbl = new System.Text.StringBuilder();
                sbl.Append("<script type = 'text/javascript'>");
                sbl.Append("window.onload=function(){");
                sbl.Append("alert('");
                sbl.Append(errormsg1);
                sbl.Append("')};");
                sbl.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sbl.ToString());
                Response.Redirect("Register.aspx");*/
            }




            /*  try { e.Cancel = nameInDb.Equals(universityName) ? false : true; }

              catch (ArgumentNullException)
              {
                  string errormsg1 = "KU Registered name Not found. Sorry You have to registr with a valid ";
                  System.Text.StringBuilder sbl = new System.Text.StringBuilder();
                  sbl.Append("<script type = 'text/javascript'>");
                  sbl.Append("window.onload=function(){");
                  sbl.Append("alert('");
                  sbl.Append(errormsg1);
                  sbl.Append("')};");
                  sbl.Append("</script>");
                  ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sbl.ToString());
                  Response.Redirect("Register.aspx");
                  Response.Redirect("Register.aspx"); }
              catch (Exception)
              { Response.Redirect("Register.aspx"); }*/

        }




    }
}
