using System.Text.Json;
using weatherApp.Models;

namespace weatherApp.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ClimaResponse> ObtenerClimaAsycn(string ciudad)
        {
            // GeoCodificación: nombre de ciudad -> Latitud/Longitud
            var geoUrl = $"https://geocoding-api.open-meteo.com/v1/search?name={ciudad}&count=1&language=es";

            var geoResp = await _httpClient.GetStringAsync(geoUrl);
            var geoData = JsonDocument.Parse(geoResp);

            if (!geoData.RootElement.TryGetProperty("results", out var results) || results.GetArrayLength() == 0)
                throw new Exception("Ciudad no encontrada");

            var location = results[0];
            var lat = location.GetProperty("latitude").GetDouble();
            var lon = location.GetProperty("longitude").GetDouble();
            var nombre = location.GetProperty("name").GetString();

            // Clima actual
            var climaUrl = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&current=temperature_2m,relative_humidity_2m,apparent_temperature,weather_code,wind_speed_10m";
            var climaResp = await _httpClient.GetStringAsync(climaUrl);
            var climaData = JsonDocument.Parse(climaResp);
            var current = climaData.RootElement.GetProperty("current");

            return new ClimaResponse
            {
                Ciudad = nombre ?? ciudad,
                Temperatura = current.GetProperty("temperature_2m").GetDouble(),
                SensacionTermica = current.GetProperty("apparent_temperature").GetDouble(),
                Humedad = current.GetProperty("relative_humidity_2m").GetInt32(),
                Viento = current.GetProperty("wind_speed_10m").GetDouble(),
                Descripcion = InterpretarCodigo(current.GetProperty("weather_code").GetInt32())
            };
        }

        private string InterpretarCodigo(int codigo)
        {
            return codigo switch
            {
                0 => "Cielo despejado",
                1 or 2 or 3 => "Parcialmente nublado",
                45 or 48 => "Niebla",
                51 or 53 or 55 => "Llovizna",
                61 or 63 or 65 => "Lluvia",
                71 or 73 or 75 => "Nieve",
                80 or 81 or 82 => "Chubascos",
                95 => "Tormenta",
                _ => "Desconocido"
            };
        }
    }
}