using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public static class Messages
    {
        public static string SuccessAdded = "Ekleme işlemi başarılı";
        public static string ErrorAdded = " Ekleme işlemi başarısız";

        public static string SuccessDeleted = "Silme işlemi başarılı";
        public static string SuccessUpdated = "Güncelleme işlemi başarılı";

        public static string SuccesListed = "Listeleme işlemi başarılı ";

        public static string SuccessGet = "Getirme işlemi başarılı";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

    }
}
