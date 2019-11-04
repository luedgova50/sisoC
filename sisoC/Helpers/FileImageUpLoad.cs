namespace sisoC.Helpers
{
    using System.IO;
    using System.Web;


    public class FileImageUpLoad
    {
        public static bool UploadPhoto(HttpPostedFileBase file, string folder, string name)
        {
            if (file == null || string.IsNullOrEmpty(folder) || string.IsNullOrEmpty(name))
            {
                return false;
            }

            try
            {
                string path = string.Empty;

                //string pic = string.Empty;

                if (file != null)
                {
                    //pic = Path.GetFileName(file.FileName);

                    path =
                        Path.Combine(HttpContext.
                        Current.Server.
                        MapPath(folder),
                        name);

                    file.SaveAs(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        file.InputStream.CopyTo(ms);

                        byte[] array = ms.GetBuffer();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }          
        }
    }
}