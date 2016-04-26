using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

namespace clubsgoonline
{
    /// <summary>
    /// Summary description for ThumbNail
    /// </summary>
    public class ThumbNail : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            string imageurl = context.Request.QueryString["ImURL"];
            string str = context.Server.MapPath(".") + imageurl;
            Bitmap bmp = new Bitmap(str);
            System.Drawing.Image img = bmp.GetThumbnailImage(100, 100, null, IntPtr.Zero);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bmpBytes = ms.GetBuffer();
            img.Dispose();
            ms.Close();

            context.Response.BinaryWrite(bmpBytes);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}