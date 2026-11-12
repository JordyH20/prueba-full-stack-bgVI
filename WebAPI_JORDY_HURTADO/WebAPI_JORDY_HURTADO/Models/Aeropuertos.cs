namespace WebAPI_JORDY_HURTADO.Models
{
    public class Aeropuertos
    {
        public int IdAeropuerto { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string CodigoIATA { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; } = string.Empty;
    }
}
