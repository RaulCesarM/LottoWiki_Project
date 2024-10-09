import { Component, OnInit } from '@angular/core';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent implements OnInit {
  headers: number[] = Array.from({ length: 25}, (_, index) => index + 1);
  // indexRow: number[] = Array.from({ length: 25 }, (_, index) => index + 1);

  concursos: number[] = [];
  cells: string[][] = [];

  constructor(private statusService: StatusService) {    
  }

  ngOnInit(): void {
    this.loadStatusData();
  }

  async loadStatusData(): Promise<void> {
    try {   
      this.cells = await this.statusService.getData();
      this.concursos = await this.statusService.getConcursos();  
    } catch (error) {    
    }
  }

  getCellColor(cellValue: string): string {
    if (cellValue === 'N') {
      return 'rgb(0, 169, 245)';
    }
    if (cellValue === 'R') {
      return 'rgb(36, 155, 201)';
    }
    if (cellValue === 'A') {
      return 'rgb(138, 119, 153)';
    }
    return '';
  }

  hoveredRowIndex: number | null = null;
  hoveredColumnIndex: number | null = null;

  onCellMouseOver(rowIndex: number, colIndex: number): void {
    this.hoveredRowIndex = rowIndex;
    this.hoveredColumnIndex = colIndex;
  }

  onCellMouseOut(): void {
    this.hoveredRowIndex = null;
    this.hoveredColumnIndex = null;
  }

  onCellMouseOvercol(colIndex: number): void {
    this.hoveredColumnIndex = colIndex;
  }

  onCellMouseOutcol(): void {
    this.hoveredColumnIndex = null;
  }
}
