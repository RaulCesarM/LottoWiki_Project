import { Component, OnInit } from '@angular/core';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-status',
  templateUrl: './status.component.html',
  styleUrls: ['./status.component.css']
})
export class StatusComponent implements OnInit {
  headers: number[] = Array.from({ length: 25}, (_, index) => index + 1);
 // headers: (number | string)[] = [...Array.from({ length: 25 }, (_, index) => index + 1), 'R', 'N', 'A'];
 

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

  getCountsForRow(row: string[]): { R: number; N: number; A: number } {
    const counts = { R: 0, N: 0, A: 0 };
    row.forEach(cell => {
      if (cell === 'R') counts.R++;
      if (cell === 'N') counts.N++;
      if (cell === 'A') counts.A++;
    });
    return counts;
  }

  calculateAverages() {
    const totalRows = this.cells.length;
  
    const totalCounts = this.cells.reduce(
      (totals, row) => {
        const counts = this.getCountsForRow(row);
        return {
          R: totals.R + counts.R,
          N: totals.N + counts.N,
          A: totals.A + counts.A,
        };
      },
      { R: 0, N: 0, A: 0 } 
    );
  
    return {
      averageR: totalRows > 0 ? (totalCounts.R / totalRows).toFixed(1) : 0,
      averageN: totalRows > 0 ? (totalCounts.N / totalRows).toFixed(1) : 0,
      averageA: totalRows > 0 ? (totalCounts.A / totalRows).toFixed(0) : 0,
    };
  }
  




}
