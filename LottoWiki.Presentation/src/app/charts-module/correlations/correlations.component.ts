import { Component, OnInit } from '@angular/core';
import { CorrelationsService } from 'src/app/services/correlations.service';
import { MathService } from 'src/app/services/math.service';

@Component({
  selector: 'app-correlations',
  templateUrl: './correlations.component.html',
  styleUrls: ['./correlations.component.css'],
})
export class CorrelationsComponent implements OnInit {


  avarege: number = 0;
  max: number =0;
  min: number = 0;
  headers: number[] = Array.from({ length: 25 }, (_, index) => index + 1);
  footers: number[] = Array.from({ length: 25 }, (_, index) => index + 1);
  indexRow: number[] = Array.from({ length: 25 }, (_, index) => index + 1);
  cells: number[][] = [];

  constructor(
    private correlationsService: CorrelationsService,
    private mathService: MathService) {}

  async ngOnInit() {
    await this.loadCellsData();
  }

  async loadCellsData(): Promise<void> {
    this.cells = await this.correlationsService.getData();
    this.avarege = await this.mathService.calculateAverage(this.cells);
    this.max = await this.mathService.findMaxValue(this.cells);
    this.min = await this.mathService.findMinValue(this.cells);
  }
  getCellColor(cellNumber: number): string {
     if (cellNumber === 0) {
      return ` rgb(55, 169, 245)`;
    }
  
    const max: number = this.max;    
    const min: number = 50;
    const ratio: number = (cellNumber - min) / (max - min);  
    const clampedRatio = Math.max(0, Math.min(1, ratio));
     
    const red: number = Math.floor(255 * clampedRatio ); 
    const green: number = Math.floor(77 * clampedRatio + 169 * (1 - clampedRatio)); 
    const blue: number = Math.floor(77 * clampedRatio + 245 * (1 - clampedRatio));  
   
    return `rgb(${red}, ${green}, ${blue})`;
  }

  hoveredRowIndex!: number ;
  hoveredColumnIndex!: number;

  // onCellMouseOver(rowIndex: number, colIndex: number): void {
  //   console.log(rowIndex, colIndex )
  //   this.hoveredRowIndex = rowIndex;
  //   this.hoveredColumnIndex = colIndex;
  // }



  onCellMouseOver(rowIndex: number, colIndex: number): void {
    this.hoveredRowIndex = rowIndex;
    this.hoveredColumnIndex = colIndex;
  }

  
  onCellMouseOvercol(colIndex: number): void {
    this.hoveredColumnIndex = colIndex;
  }



  onCellMouseOverRow(rowIndex: number): void {
    console.log(`Mouse over row: ${rowIndex}`);
    this.hoveredRowIndex = rowIndex;
  }
  
  onCellMouseOut(): void {
    console.log(`Mouse out`);
    this.hoveredRowIndex = 0;
    this.hoveredColumnIndex = 0;
  }
  
  onCellMouseOutcol(): void {
   
 
    this.hoveredColumnIndex = 0;
  }
  
}
