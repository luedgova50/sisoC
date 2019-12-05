namespace sisoC.Helpers
{
    using System.IO;
    using System.Web;

    public class FirmImageUpLoad
    {
        public static bool UploadFirm(HttpPostedFileBase file2, string folder2, string name2)
        {
            if (file2 == null || string.IsNullOrEmpty(folder2) || string.IsNullOrEmpty(name2))
            {
                return false;
            }

            try
            {
                string path = string.Empty;

                //string pic = string.Empty;

                if (file2 != null)
                {
                    //pic = Path.GetFileName(file.FileName);

                    path =
                        Path.Combine(HttpContext.
                        Current.Server.
                        MapPath(folder2),
                        name2);

                    file2.SaveAs(path);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        file2.InputStream.CopyTo(ms);

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