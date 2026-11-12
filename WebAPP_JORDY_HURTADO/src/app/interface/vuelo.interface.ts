export interface Vuelo {
    idVuelo: number;
    numeroVuelo: string;
    idAerolinea: number;
    idAeropuertoOrigen: number;
    idAeropuertoDestino: number;
    fechaHoraSalida: Date;
    fechaHoraLlegadaEstimada: Date;
    capacidadEconomica: number;
    capacidadEjecutiva: number;
}

