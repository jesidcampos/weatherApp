using System;
using System.Collections.Generic;
using System.Linq;

namespace gbdWeather
{
    public class data
    {
        private dbDataDataContext dbContext = new dbDataDataContext();

        #region USER - CRUD
        public string addUsuario(string usuario, string nombre, string password)
        {
            try
            {
                User newUser = new User();
                newUser.usuario = usuario;
                newUser.Nombre = nombre;
                newUser.Password = password;

                dbContext.Users.InsertOnSubmit(newUser);
                dbContext.SubmitChanges();

                return "Ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
        }

        public List<User> getDataUsuario(string usuario)
        {
            try
            {
                List<User> InfoUser = dataUser(usuario);

                if (InfoUser.Count > 0)
                {
                    return InfoUser;
                }
                else
                {
                    return InfoUser;
                }
            }
            catch (Exception ex)
            {
                List<User> emptyUser = new List<User>();

                return emptyUser;
            }
        }

        public string updateDataUsuario(string usuario, string nombre, string password)
        {
            List<User> InfoUser = dataUser(usuario);

            foreach (User DataUsuario in InfoUser)
            {
                DataUsuario.Nombre = nombre;
                DataUsuario.Password = password;
            }

            try
            {
                dbContext.SubmitChanges();

                return "Ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
        }

        public string deleteUsuario(string usuario)
        {
            List<User> InfoUser = dataUser(usuario);

            foreach (var user in InfoUser)
            {
                dbContext.Users.DeleteOnSubmit(user);
            }

            try
            {
                dbContext.SubmitChanges();

                return "Registro eliminado!!!";
            }
            catch (Exception ex)
            {
                return "No encontrado!!!" + ex.Message;
            }
        }

        public List<User> dataUser(string usuario)
        {
            var dataUsuario = from DataUsuario in dbContext.Users
                              where DataUsuario.usuario.Equals(usuario)
                              select DataUsuario;
            return dataUsuario.ToList();
        }

        #endregion

        #region Weather - CRUD
        public string addWeather(Weather weather)
        {
            try
            {
                dbContext.Weathers.InsertOnSubmit(weather);
                dbContext.SubmitChanges();

                return "Ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
            #endregion
        }

        public List<Weather> getDataWeather()
        {
            try
            {
                List<Weather> InfoWeather = dataWeather();

                if (InfoWeather.Count > 0)
                {
                    return InfoWeather;
                }
                else
                {
                    return InfoWeather;
                }
            }
            catch (Exception ex)
            {
                List<Weather> emptyWeather = new List<Weather>();

                return emptyWeather;
            }
        }

        public string updateDataWeather(Weather weather)
        {
            List<Weather> InfoWeather = dataWeather(weather.idClima);

            foreach (Weather DataWeather in InfoWeather)
            {
                DataWeather.Temperatura = weather.Temperatura;
                DataWeather.Precipitacion = weather.Precipitacion;
                DataWeather.Humedad = weather.Humedad;
                DataWeather.VelocidadViento = weather.VelocidadViento;
            }

            try
            {
                dbContext.SubmitChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }
        }

        public string deleteDataWeather(int idClima)
        {
            List<Weather> InfoWeather = dataWeather(idClima);

            foreach (var weather in InfoWeather)
            {
                dbContext.Weathers.DeleteOnSubmit(weather);
            }

            try
            {
                dbContext.SubmitChanges();

                return "Registro eliminado!!!";
            }
            catch (Exception ex)
            {
                return "No encontrado!!!" + ex.Message;
            }
        }
        public List<Weather> dataWeather()
        {
            var dataWeather = from DataWeather in dbContext.Weathers
                              select DataWeather;
            return dataWeather.ToList();
        }

        public List<Weather> dataWeather(int idClima)
        {
            var dataWeather = from DataWeather in dbContext.Weathers
                              where DataWeather.idClima.Equals(idClima)
                              select DataWeather;

            return dataWeather.ToList();
        }
    }
}
