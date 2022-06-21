using java.awt.image;
using RestSharp;
using SharpDX;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XAct;
using DataBuffer = java.awt.image.DataBuffer;

namespace LBA_COLMAS
{
    public partial class Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void btnGuardarDatosCliente(object sender, EventArgs e)
        {

            var datos = new ClientesDto()
            {
                Apellido = (_apellido.FindControl("_apellido") as TextBox).Text,
                Correo = (_Correo.FindControl("_Correo") as TextBox).Text,
                Nombre = (_nombre.FindControl("_nombre") as TextBox).Text,
                Telefono = Convert.ToInt32((_Identificiacion.FindControl("_Identificiacion") as TextBox).Text),
            };

            string jsonString = JsonSerializer.Serialize(datos);

            CrearCliente(jsonString);
        }

        public bool CrearCliente(string _Cliente)
        {
            var result = new ConexionApi().DBConex(_Cliente);
            return result;
        }         



    }
}