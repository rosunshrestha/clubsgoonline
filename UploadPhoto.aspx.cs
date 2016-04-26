using System;
using System.IO;
using System.Web.UI.WebControls;
using clubsgoonline.App_Code;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Security.Permissions;

using System.Web.Security;


namespace clubsgoonline
{
    public partial class UploadPhoto : System.Web.UI.Page
    {
        string id_club;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_club = (Request.QueryString["recordID"]);
            Label7.Visible = false;
            Label7.Text = Convert.ToString(id_club);
            if (!IsPostBack)
            {

                /*clubsgoonline.App_Code.Global.currentpage =0;
                SqlConnection myConnection = new SqlConnection();
                string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
                myConnection.ConnectionString = connStr;
                SqlCommand cmd = new SqlCommand("select * from photo",myConnection);
                myConnection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                myConnection.Close();*/
                //BindList();
                DataList2.DataBind();
                lblInfo.Text = String.Empty;

            }
        }

        public void BindList()
        {
            PagedDataSource pg = new PagedDataSource();
            pg.AllowPaging = true;
            pg.PageSize = 6;
            pg.CurrentPageIndex = clubsgoonline.App_Code.Global.currentpage;
            //DataSet ds = (DataSet) ViewState["ds"];
            pg.DataSource = SqlDataSource1.SelectCommand;
            LinkButton1.Enabled = !pg.IsFirstPage;
            // LinkButton2.Enabled = !pg.IsLastPage;
            //DataList2.DataSource = pg;
            DataList2.DataBind();



        }



        // Manually register the event-handling methods.
        //DataList2.DeleteCommand +=
        //    new DataListCommandEventHandler(this.DataList2_DeleteCommand);

        //if (!Page.IsPostBack) 
        //{

        //        DataList2.DataBind();

        //}



        protected void BtnUpload_Click(object sender, EventArgs e)
        {
            string imagefolder = "Images";
            string savepath = Path.Combine(Request.PhysicalApplicationPath, imagefolder);
            string savefile;
            lblInfo.Text = String.Empty;
            Label1.Text = String.Empty;

            if (FileUpload2.HasFile)
            {
                // Check the extension.
                string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
                switch (extension.ToLower())
                {
                    case ".bmp":
                    case ".gif":
                    case ".jpg":
                    case ".png":
                        break;
                    default:
                        lblInfo.Text = "This file type is not allowed.";
                        return;
                }

                // Using this code, the saved file will retain its original
                // file name when it's placed on the server.

                savefile = Path.Combine(savepath, FileUpload2.FileName);

                try
                {
                    FileUpload2.PostedFile.SaveAs(savefile);
                    lblInfo.Text = "File " + FileUpload2.FileName;
                    lblInfo.Text += " uploaded successfully to";
                    lblInfo.Text += savefile;
                    Label2.Text = User.Identity.Name;
                    Label3.Text = DateTime.Now.ToString();
                    Guid guid = (Guid)Membership.GetUser().ProviderUserKey;
                    Label6.Text = guid.ToString();
                    SqlDataSource1.Insert();
                    DataList2.DataBind();

                    Label4.Text = "Success";
                    TextBox1.Text = string.Empty;

                }
                catch (Exception err)
                {
                    lblInfo.Text = err.Message;
                }
            }

            else
            {
                Label1.Text = "Sorry No file was selected";
                lblInfo.Text = string.Empty;
                Label2.Text = string.Empty;
                Label3.Text = string.Empty;
                Label4.Text = string.Empty;
            }
        }

        //protected void Photo_Delete(object source, DataListCommandEventArgs e)
        //{
        //    DataList2.EditItemIndex = e.Item.ItemIndex;
        //    //Code to delete the row represented by ItemIndex
        //    DataList2.EditItemIndex = -1; //Reset the index
        //    DataList2.DataBind();
        //}

        //protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        //{
        //    SqlConnection myConnection = new SqlConnection();
        //    string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
        //    myConnection.ConnectionString = connStr;
        //    myConnection.Open();
        //    SqlCommand _cmd = new SqlCommand("delete from tblPhoto where id=" + DataList2.DataKeys[e.Item.ItemIndex], myConnection );
        //    _cmd.ExecuteNonQuery();
        //    myConnection.Close();
        //    DataList2.EditItemIndex = -1;
        //    DataList2.DataBind();
        //}

        //protected void Delete_Click(object sender, EventArgs e)
        //{

        //}

        // if (user has put the photo (see by uid) deletebutton.visible else not visible)) !!

        //http://www.devx.com/vb2themax/Article/19908

        // [PrincipalPermission(SecurityAction.Demand, Name = "Prajwol Shrestha")]
        protected void DataList2_DeleteCommand(object source, DataListCommandEventArgs e)
        {
            int id = (int)DataList2.DataKeys[(int)e.Item.ItemIndex];
            SqlDataSource1.DeleteParameters["id"].DefaultValue = id.ToString();

            Label2.Text = string.Empty;
            Label3.Text = string.Empty;
            Label4.Text = string.Empty;

            SqlDataSource1.Delete();
            lblInfo.Text = "Photo Deleted Successfully";
            DataList2.DataBind();


            // SqlConnection myConnection = new SqlConnection();
            //   string connStr = WebConfigurationManager.ConnectionStrings["cgo_dataConnectionString"].ConnectionString;
            //    myConnection.ConnectionString = connStr;
            //   myConnection.Open();
            //   SqlCommand mycommand = new SqlCommand("delete from photo where id=" + @id, myConnection);

            //SqlCommand _cmd = new SqlCommand("delete from tblPhoto where id=" + DataList2.DataKeys[e.Item.ItemIndex], myConnection );
            //  _cmd.ExecuteNonQuery();
            // SqlDataSource1.DeleteParameters["PhotoID"].DefaultValue = id.ToString();
            //SqlDataSource1.Delete();

            // myConnection.Close();
        }


        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            clubsgoonline.App_Code.Global.currentpage -= 1;
            BindList();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            clubsgoonline.App_Code.Global.currentpage += 1;
            BindList();
        }

        protected void ViewAllPhotos(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "Select * from photo where club_id=" + id_club;
            DataList2.DataBind();

        }


    }

}
