using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using weatherApp.SRWeather;

namespace weatherApp
{
    public partial class DatosClimaticos : System.Web.UI.Page
    {
        WSWeatherSoapClient wsWeatherClient = new WSWeatherSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Administrador"] == null)
            {
                Server.Transfer("Access.aspx");

            }
            updateGrid();
        }

        protected void BtnSalir_Click(object sender, EventArgs e)
        {
            Session["Administrador"] = "";
            Response.Redirect("Access.aspx");
        }

        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            Weather newWeather = new Weather();
            newWeather.Temperatura = Convert.ToDecimal(txtTemperatura.Value.Replace(".",","));
            newWeather.Precipitacion = Convert.ToDecimal(txtPrecipita.Value.Replace(".", ","));
            newWeather.Humedad = Convert.ToDecimal(txthumedad.Value.Replace(".", ","));
            newWeather.VelocidadViento = Convert.ToDecimal(txtvelocidad.Value.Replace(".", ","));

            wsWeatherClient.addWeather(newWeather);

            updateGrid();
        }

        protected void updateGrid()
        {
            string json = wsWeatherClient.getDataWeather();

            DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));

            gvDatpsClimaticos.DataSource = dt;
            gvDatpsClimaticos.DataBind();

            //txtTemperatura.Text = "";
            //txtPrecipita.Value = "";
            //txthumedad.Value = "";
            //txtvelocidad.Value = "";
        }

        protected void gvDatpsClimaticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTemperatura.Value = gvDatpsClimaticos.SelectedRow.Cells[2].Text;
            txtPrecipita.Value = gvDatpsClimaticos.SelectedRow.Cells[3].Text;
            txthumedad.Value = gvDatpsClimaticos.SelectedRow.Cells[4].Text;
            txtvelocidad.Value = gvDatpsClimaticos.SelectedRow.Cells[5].Text;
            lblidClima.Text = gvDatpsClimaticos.SelectedRow.Cells[1].Text;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            Weather newWeather = new Weather();
            newWeather.idClima = Convert.ToInt32(lblidClima.Text);
            newWeather.Temperatura = Convert.ToDecimal(txtTemperatura.Value.Replace(".", ","));
            newWeather.Precipitacion = Convert.ToDecimal(txtPrecipita.Value.Replace(".", ","));
            newWeather.Humedad = Convert.ToDecimal(txthumedad.Value.Replace(".", ","));
            newWeather.VelocidadViento = Convert.ToDecimal(txtvelocidad.Value.Replace(".", ","));

            wsWeatherClient.updateDataWeather(newWeather);

            updateGrid();
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            wsWeatherClient.deleteDataWeather(Convert.ToInt32(lblidClima.Text));

            updateGrid();
        }
    }
}