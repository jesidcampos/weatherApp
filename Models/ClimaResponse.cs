namespace weatherApp.Models
{
    public class ClimaResponse
    {
        public string Ciudad { get; set; } = string.Empty;
        public double Temperatura { get; set; }
        public double SensacionTermica { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int Humedad { get; set; }
        public double Viento { get; set; }
    }
}