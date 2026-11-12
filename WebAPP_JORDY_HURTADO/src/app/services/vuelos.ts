import { inject, Injectable } from '@angular/core';
import { environment } from '../../environment';
import { Vuelo } from '../interface/vuelo.interface';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
})
export class Vuelos {
    private url =  `${environment.apiUrl}/VuelosControllers`; 
    private http = inject(HttpClient);

    getVuelos(): Observable<Vuelo[]> {
        return this.http.get<Vuelo[] | Vuelo>(this.url).pipe(
            map((respuesta) => Array.isArray(respuesta) ? respuesta : [respuesta])
        );
    }

    postVuelo(vuelo: Vuelo): Observable<Vuelo> {
        return this.http.post<Vuelo>(this.url, vuelo);
    }

}
