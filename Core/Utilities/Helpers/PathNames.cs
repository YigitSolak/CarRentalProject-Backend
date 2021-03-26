using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class PathNames
    {
        public static string BaseName = @"\WebAPI\wwwroot\";
        public static string CarImages = @"Uploads\Images\CarImages";
        public static string AddCarImage = BaseName + CarImages;
        public static string CarDefaultImages = CarImages + "\\default-image.jpg";
    }
}
