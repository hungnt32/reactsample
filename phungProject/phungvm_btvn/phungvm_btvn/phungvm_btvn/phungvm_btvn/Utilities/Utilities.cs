using System;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel.Web;
using System.Text;

namespace phungvm_btvn.Utilities
{
    public static class Utilities
    {
        public static string GetHashSha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static string PasswordHash(string password)
        {
            string firsthash = GetHashSha256(password);
            int middleindex = password.Length / 2;
            string randomizedpassword = password.Insert(middleindex, firsthash.Substring(0, middleindex));
            return GetHashSha256(randomizedpassword);
        }

        public static string GetToken()
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            string token = headers["token"];
            return token;
        }

    }
}