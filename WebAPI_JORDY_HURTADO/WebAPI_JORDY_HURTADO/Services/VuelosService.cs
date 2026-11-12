using Dapper;
using WebAPI_JORDY_HURTADO.Data;
using WebAPI_JORDY_HURTADO.Dtos.Request;
using WebAPI_JORDY_HURTADO.Models;

namespace WebAPI_JORDY_HURTADO.Services
{
    public class VuelosService
    {
        private readonly DataDapper _dataDapper;

        public VuelosService(DataDapper dataDapper)
        {
            _dataDapper = dataDapper;
        }


        public async Task<IEnumerable<Vuelos>> GetVuelosAsync()
        {
            using var connection = _dataDapper.CreateConnection();
            var query = "SELECT * FROM Vuelos";
            var vuelos = await connection.QueryAsync<Vuelos>(query);
            return vuelos;
        }


        public async Task<IEnumerable<Vuelos>> GetVueloByIdAsync(int id)
        {
            using var connection = _dataDapper.CreateConnection();
            var query = "SELECT * FROM Vuelos WHERE IdVuelo = @Id";
            var vuelo = await connection.QueryAsync<Vuelos>(query, new { Id = id });
            return vuelo;
        }


        public async Task<IEnumerable<Vuelos>> CreateVueloAsync(VuelosRequest dto)
        {
            using (var connection = _dataDapper.CreateConnection())
            {
                var query = @"
                INSERT INTO Vuelos (NumeroVuelo, IdAerolinea, IdAeropuertoOrigen, IdAeropuertoDestino, FechaHoraSalida, FechaHoraLlegadaEstimada, CapacidadEconomica, CapacidadEjecutiva)
                VALUES (@NumeroVuelo, @IdAerolinea, @IdAeropuertoOrigen, @IdAeropuertoDestino, @FechaHoraSalida, @FechaHoraLlegadaEstimada, @CapacidadEconomica, @CapacidadEjecutiva);
                SELECT * FROM Vuelos WHERE IdVuelo = SCOPE_IDENTITY();";
          

                var paramters = new
                {

                    dto.NumeroVuelo,
                    dto.IdAerolinea,
                    dto.IdAeropuertoOrigen,
                    dto.IdAeropuertoDestino,
                    dto.FechaHoraSalida,
                    dto.FechaHoraLlegadaEstimada,
                    dto.CapacidadEconomica,
                    dto.CapacidadEjecutiva
                };

                var vuelos = await connection.QueryAsync<Vuelos>(query, paramters);
                return vuelos;
            }
        }



        public async Task<IEnumerable<Vuelos>> UpdateVueloAsync(int id, VuelosRequest dto)
        {
            using (var connection = _dataDapper.CreateConnection())
            {
                var query = @"
                UPDATE Vuelos
                SET NumeroVuelo = @NumeroVuelo,
                    IdAerolinea = @IdAerolinea,
                    IdAeropuertoOrigen = @IdAeropuertoOrigen,
                    IdAeropuertoDestino = @IdAeropuertoDestino,
                    FechaHoraSalida = @FechaHoraSalida,
                    FechaHoraLlegadaEstimada = @FechaHoraLlegadaEstimada,
                    CapacidadEconomica = @CapacidadEconomica,
                    CapacidadEjecutiva = @CapacidadEjecutiva
                WHERE IdVuelo = @Id;
                SELECT * FROM Vuelos WHERE IdVuelo = @Id;";
                var parameters = new
                {
                    Id = id,
                    dto.NumeroVuelo,
                    dto.IdAerolinea,
                    dto.IdAeropuertoOrigen,
                    dto.IdAeropuertoDestino,
                    dto.FechaHoraSalida,
                    dto.FechaHoraLlegadaEstimada,
                    dto.CapacidadEconomica,
                    dto.CapacidadEjecutiva
                };
                var vuelos = await connection.QueryAsync<Vuelos>(query, parameters);
                return vuelos;
            }
        }
    }
}
