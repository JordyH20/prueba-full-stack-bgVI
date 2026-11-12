import { DatePipe } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';
import { Vuelo } from '../../interface/vuelo.interface';
import { Vuelos as VuelosService } from '../../services/vuelos';

@Component({
  imports: [DatePipe],
  selector: 'app-vuelos',
  styleUrl: './vuelos.css',
  templateUrl: './vuelos.html',
})
export class Vuelos implements OnInit {
  private readonly vuelosService = inject(VuelosService);

  vuelos = signal<Vuelo[]>([]);
  cargando = true;
  error = '';

  ngOnInit(): void {
    this.vuelosService.getVuelos().subscribe({
      next: (vuelos) => {
        console.log('Vuelos recibidos para mostrar:', vuelos);
        if (!Array.isArray(vuelos)) {
          this.error = 'La respuesta de la API no es una lista de vuelos.';
          this.cargando = false;
          return;
        }
        this.vuelos.set(vuelos);
        this.cargando = false;
      },
      error: (err) => {
        console.error('Error al cargar los vuelos:', err);
        this.error = `No se pudieron cargar los vuelos (HTTP ${err.status || 'sin respuesta'}). Revisa la consola del navegador y el acceso de CORS.`;
        this.cargando = false;
      },
    });
  }
}
