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
using System.IO;

namespace clubsgoonline
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                School.Items.Add("Select One");
                School.Items.Add("Engineering");
                School.Items.Add("Science");
                School.Items.Add("Management");
                School.Items.Add("Independant");
            }
            
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string imagename = Abbv.Text + ".jpg";
                SqlConnection myConnection = new SqlConnection();
                string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
                myConnection.ConnectionString = connStr;
                myConnection.Open();
                SqlCommand MySQLCommand = new SqlCommand("INSERT INTO clubinformation(clubname,abbreviation,clubmoto,establishedyear,clublogo,clubdescription)VALUES ('" + ClubName.Text
                    + "','" + Abbv.Text + "'," + Convert.ToInt32(Estd.Text) + ",'" + imagename + "'," + Description.Text + ")", myConnection);
                MySQLCommand.ExecuteNonQuery();
                Response.Redirect("~\\Default.aspx");
       
            }
            else Response.Redirect("SignUp.aspx");
        }
        void Engineering()
        {
                Dept.Items.Clear();
                Dept.Items.Add("Computer Engineering");
                Dept.Items.Add("Mechanical Engineering");
                Dept.Items.Add("Civil Engineering");
                Dept.Items.Add("Geomatics Engineering");
                Dept.Items.Add("Electrical Engineering");
                Dept.Items.Add("Environmental Engineering");
        }
        void Science()
        {
            Dept.Items.Clear();
            Dept.Items.Add("Computer Science");
            Dept.Items.Add("Biotechnology");
            Dept.Items.Add("Environmental Science");
            Dept.Items.Add("Human Biology");
            Dept.Items.Add("Pharmacy");
            Dept.Items.Add("Applied Physics");
        }

        void Management()
        {
            Dept.Items.Clear();
            Dept.Items.Add("BA");
            Dept.Items.Add("BBA");
            Dept.Items.Add("BBS");
        }

        protected void School_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (School.SelectedIndex == 1) Engineering();
            else if (School.SelectedIndex == 2) Science();
            else if (School.SelectedIndex == 3) Management();
        }

        protected void UploadNewLogo(object sender, EventArgs e)
        {
            string imagefolder = "Logo";
            string savepath = Path.Combine(Request.PhysicalApplicationPath, imagefolder);
            string savefile;

            if (UploadLogo.HasFile)
            {
                // Check the extension.
                string extension = Path.GetExtension(UploadLogo.PostedFile.FileName);
                switch (extension.ToLower())
                {
                    case ".bmp":
                    case ".gif":
                    case ".jpg":
                        break;
                    default:
                        UpdatePro.Text="Invalid File";
                        break;
                }

                // Using this code, the saved file will retain its original
                // file name when it's placed on the server.

                savefile = Path.Combine(savepath, UploadLogo.FileName);

                try
                {
                    UploadLogo.PostedFile.SaveAs(savefile);
                    UpdatePro.Text="File Successfully Uploaded";
                }
                catch (Exception err)
                {
                    UpdatePro.Text = err.Message;
                }
            }
        }

        protected void CheckCode(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection();
            string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            myConnection.ConnectionString = connStr;
            myConnection.Open();
            SqlCommand SQLCommand = new SqlCommand("select * from verify_club where used=0", myConnection);
            SqlDataReader myreader = SQLCommand.ExecuteReader();
            while (myreader.Read())
            { 
                if(SKey.Text==myreader.GetString(1))
                {
                    SqlCommand SQLCommand1 = new SqlCommand("update verify_club set used=1 where SKey='" + myreader.GetString(1) + "'", myConnection);
                    SQLCommand1.ExecuteNonQuery();
                    vSkey.Validate();
                    break;
                }
            }
            myreader.Close();
            myConnection.Close();
        }
    }
}