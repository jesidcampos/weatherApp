using System;
using weatherApp.SRWeather;
using Newtonsoft.Json;
using System.Data;

namespace weatherApp
{
    public partial class Access : System.Web.UI.Page
    {
        WSWeatherSoapClient wsWeatherClient = new WSWeatherSoapClient();

        protected void Page_Load(object sender, EventArgs e)
        {   
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string json = wsWeatherClient.getDataUsuario(this.TextBox1.Text);

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            try
            {

                if ((this.TextBox1.Text == "jesidcampos@gmail.com"))
                {
                    Session["Administrador"] = this.TextBox1.Text;
                    Response.Redirect("DatosClimaticos.aspx");
                }
                else
                {

                }
            }
            catch (Exception)
            {
                //this.LblError.Text = "Error escribiendo Usuario o Contraseña ...  ";

            }

        }
    }
}