namespace WebAPI_JORDY_HURTADO.Models
{
    public class Vuelos
    {
        public int IdVuelo { get; set; }
        public string NumeroVuelo { get; set; } = string.Empty;
        public int IdAerolinea { get; set; }
        public int IdAeropuertoOrigen { get; set; }
        public int IdAeropuertoDestino { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public DateTime FechaHoraLlegadaEstimada { get; set; }
        public int CapacidadEconomica { get; set; }
        public int CapacidadEjecutiva { get; set; }
    }
}


