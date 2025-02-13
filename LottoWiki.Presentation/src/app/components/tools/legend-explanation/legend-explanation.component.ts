import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-legend-explanation',
  templateUrl: './legend-explanation.component.html',
  styleUrls: ['./legend-explanation.component.css']
})
export class LegendExplanationComponent {
  legends = [
    { label: 'Ocorrencias', color: '#ADD8E6' },
    { label: 'Média', color: '#FF0000' },
    { label: 'tendencia exponencial', color: '#4188f1' },
    { label: 'tendencia aritmetica', color: '#000000' }
  ];
  
}