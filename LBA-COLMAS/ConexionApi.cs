using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace LBA_COLMAS
{
    public class ConexionApi
    {
        public bool DBConex(string _Cliente)
        {
            string responseFromServer = string.Empty;
            WebRequest request = WebRequest.Create("https://localhost:44329/api/Peticion?peticion=" + _Cliente);
            request.Method = "POST";

            string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
            }           

            return Convert.ToBoolean(responseFromServer);

        }
    }
}