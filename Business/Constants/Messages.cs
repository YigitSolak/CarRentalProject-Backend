using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Başarıyla eklendi.";
        public static string NameInvalid = "İsim geçersiz.";
        public static string Listed = "Başarıyla listelendi.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string Deleted = "Başarıyla silindi.";
        public static string Updated = "Başarıyla güncellendi.";
        public static string CarImageLimitExceeded = "Araba resim sınırı aşıldı.";
        public static string AuthorizationDenied = "Yetkilendirme başarısız.";
    }
}
