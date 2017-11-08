using System.IO;

namespace Silverzone.Data
{
    public class image_urlResolver
    {
        public const string profilePic_temp = "Img/User/profilePic/{0}/temp/";
        public const string profilePic_main = "Img/User/profilePic/{0}/";

        public const string bookImage_main = "Img/Admin/BookImage/";
        public const string quizImage_main = "Img/Admin/QuizImage/";

        // bcoz this value is not fixed like above string
       public static string project_root = Path.GetFullPath(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "..\\Silverzone.Web")) + "/";

    }

}
