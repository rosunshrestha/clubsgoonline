using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Web.Security;

namespace clubsgoonline
{
    public partial class givegive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string imagefolder = "Images";
            string savepath;
            string savefile;

            if (FileUpload1.HasFile)
            {
                savepath = Path.Combine(Request.PhysicalApplicationPath, imagefolder);
                savefile = Path.Combine(savepath, FileUpload1.FileName);
                   
                FileUpload1.SaveAs(savefile);
                SqlDataSource1.Insert();
                Label1.Text = "Success";
                

            }
        }
    }
}