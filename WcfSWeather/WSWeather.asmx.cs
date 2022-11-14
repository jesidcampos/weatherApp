using gbdWeather;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace WcfSWeather
{
    /// <summary>
    /// Summary description for WSWeather
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WSWeather : System.Web.Services.WebService
    {
        #region User - CRUD
        
        [WebMethod]
        public string addUsuario(string usuario, string nombre, string password)
        {
            gbdWeather.data NewdataUser = new gbdWeather.data();

            return NewdataUser.addUsuario(usuario, nombre, password);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getDataUsuario(string usuario)
        {
            gbdWeather.data dataUser = new gbdWeather.data();

            List<User> lstUser = new List<gbdWeather.User>();

            lstUser = dataUser.getDataUsuario(usuario);

            return new JavaScriptSerializer().Serialize(lstUser.ToArray());
        }

        [WebMethod]
        public string updateDataUsuario(string usuario, string nombre, string password)
        {
            gbdWeather.data UpdateUser = new gbdWeather.data();

            return UpdateUser.updateDataUsuario(usuario, nombre, password);
        }

        [WebMethod]
        public string deleteUsuario(string usuario)
        {
            gbdWeather.data DeleteUser = new gbdWeather.data();

            return DeleteUser.deleteUsuario(usuario);
        }

        #endregion

        #region Weather Data - CRUD
        [WebMethod]
        public string addWeather(Weather weather)
        {
            gbdWeather.data NewDataWeather = new gbdWeather.data();

            return NewDataWeather.addWeather(weather);
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getDataWeather()
        {
            gbdWeather.data dataWeather = new gbdWeather.data();

            List<Weather> lstWeather = new List<gbdWeather.Weather>();

            lstWeather = dataWeather.getDataWeather();

            return new JavaScriptSerializer().Serialize(lstWeather.ToArray());
        }

        [WebMethod]
        public string updateDataWeather(Weather weather)
        {
            gbdWeather.data UpdateWeather = new gbdWeather.data();

            return UpdateWeather.updateDataWeather(weather);
        }

        [WebMethod]
        public string deleteDataWeather(int idClima)
        {
            gbdWeather.data DeleteWeather = new gbdWeather.data();

            return DeleteWeather.deleteDataWeather(idClima);
        }
        #endregion
    }
}
