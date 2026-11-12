using System.ComponentModel.DataAnnotations;

namespace WebAPI_JORDY_HURTADO.Dtos.Request
{
    public class VuelosRequest
    {
        [Required]
        public string NumeroVuelo { get; set; } = string.Empty;

        [Required]
        public int IdAerolinea { get; set; }

        [Required]
        public int IdAeropuertoOrigen { get; set; }

        [Required]
        public int IdAeropuertoDestino { get; set; }

        [Required]
        public DateTime FechaHoraSalida { get; set; }

        [Required]
        public DateTime FechaHoraLlegadaEstimada { get; set; }

        [Required]
        public int CapacidadEconomica { get; set; }

        [Required]
        public int CapacidadEjecutiva { get; set; }
    }
}
