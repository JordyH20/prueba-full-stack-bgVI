import { Component } from '@angular/core';
import { Vuelos } from './components/vuelos/vuelos';

@Component({
  imports: [Vuelos],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {}
