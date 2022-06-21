using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XAct;

namespace LBA_COLMAS
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var datos = new ClientesDto()
            {
                Apellido = "barrios",
                Correo = "barrios@correo.kjsjs.bcom",
                Nombre = "prueba nombre",
                Telefono = 21616
            };

            string jsonString = JsonSerializer.Serialize(datos);

            CrearCliente(jsonString);
        }

        private bool CrearCliente(string _Cliente)
        {
            var url = $"https://localhost:44329/api/Peticion?peticion=" + _Cliente;
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] data = encoder.GetBytes(_Cliente);
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;
            request.Accept = "application/json";

            try
            {
                using (var response1 = request.GetRequestStream())
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                            }
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

            return true;
        }



    }
}